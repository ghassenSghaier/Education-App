using System;
using System.Collections.Generic;
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
    public class FormationController : ControllerBase
    {
        private readonly ILogger<FormationController> _logger;
        private readonly IFormationRepository _FormationRepsitory;

        // GET: /<controller>/

        public FormationController(ILogger<FormationController> logger, IFormationRepository FormationRepsitory)
        {
            _logger = logger;
            _FormationRepsitory = FormationRepsitory;
        }
        [HttpGet]
        public IEnumerable<Formation> Get()
        {
            return _FormationRepsitory.GetNonInsc();
        }        
        [HttpPost]
        public void Add(Formation formation)
        {
             _FormationRepsitory.Add(formation);
        }
    }
}
