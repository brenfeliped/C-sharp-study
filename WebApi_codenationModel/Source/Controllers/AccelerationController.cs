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
    public class AccelerationController : ControllerBase
    {
        private IAccelerationService _service;
        private IMapper _mapper;

        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        // GET api/acceleration
        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null) 
        {
            if (companyId == null) {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<AccelerationDTO>>(_service.FindByCompanyId((int)companyId)));

        }

        // GET api/acceleration/{id}
        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id) 
        {
            return Ok(_mapper.Map<AccelerationDTO>(_service.FindById(id)));
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value) 
        {

            return Ok(_mapper.Map<AccelerationDTO>(_service.Save(_mapper.Map<Acceleration>(value))));
        }
    }
}
