using APIProject.DataModel;
using APIProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var AllStudents = _studentRepository.GetAllStudentAsync();

            return Ok(AllStudents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Student = await _studentRepository.GetStudentByIdAsync(id);
            if (Student == null)
            {
                return NotFound();
            }
            return Ok(Student);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student studentObj)
        {
            var createdStdID = await _studentRepository.AddStudentAsync(studentObj);

            return CreatedAtAction(
                        nameof(Get),
                        new { id = createdStdID, controller = "Student" },
                        createdStdID
                   );

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student studentObj)
        {
            await _studentRepository.UpdateStudentAsync(id, studentObj);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
            return Ok();

        }


    }
}
