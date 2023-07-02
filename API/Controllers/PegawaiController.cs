using Application.AppPegawai;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class PegawaiController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetPegawaiList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Pegawai>> GetPegawaiById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePegawai(Pegawai pegawai)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Pegawai = pegawai }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPegawaiType(Guid id, Pegawai pegawai)
        {
            pegawai.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Pegawai = pegawai }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePegawaiType(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}