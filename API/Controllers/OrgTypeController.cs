using Application.AppOrgType;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using Persistence;

namespace API.Controllers
{
    // [AllowAnonymous]
    public class OrgTypeController : BaseApiController
    {
        // private readonly IMediator _mediator;
        // public OrgTypeController(IMediator mediator)
        // {
        //     _mediator    = mediator;
        // }

        // [HttpGet(Name = "GetWeatherForecast")]

        [HttpGet]
        public async Task<IActionResult> GetOrgTypeList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
            // var rr = await Mediator.Send(new List.Query());
            // return rr;
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrgType>> GetOrgTypeById(Guid id)
        {
            // var rr = await _context.ROrgType.FindAsync(id);
            // if (rr == null) return await _context.ROrgType.FirstOrDefaultAsync();
            // var ret = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
            // if (ret.IsSuccess && ret.Value != null) return Ok(ret.Value);
            // if (ret.IsSuccess && ret.Value == null) return NotFound();
            // return BadRequest(ret.Error);
            // var ret = await Mediator.Send(new Details.Query { Id = id });
            // if (ret == null) return NotFound();
            // return ret;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrgType(OrgType orgType)
        {
            return HandleResult(await Mediator.Send(new Create.Command { OrgType = orgType }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrgType(Guid id, OrgType orgType)
        {
            orgType.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { OrgType = orgType }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgType(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}