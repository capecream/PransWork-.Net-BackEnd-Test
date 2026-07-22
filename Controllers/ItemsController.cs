using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    /// <summary>
    /// API layer: รับ HTTP request แล้วส่งต่อให้ Service
    /// ไม่มี business logic อยู่ในนี้ มีแค่การแปลง request/response
    /// Endpoint ตรงกับที่ฝั่ง Flutter (ApiService) เรียกใช้:
    ///   GET  /api/items
    ///   GET  /api/items/{id}
    ///   POST /api/items
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetAll()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound(new { message = $"ไม่พบรายการ id = {id}" });
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> Create([FromBody] Item item)
        {
            try
            {
                var created = await _itemService.CreateItemAsync(item);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
