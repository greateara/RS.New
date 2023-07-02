using Application.AppSelect;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class SelectController : BaseApiController
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSelectList(string id)
        {
            return HandleResult(await Mediator.Send(new List.Query { Id = id }));
        }



    }
}