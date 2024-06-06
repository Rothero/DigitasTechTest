using Microsoft.AspNetCore.Mvc;
using DigitasTechTest.Application.Interfaces;
using DigitasTechTest.Domain;
using System.Threading.Tasks;
using DigitasWebApi.Request;
using DigitasWebApi.Response;
namespace DigitasWebApi.Controllers
{
    [ApiController]
    [Route("Tasks")]
    public class DigitasWebApiController : Controller
    {
        private readonly IDigitasTaskService _taskService;

        public DigitasWebApiController(IDigitasTaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDigitasTasks()
        {
            var result = await _taskService.GetAllDigitasTasks();
            DigitasTaskResponse response = new DigitasTaskResponse(result);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDigitasTaskById(int id)
        {
            var result = await _taskService.GetDigitasTask(id);
            DigitasTaskResponse response =  new DigitasTaskResponse(result);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDigitasTask([FromBody] DigitasTaskRequest task)
        {
            var result = await _taskService.InsertDigitasTasks(task.ToDigitasTask());
            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDigitasTask([FromBody] DigitasTaskRequest task, int id)
        {
            var result = await _taskService.UpdateDigitasTasks(task.ToDigitasTask(id));
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDigitasTask(int id) 
        {
            var result = await _taskService.DeleteDigitasTasks(id);
            return Ok(result);
        }

    }
}
