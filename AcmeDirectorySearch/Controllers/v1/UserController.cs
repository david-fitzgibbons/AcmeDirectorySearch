namespace AcmeDirectorySearch.Controllers.v1
{
    using AcmeDirectorySearch.Controllers.v1.Contracts;
    using AcmeDirectorySearch.Core.DTO;
    using AcmeDirectorySearch.Core.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">Dependecy injected User Service.</param>
        /// <param name="mapper">Dependecy injected AutoMapper.</param>
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retrieve a list of User objects that match the passed filters provided.  The filters
        /// will check against first name or last name.  Multiple filter parameters can be 
        /// passed at the same time to create a complex query (?filter=xyz&filter=abc)
        /// </summary>
        /// <param name="filter">text to match against first or last name</param>
        /// <returns>A <see cref="Task{TResult}"/> List <see cref="UserResponse"/></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<UserResponse>>> QueryByName([FromQuery] string[] filter)
        {
            // validate filter was provided
            if (filter == null || filter.Length == 0)
            {
                return this.BadRequest("Query filter required");
            }

            List<UserDTO> response = await this.userService.QueryUsersByName(filter);
            return this.mapper.Map<List<UserDTO>, List<UserResponse>>(response);
        }

        /// <summary>
        /// Retreive a single user by Id
        /// </summary>
        /// <param name="id">Numeric identifier of the User</param>
        /// <returns><see cref="UserResponse"/></returns>
        [HttpGet("{id}", Name = "Get_Single_User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> GetSingleUser(int id)
        {
            UserDTO response = await this.userService.GetSingleUser(id);
            return this.mapper.Map<UserDTO, UserResponse>(response);
        }

        /// <summary>
        /// Retrieves the User's Profile Image, if one was not provided 
        /// when the user was created then a default image will be returned
        /// </summary>
        /// <param name="id">Numeric identifier of the User</param>
        /// <returns><see cref="FileContentResult"/></returns>
        [HttpGet("{id}/image", Name = "Get_User_Image")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUserImage(int id)
        {
            UserImageDTO img = await this.userService.GetUserImage(id);
            return this.File(System.Convert.FromBase64String(img.Base64Image), img.Type);
        }

        /// <summary>
        /// Create a new User record along with their associated Address.
        /// </summary>
        /// <param name="newUser">JSON representation of the User and Address to be created.</param>
        /// <returns>A <see cref="Task{TResult}"/><see cref="UserResponse"/></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUser newUser)
        {
            UserDTO newUserDTO = this.mapper.Map<CreateUser, UserDTO>(newUser);
            UserDTO response = await this.userService.CreateUser(newUserDTO);

            return this.mapper.Map<UserDTO, UserResponse>(response);
        }
    }
}
