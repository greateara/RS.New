using Application.AppAgama;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AgamaController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAgamaList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // [Authorize]
        [HttpGet("{id}")]
        // public async Task<ActionResult<Agama>> GetAgamaById(Guid id)
        public async Task<IActionResult> GetAgamaById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
            // var result = await Mediator.Send(new Details.Query { Id = id });
            // if (result.IsSuccess && result.Value != null) return Ok(result.Value);
            // if (result.IsSuccess && result.Value == null) return NotFound();
            // return HandleResult(result);
        }

        [HttpGet("{SearchText}/{Count}/{Skip}")]
        // public async Task<ActionResult<Agama>> GetAgamaById(Guid id)
        public async Task<IActionResult> GetAgamaPage(string SearchText, int Count, int Skip)
        {
            return HandleResult(await Mediator.Send(new ListPage.Query
            { SearchText = SearchText, Count = Count, Skip = Skip }));
            // var result = await Mediator.Send(new Details.Query { Id = id });
            // if (result.IsSuccess && result.Value != null) return Ok(result.Value);
            // if (result.IsSuccess && result.Value == null) return NotFound();
            // return HandleResult(result);
        }

        [HttpGet("filter/{SearchText}")]
        // public async Task<ActionResult<Agama>> GetAgamaById(Guid id)
        public async Task<IActionResult> GetAgamaFilter(string SearchText)
        {
            return HandleResult(await Mediator.Send(new ListFilter.Query
            { SearchText = SearchText }));
            // var result = await Mediator.Send(new Details.Query { Id = id });
            // if (result.IsSuccess && result.Value != null) return Ok(result.Value);
            // if (result.IsSuccess && result.Value == null) return NotFound();
            // return HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgama(Agama agama)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Agama = agama }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAgama(Guid id, Agama agama)
        {
            agama.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Agama = agama }));
        }

        [HttpDelete("{id}/{timeStamp}")]
        public async Task<IActionResult> DeleteAgama(Guid id, string timeStamp)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id, TimeStamp = timeStamp }));
        }

    }
}