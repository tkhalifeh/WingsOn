﻿using AutoMapper;
using System.Web.Http;
using WingsOn.Api.DTOs;
using WingsOn.Api.DTOs.Response;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Controllers
{
    public class PeopleController : BaseController
    {
        private readonly IRepository<Person> _repo;

        public PeopleController(IRepository<Person> repo)
        {
            _repo = repo;
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/people/{id}")]
        public IHttpActionResult Get(int id)
        {
            var person = _repo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PATCH api/<controller>/id
        [HttpPatch]
        [Route("api/people/{id}")]
        public IHttpActionResult Patch(int id, [FromBody]PersonDto model)
        {
            var person = _repo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            person.Email = model.Email;
            _repo.Save(person);

            PersonDto response = Mapper.Map<PersonDto>(person);
            return Ok(person);
        }
    }
}