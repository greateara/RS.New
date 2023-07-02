using Application.AppGender;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class GenderController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetGenderList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGenderById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGender(Gender gender)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Gender = gender }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditGender(Guid id, Gender gender)
        {
            gender.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Gender = gender }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}