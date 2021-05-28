using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using creditCardApi.Data;
using creditCardApi.Models;
using creditCardApi.Utils;

namespace creditCardApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CreditCardController : ControllerBase
    {
        // [HttpGet]
        // [Route("{email:string}")]
        // public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        // {
        //     var categories = await context.Categories.ToListAsync();
        //     return categories;
        // }

        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult<CreditCard>> Post(
            [FromServices] DataContext context,
            [FromBody] CreditCard model)
        {
            if (ModelState.IsValid)
            {
                model.cardNumber = RandomCardNumber.generate();

                context.CreditCards.Add(model);
                await context.SaveChangesAsync();

                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }

}