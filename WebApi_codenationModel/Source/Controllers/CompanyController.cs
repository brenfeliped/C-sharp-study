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
    public class CompanyController : ControllerBase
    {
        private ICompanyService _service;
        private IMapper _mapper;
        public CompanyController(ICompanyService service, IMapper mapper)
        {

            this._service = service;
            this._mapper = mapper;
        }

        //GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId != null && userId != null) || (accelerationId == null && userId == null))
            {
                return NoContent();

            }
            else {
                if (accelerationId != null) {
                    return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(_service.FindByAccelerationId((int)accelerationId)));
                }

                return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(_service.FindByUserId((int)userId)));
            }

        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id) 
        {

            return Ok(_mapper.Map<CompanyDTO>(_service.FindById(id)));
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {

            return Ok(_mapper.Map<CompanyDTO>(_service.Save(_mapper.Map<Company>(value))));
        }
    }
}
