using ic_tienda_bussines.Auth.models;
using ic_tienda_bussines.Errors;
using ic_tienda_bussines.Store.models;
using ic_tienda_bussines.Store.repositories;
using ic_tienda_presentacion.Attributes;
using ic_tienda_presentacion.models;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("/api/v1/store/brand")]
    public class BrandController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IProductRepository _prodRepo;
        public BrandController(
            IProductRepository prodRepo,
            ILogger<BrandController> logger
        ) {
          _prodRepo = prodRepo;
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        public ActionResult<List<Brand>> Listar()
        {
            try
            {
                List<Brand> brands = _prodRepo.brand().GetAll();
                return Ok(brands);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[BrandController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[BrandController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{brand_id}")]

        public ActionResult<Brand> Obtener([FromRoute]int brand_id)
        {
            try
            {
                Brand? brand = _prodRepo.brand().GetById(brand_id); 
                if (brand == null)
                {
                    return NotFound();
                }
                return Ok(brand);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[BrandController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[BrandController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        [IsLogin]
        [HasRoles("1","2")]
        public ActionResult<Brand> Crear([FromBody] BrandBody body)
        {
            try
            {
                Brand brand = _prodRepo.brand().Create( (Brand)body );
               
                return Ok(brand);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[BrandController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BrandController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{brand_id}")]
        [IsLogin]
        [HasRoles("1","2")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int brand_id, 
                                     [FromBody] BrandBody body)
        {
            try
            {
                _prodRepo.brand().Update(brand_id, (Brand)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[BrandController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BrandController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{brand_id}")]
        [IsLogin]
        [HasRoles("1","2", "3")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int brand_id)
        {
            try
            {
                _prodRepo.brand().Delete(brand_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[BrandController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BrandController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}
