using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Common;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Item;
using Platform.Core.Requests.ItemProgram;
using Platform.Core.Requests.Selection;
using Platform.Services;
using System.ComponentModel.Design;


namespace Platform.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IItemsService itemsService;

        public ItemsController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParameters itemParameters)
        {
            return Ok(await itemsService.GetAll(itemParameters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await itemsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemDto newItem)
        {
            return Ok(await itemsService.Create(newItem));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await itemsService.Delete(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateItemDto updatedItem)
        {
            return Ok(await itemsService.Update(id, updatedItem));
        }

        //[HttpPost("Add")]
        //public async Task<IActionResult> AddItemToProgram(AddItemProgramDto addItemProgram)
        //{
        //    return Ok(await itemsService.AddItemToProgram(addItemProgram));
        //}


    }
}
