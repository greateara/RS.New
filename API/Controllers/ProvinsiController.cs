using Application.AppProvinsi;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class ProvinsiController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetProvinsiList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvinsiById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpGet("{SearchText}/{Count}/{Skip}")]
        public async Task<IActionResult> GetProvinsiPage(string SearchText, int Count, int Skip)
        {
            return HandleResult(await Mediator.Send(new ListPage.Query
            { SearchText = SearchText, Count = Count, Skip = Skip }));
        }

        [HttpGet("filter/{SearchText}")]
        public async Task<IActionResult> GetProvinsiFilter(string SearchText)
        {
            return HandleResult(await Mediator.Send(new ListFilter.Query
            { SearchText = SearchText }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvinsi(Provinsi provinsi)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Provinsi = provinsi }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProvinsi(Guid id, Provinsi provinsi)
        {
            provinsi.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Provinsi = provinsi }));
        }

        [HttpDelete("{id}/{timeStamp}")]
        public async Task<IActionResult> DeleteProvinsi(Guid id, string timeStamp)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id, TimeStamp = timeStamp }));
        }

    }
}