using Application.AppGolongan;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class GolonganController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetGolonganList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Bahasa>> GetGolonganById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGolongan(Golongan golongan)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Golongan = golongan }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditGolongan(Guid id, Golongan golongan)
        {
            golongan.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Golongan = golongan }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGolongan(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}