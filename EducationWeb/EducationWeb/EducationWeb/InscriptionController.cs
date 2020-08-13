using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EducationWeb.DOMAIN;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationWeb
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscriptionController : ControllerBase
    {
        private readonly ILogger<InscriptionController> _logger;
        private readonly IInscriptionRepository _InscriptionRepository;

        // GET: /<controller>/

        public InscriptionController(ILogger<InscriptionController> logger, IInscriptionRepository InscriptionRepository)
        {
            _logger = logger;
            _InscriptionRepository = InscriptionRepository;
        }
        [HttpGet]
        public IEnumerable<Inscription> List()
        {
            return _InscriptionRepository.GetAll();
        }
        /**[HttpGet("{id}")]
        public Inscription GetInsc(string id)
        {
            return _InscriptionRepository.GetById(id);
        } **/
        [HttpPost]
        public void create([FromBody]Inscription inscription)
        {
            Debug.WriteLine(inscription.InscId.ToString());
            _InscriptionRepository.Add(inscription);
        }

        [HttpDelete]
        public void delete(string id)
        {            
            _InscriptionRepository.delete(id);
        }
    }
}
