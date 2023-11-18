using BackEnd.Context;
using BackEnd.Dtos;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;

        public ItemsController(ApplicationDBContext context)
        {
            _Context = context;
        }

        //create
        [HttpPost]
        public async Task<ActionResult> CreateItem([FromBody] CreateUpdateItemsDto dto)
        {
            var newItem = new itemEntity()
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
            };
            await _Context.Items.AddAsync(newItem);
            await _Context.SaveChangesAsync();

            return Ok("Item Save Successfully");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<itemEntity>> GetProductByID([FromRoute] long id)
        {
            var item = await _Context.Items.FirstOrDefaultAsync(q => q.Id == id);

            if (item is null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(item);
        }

        //Update
        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateItem([FromRoute] long id, [FromBody] CreateUpdateItemsDto dto)
        {
            var Item = await _Context.Items.FirstOrDefaultAsync(p => p.Id == id);

            if (Item is null)
            {
                return NotFound("Item Is not found");
            }

            Item.Title = dto.Title;
            Item.Description = dto.Description;
            Item.Status = dto.Status;

            await _Context.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("id")]

        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var Item= await _Context.Items.FirstOrDefaultAsync(q => q.Id ==id);

            if(Item is null)
            {
                return NotFound("Product Not Found");
            }
            _Context.Items.Remove(Item);
            await _Context.SaveChangesAsync();

            return Ok("Product Deleted Successfully");
        }
    }
    
}
