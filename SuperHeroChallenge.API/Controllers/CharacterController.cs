using Microsoft.AspNetCore.Mvc;
using SuperHero.Domain.Request;
using SuperHero.Domain.Response;
using SuperHero.Service.Interfaces;
using System;

namespace SuperHero.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }


        [HttpGet]
        public ObjectResult GetCharacter([FromQuery] CharacterRequest request)
        {
            try
            {
                var result = _characterService.GetCharacter(request);

                return Ok(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
