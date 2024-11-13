using ic_tienda_bussines.Errors;
using ic_tienda_bussines.Store.models;
using ic_tienda_bussines.Store.repositories;
using ic_tienda_presentacion.Attributes;
using ic_tienda_presentacion.models;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("/api/v1/store/category")]
    public class CategoryController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IProductRepository _prodRepo;
        public CategoryController(
            IProductRepository prodRepo,
            ILogger<CategoryController> logger
        ) {
          _prodRepo = prodRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Category>> Listar()
        {
            try
            {
                List<Category> categories = _prodRepo.category().GetAll();
                return Ok(categories);
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

        [HttpGet]
        [Route("{brand_id}")]
        public ActionResult<Category> Obtener([FromRoute]int brand_id)
        {
            try
            {
                Category? category = _prodRepo.category().GetById(brand_id); 
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoryController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[CategoryController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        [IsLogin]
        [HasRoles("1","2")]
        public ActionResult<Category> Crear([FromBody] CategoryBody body)
        {
            try
            {
                Category category = _prodRepo.category().Create( (Category)body );
               
                return Ok(category);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoryController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoryController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{brand_id}")]
        [IsLogin]
        [HasRoles("1","2")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int brand_id, 
                                     [FromBody] CategoryBody body)
        {
            try
            {
                _prodRepo.category().Update(brand_id, (Category)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoryController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoryController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }


        [HttpDelete]
        [Route("{brand_id}")]
        [IsLogin]
        [HasRoles("1","2")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int brand_id)
        {
            try
            {
                _prodRepo.category().Delete(brand_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[CategoryController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoryController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}
