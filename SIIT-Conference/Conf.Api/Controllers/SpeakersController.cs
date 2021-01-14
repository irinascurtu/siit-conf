using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Conf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly ISpeakerService speakerService;

        public SpeakersController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }


        // GET: api/<SpeakersController>
        [HttpGet]
        public IEnumerable<Speaker> Get()
        {
            return speakerService.GetAllSpeakers();
        }

        // GET api/<SpeakersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SpeakersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SpeakersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpeakersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
