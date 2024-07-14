using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uncos.Application.Categories.Queries.GetCategory;
using Uncos.Application.News.Queries.GetNewsList;

namespace Uncos.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CategoryController : BaseController
    {
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetCategoryVm>>> GetAll()
        {
            var query = new GetGategoryQuery { };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
