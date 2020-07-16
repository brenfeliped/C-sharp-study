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
    public class SubmissionController : ControllerBase
    {
        private ISubmissionService _service;
        private IMapper _mapper;
        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        // GET api/submission/higherScore
        [HttpGet("higherScore")]
        public ActionResult<Decimal> GetHigherScore(int? challengeId = null) 
        {
            if (challengeId == null) {
                return NoContent();
            }

            return Ok(_service.FindHigherScoreByChallengeId((int)challengeId));
        }

        // GET api/submission
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null) 
        {
            if (challengeId != null && accelerationId != null) {

                return Ok(_mapper.Map<IEnumerable<SubmissionDTO>>(_service
                    .FindByChallengeIdAndAccelerationId((int)challengeId,(int)accelerationId))); 
            }
            return NoContent();
        }

        //POST /api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value) 
        {
            return Ok(_mapper.Map<SubmissionDTO>(_service.Save(_mapper.Map<Submission>(value))));

        }
    }
}
