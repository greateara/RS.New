using Application.AppOrg;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // [AllowAnonymous]
    public class OrgController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetOrgList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrgType>> GetOrgById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrg(Org org)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Org = org }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrgType(Guid id, Org org)
        {
            org.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Org = org }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgType(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}