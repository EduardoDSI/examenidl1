using ic_tienda_bussines.Errors;
using ic_tienda_bussines.Store.models;
using ic_tienda_bussines.Store.repositories;
using ic_tienda_presentacion.Attributes;
using ic_tienda_presentacion.models;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("/api/v1/store/product")]
    public class ProductController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IProductRepository _prodRepo;
        public ProductController(
            IProductRepository prodRepo,
            ILogger<ProductController> logger
        ) {
          _prodRepo = prodRepo;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Product>> Listar()
        {
            try
            {
                List<Product> products = _prodRepo.product().GetAll();
                return Ok(products);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex) {
                _logger.LogError(
                    $"[ProductController][Listar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{product_id}")]
        public ActionResult<Product> Obtener([FromRoute]int product_id)
        {
            try
            {
                Product? product = _prodRepo.product().GetById(product_id); 
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    $"[ProductController][Obtener] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        [IsLogin]
        [HasRoles("1","2")]
        public ActionResult<Product> Crear([FromBody] ProductBody body)
        {
            try
            {
                Product product = _prodRepo.product().Create( (Product)body );
               
                return Ok(product);
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductController][Crear] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{product_id}")]
        [IsLogin]
        [HasRoles("1","2")]
        public ActionResult<CustomResponse> Actualizar([FromRoute] int product_id, 
                                     [FromBody] ProductBody body)
        {
            try
            {
                _prodRepo.product().Update(product_id, (Product)body);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductController][Actualizar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{product_id}")]
        [IsLogin]
        [HasRoles("1","2")]
        public ActionResult<CustomResponse> Eliminar([FromRoute] int product_id)
        {
            try
            {
                _prodRepo.product().Delete(product_id);

                return Ok(new CustomResponse());
            }
            catch(MessageExeption ex) {
                _logger.LogError(
                    $"[ProductController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ProductController][Eliminar] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}
