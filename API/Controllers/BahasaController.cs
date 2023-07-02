using Application.AppBahasa;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class BahasaController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetBahasaList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Bahasa>> GetBahasaById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBahasa(Bahasa bahasa)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Bahasa = bahasa }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBahasa(Guid id, Bahasa bahasa)
        {
            bahasa.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Bahasa = bahasa }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBahasa(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}