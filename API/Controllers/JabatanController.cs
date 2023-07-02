using Application.AppJabatan;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class JabatanController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetJabatanList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Bahasa>> GetJabatanById(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBahasa(Jabatan jabatan)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Jabatan = jabatan }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBahasa(Guid id, Jabatan jabatan)
        {
            jabatan.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Jabatan = jabatan }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJabatan(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}