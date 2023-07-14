using ErrorHandling.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private List<Student> students = new List<Student>();
        private ILoggerManager _logger;

        public ValuesController(ILoggerManager logger)
        {
            _logger = logger;
            students = new List<Student>()
            {
                new Student()
            {
                Id=1,
                Name="First Name",
            },
            new Student()
            {
                Id= 2,
                Name="Second Name"
            },new Student() { Id=3, Name="Third Name"}
            };

        }

        [HttpGet]
        public IActionResult Get()
        {
       
                _logger.LogInfo("Fetching all the Students from the storage");

                throw new Exception("Exception while fetching all the students from the storage.");
                _logger.LogInfo($"Returning {students.Count} students.");
                return Ok(students);

        }


    }
}
