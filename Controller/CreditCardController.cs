using System;
using System.Text.Json;
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
        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult<String>> Post(
            [FromServices] DataContext context,
            [FromBody] CreditCard model)
        {
            if (ModelState.IsValid)
            {
                model.cardNumber = RandomCardNumber.generate();

                context.CreditCards.Add(model);
                await context.SaveChangesAsync();

                return model.cardNumber;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("list/{email:maxlength(50)}")]
        public async Task<ActionResult<List<String>>> GetByEmail([FromServices] DataContext context, string email)
        {
            // var creditCards = await (from obj in context.CreditCards
            //                         where obj.email == email
            //                         select obj.cardNumber).ToListAsync();

            var creditCards = await context.CreditCards
                .Where(o => o.email == email)
                .Select(o => o.cardNumber)
                .ToListAsync();

            return creditCards;

        }

    }

}