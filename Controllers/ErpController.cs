using Microsoft.AspNetCore.Mvc;
using cms_webapi.Interfaces;
using cms_webapi.Data;
using Microsoft.AspNetCore.Authorization;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ErpController : ControllerBase
    {
        private readonly IErpService _IErpService;
        private readonly ErpCmsDbContext _erpContext;

        public ErpController(IErpService erpService, ErpCmsDbContext erpContext)
        {
            _IErpService = erpService;
            _erpContext = erpContext;
        }

        // VW (View) Endpoints - Sadece GET işlemleri
        [HttpGet("cari")]
        public async Task<IActionResult> GetAllCari()
        {
            var result = await _IErpService.GetAllCariAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("depo")]
        public async Task<IActionResult> GetAllDepo()
        {
            var result = await _IErpService.GetAllDepoAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("stok")]
        public async Task<IActionResult> GetAllStok()
        {
            var result = await _IErpService.GetAllStokAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("proje")]
        public async Task<IActionResult> GetAllProje()
        {
            var result = await _IErpService.GetAllProjeAsync();
            return StatusCode(result.StatusCode, result);
        }

        // FN (Function) Endpoints - Parametreli sorgular
        [HttpGet("onHandQuantity")]
        public async Task<IActionResult> GetOnHandQuantityWithSerial(
            [FromQuery] int? depoKodu = null,
            [FromQuery] string? stokKodu = null,
            [FromQuery] string? seriNo = null,
            [FromQuery] string? projeKodu = null)
        {
            try
            {
                var result = await _IErpService.GetOnHandQuantityWithSerialAsync(_erpContext, depoKodu, stokKodu, seriNo, projeKodu);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "An error occurred", Error = ex.Message });
            }
        }

        [HttpGet("product-pricing")]
        public async Task<IActionResult> GetProductPricing([FromQuery] string stokKodu)
        {
            var result = await _IErpService.GetProductPricingAsync(_erpContext, stokKodu);
            return StatusCode(result.StatusCode, result);
        }

        // Health Check
        [HttpGet("health")]
        public async Task<IActionResult> HealthCheck()
        {
            var result = await _IErpService.HealthCheckAsync();
            return StatusCode(result.StatusCode, result);
        }
    }
}
