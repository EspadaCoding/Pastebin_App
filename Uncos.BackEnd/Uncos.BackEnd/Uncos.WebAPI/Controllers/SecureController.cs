using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Uncos.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : BaseController
    {
        [HttpGet("check-IsAuthenticated")] 
        public IActionResult Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(new { Message = "User is authenticated", User = User.Identity.Name });
            }
            else
            {
                return Unauthorized(new { Message = "User is not authenticated" });
            }
        }

        [HttpGet("secure-data")] 
        public IActionResult GetSecureData()
        {
            var userId = UserId;
            if (userId == Guid.Empty)
            {
                return Unauthorized("User is not authenticated.");
            }

            // Use the Mediator to handle some business logic
            // var result = await Mediator.Send(new SomeQuery { UserId = userId });

            return Ok(new { Message = "User is authenticated", UserId = userId });
        }

        [HttpGet] 
        [Route("CheckPermissions")] 
        public IActionResult CheckPermissions()
        {
            try
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images");
                var testFilePath = Path.Combine(folderPath, "testfile.txt");

                if (!Directory.Exists(folderPath))
                {
                    return NotFound("Папка не найдена.");
                }

                // Попробуйте создать и удалить тестовый файл, чтобы проверить права на запись и удаление
                using (var fs = new FileStream(testFilePath, FileMode.CreateNew))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("Тест");
                    }
                }
                System.IO.File.Delete(testFilePath);

                return Ok("Права доступа в порядке.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка доступа к файлам: {ex.Message}");
            }
        }
    }
}
