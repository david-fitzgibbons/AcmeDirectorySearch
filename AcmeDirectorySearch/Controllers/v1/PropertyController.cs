namespace AcmeDirectorySearch.Controllers.v1
{
    using AcmeDirectorySearch.Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        /// <summary>
        /// Returns possible states to be used in an Address
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> List of States.</returns>
        [HttpGet("states", Name = "Get")]
        public async Task<ActionResult<List<string>>> GetStates()
        {
            var result = await this.propertyService.GetStates();
            return result.ToList();
        }
    }
}
