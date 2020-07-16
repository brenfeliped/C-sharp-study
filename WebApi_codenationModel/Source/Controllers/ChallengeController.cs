using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private IChallengeService _service;
        private IMapper _mapper;
        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        //GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null) 
        {
            if ((accelerationId == null || userId == null))
            {

                return NoContent();
            }
   
            return Ok(_mapper.Map<IEnumerable<ChallengeDTO>>(_service.FindByAccelerationIdAndUserId((int)accelerationId,(int)userId)));
        }

        // POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value) {

            return Ok(_mapper.Map<ChallengeDTO>(_service.Save(_mapper.Map<Models.Challenge>(value))));
        
        }
    }
}
