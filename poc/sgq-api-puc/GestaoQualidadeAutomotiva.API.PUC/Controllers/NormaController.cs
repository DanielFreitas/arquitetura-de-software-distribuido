using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GestaoQualidadeAutomotiva.API.PUC.Domain.Models;
using System.Threading.Tasks;
using GestaoQualidadeAutomotiva.API.PUC.Lib;
using GestaoQualidadeAutomotiva.API.PUC.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace GestaoQualidadeAutomotiva.API.PUC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormaController : ControllerBase
    {
        private readonly INormaService _service;
        private readonly IUrlHelper _urlHelper;

        public NormaController(IUrlHelper urlHelper, INormaService service)
        {
            _urlHelper = urlHelper;
            _service = service;
        }

        /// <summary>
        /// Get a specific norma by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}", Name = nameof(Get))]
        [Authorize]
        public async Task<ActionResult> Get(int id)
        {
            var norma = await _service.GetNorma(id);

            if (norma == null)
                return NotFound();

            var outputModel = GetModelLinks(norma);
            return Ok(outputModel);
        }

        /// <summary>
        /// Get all normas.
        /// </summary>
        [HttpGet(Name = nameof(GetAll))]
        [Authorize]
        public async Task<ActionResult> GetAll()
        {          
            var listNorma = await _service.GetListNorma();

            if (listNorma == null)
                return NotFound();

            List<LinksWrapper<Norma>> listRetorno = new List<LinksWrapper<Norma>>();

            foreach (Norma norma in listNorma)
            {
                listRetorno.Add(GetModelLinks(norma));
            }

            return Ok(listRetorno);
        }

        /// <summary>
        /// Updates a specific norma.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="norma"></param>
        /// <response code="400">Bad Request</response>
        /// <response code="404">ID not found or invalid</response>
        [HttpPut("{id}", Name = nameof(Update))]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] Norma norma)
        {
            if (id != norma.NormaId)
                return BadRequest();

            if (norma == null || id != norma.NormaId)
                return BadRequest();

            var normaAux = await _service.GetNorma(id);

            if (normaAux == null)
                return NotFound();

            if (!ModelState.IsValid)
                return new UnprocessableEntity(ModelState);

            _service.UpdateNorma(norma);

            return Ok();
        }

        /// <summary>
        /// Deletes a specific norma.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="404">ID not found or invalid</response>
        [HttpDelete("{id}", Name = nameof(Delete))]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var norma = await _service.GetNorma(id);

            if (norma == null)
                return NotFound();

            _service.DeleteNorma(norma);

            return Ok();
        }

        /// <summary>
        /// Creates a norma.
        /// </summary>
        /// <param name="norma"></param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Unprocessable Entity</response>
        [HttpPost(Name = nameof(Create))]
        [Authorize]
        public IActionResult Create([FromBody] Norma norma)
        {
            if (norma == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.AddNorma(norma);

            var outputModel = GetModelLinks(norma);
            return CreatedAtRoute("Get", new { id = outputModel.Content.NormaId }, outputModel);
        }

        private LinksWrapper<Norma> GetModelLinks(Norma model)
        {
            return new LinksWrapper<Norma>
            {
                Content = model,
                Links = GetLinksModel(model)
            };
        }

        private List<LinkInfo> GetLinksModel(Norma model)
        {
            var links = new List<LinkInfo>();

            links.Add(new LinkInfo(_urlHelper.Link(nameof(Get), new { id = model.NormaId }), rel: "self", method: "GET"));
            links.Add(new LinkInfo(_urlHelper.Link(nameof(Delete), new { id = model.NormaId }), rel: "delete-norma", method: "DELETE"));
            links.Add(new LinkInfo(_urlHelper.Link(nameof(Update), new { id = model.NormaId }), rel: "update-norma", method: "PUT"));

            return links;
        }

    }

}
