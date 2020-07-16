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
    public class CandidateController : ControllerBase
    {
        private ICandidateService _service;
        private IMapper _mapper;
        public CandidateController(ICandidateService service, IMapper mapper)
        {

            this._service = service;
            this._mapper = mapper;
        }

        // GET api/candite
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null) 
        {
            if ((companyId == null && accelerationId == null)  && (companyId != null && accelerationId != null)) {

                return NoContent();
            }

            if (companyId != null) {

                return Ok(_mapper.Map<IEnumerable<CandidateDTO>>(_service.FindByCompanyId((int)companyId)));
            }

            return Ok(_mapper.Map<IEnumerable<CandidateDTO>>(_service.FindByAccelerationId((int) accelerationId)));
        
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId) 
        {
            return Ok(_mapper.Map<CandidateDTO>(_service.FindById(userId,accelerationId,companyId)));

        }

        // POST api/challenge
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            return Ok(_mapper.Map<CandidateDTO>(_service.Save(_mapper.Map<Candidate>(value))));
            
        }

    }
}
