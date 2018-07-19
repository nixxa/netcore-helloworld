using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebModels;
using Core.Actions;
using AutoMapper;
using Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ValuesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Getting all products
        /// </summary>
        /// <returns>List of products</returns>
        /// <response code="200">Returns all products</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductReadModel>))]
        public async Task<ActionResult<IEnumerable<ProductReadModel>>> Get()
        {
            var response = await _mediator.Send(new GetAllProductsRequest());
            var result = _mapper.Map<ICollection<ProductReadModel>>(response);
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductReadModel))]
        [ProducesResponseType(400)]
        public ActionResult<string> Get(int id)
        {
            return Ok(new ProductReadModel { Name = "Product One" });
        }

        // POST api/values
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ProductReadModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _mapper.Map<Product>(model);
            product = await _mediator.Send(new SaveProductRequest(product));
            return Ok(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public IActionResult Put(int id, [FromBody] ProductReadModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
