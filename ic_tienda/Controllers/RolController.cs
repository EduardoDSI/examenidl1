// using ic_tienda_bussines.Auth.models;
// using ic_tienda_bussines.Auth.repositories;
// using ic_tienda_bussines.Errors;
// using ic_tienda_presentacion.models;
// using Microsoft.AspNetCore.Mvc;

// namespace ic_tienda.Controllers
// {
//     [ApiController]
//     [Route("/api/v1/rol")]
//     public class RolController : ControllerBase
//     {
//         public readonly ILogger _logger;
//         public readonly IAuthRepository _auth;
//         public RolController(
//             IAuthRepository auth,
//             ILogger<RolController> logger
//         ) {
//           _auth = auth;
//             _logger = logger;
//         }

//         [HttpGet]
//         [Route("")]
//         public ActionResult<List<Rol>> Listar()
//         {
//             try
//             {
//                 List<Rol> roles = _auth.rolService.GetAll();
//                 return Ok(roles);
//             }
//             catch(MessageExeption ex) {
//                 _logger.LogError(
//                     $"[RolController][Listar] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
//             }
//             catch (Exception ex) {
//                 _logger.LogError(
//                     $"[RolController][Listar] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true));
//             }
//         }

//         [HttpGet]
//         [Route("{rol_id}")]
//         public ActionResult<Rol> Obtener([FromRoute]int rol_id)
//         {
//             try
//             {
//                 Rol? rol = _auth.rolService.GetById(rol_id); 
//                 if (rol == null)
//                 {
//                     return NotFound();
//                 }
//                 return Ok(rol);
//             }
//             catch(MessageExeption ex) {
//                 _logger.LogError(
//                     $"[RolController][Obtener] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
//             }
//             catch(Exception ex)
//             {
//                 _logger.LogError(
//                     $"[RolController][Obtener] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true));
//             }
//         }

//         [HttpPost]
//         [Route("")]
//         public ActionResult<Rol> Crear([FromBody] RolBody body)
//         {
//             try
//             {
//                 Rol rol = _auth.rolService.Create( (Rol)body );
               
//                 return Ok(rol);
//             }
//             catch(MessageExeption ex) {
//                 _logger.LogError(
//                     $"[RolController][Crear] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(
//                     $"[RolController][Crear] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true));
//             }
//         }

//         [HttpPut]
//         [Route("{rol_id}")]
//         public ActionResult<CustomResponse> Actualizar([FromRoute] int rol_id, 
//                                      [FromBody] RolBody body)
//         {
//             try
//             {
//                 _auth.rolService.Update(rol_id, (Rol)body);

//                 return Ok(new CustomResponse());
//             }
//             catch(MessageExeption ex) {
//                 _logger.LogError(
//                     $"[RolController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(
//                     $"[RolController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true));
//             }
//         }

//         [HttpDelete]
//         [Route("{rol_id}")]
//         public ActionResult<CustomResponse> Eliminar([FromRoute] int rol_id)
//         {
//             try
//             {
//                 _auth.rolService.Delete(rol_id);

//                 return Ok(new CustomResponse());
//             }
//             catch(MessageExeption ex) {
//                 _logger.LogError(
//                     $"[RolController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(
//                     $"[RolController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
//                 return StatusCode(500, new CustomResponse(error: true));
//             }
//         }
//     }
// }
