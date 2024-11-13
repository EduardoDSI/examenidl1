using ic_tienda_bussines.Auth.models;
using ic_tienda_bussines.Auth.repositories;
using ic_tienda_bussines.Errors;
using ic_tienda_presentacion.models;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers.Auth
{
    [ApiController]
    [Route("/api/v1/auth")]
    public class AuthenticationController : ControllerBase
    {
        public readonly ILogger _logger;
        private readonly IAuthenticationRepository _auth;
        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IAuthenticationRepository auth
            ) {
            _auth = auth;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login([FromBody]LoginRequest body) {
            try {
                return Ok(_auth.Login(body));
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoryController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[CategoryController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }


        [HttpPost]
        [Route("register")]
        public ActionResult<CustomResponse> Regiser([FromBody]RegisterRequest body) {
            try {
                _auth.Register(body);
                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoryController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[CategoryController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}