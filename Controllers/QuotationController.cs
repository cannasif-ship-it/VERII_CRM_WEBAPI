using Microsoft.AspNetCore.Mvc;
using cms_webapi.DTOs;
using Microsoft.AspNetCore.Authorization;
using cms_webapi.Interfaces;

namespace cms_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        /// <summary>
        /// Tüm teklifleri getirir
        /// </summary>
        /// <returns>Teklif listesi</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuotationGetDto>>> GetQuotations()
        {
            try
            {
                var quotations = await _quotationService.GetAllQuotationsAsync();
                return Ok(quotations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// ID'ye göre teklif getirir
        /// </summary>
        /// <param name="id">Teklif ID</param>
        /// <returns>Teklif detayı</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<QuotationGetDto>> GetQuotation(long id)
        {
            try
            {
                var quotation = await _quotationService.GetQuotationByIdAsync(id);
                if (quotation == null)
                {
                    return NotFound($"Quotation with ID {id} not found.");
                }
                return Ok(quotation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Yeni teklif oluşturur
        /// </summary>
        /// <param name="createQuotationDto">Teklif oluşturma bilgileri</param>
        /// <returns>Oluşturulan teklif</returns>
        [HttpPost]
        public async Task<ActionResult<QuotationDto>> CreateQuotation(CreateQuotationDto createQuotationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var quotation = await _quotationService.CreateQuotationAsync(createQuotationDto);
                return CreatedAtAction(nameof(GetQuotation), new { id = quotation.Id }, quotation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Teklifi günceller
        /// </summary>
        /// <param name="id">Teklif ID</param>
        /// <param name="updateQuotationDto">Güncellenecek teklif bilgileri</param>
        /// <returns>Güncellenmiş teklif</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<QuotationDto>> UpdateQuotation(long id, UpdateQuotationDto updateQuotationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var quotation = await _quotationService.UpdateQuotationAsync(id, updateQuotationDto);
                if (quotation == null)
                {
                    return NotFound($"Quotation with ID {id} not found.");
                }

                return Ok(quotation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Teklifi siler
        /// </summary>
        /// <param name="id">Teklif ID</param>
        /// <returns>Silme işlemi sonucu</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotation(long id)
        {
            try
            {
                var result = await _quotationService.DeleteQuotationAsync(id);
                if (!result)
                {
                    return NotFound($"Quotation with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Potansiyel müşteriye göre teklifleri getirir
        /// </summary>
        /// <param name="potentialCustomerId">Potansiyel müşteri ID</param>
        /// <returns>Teklif listesi</returns>
        [HttpGet("by-potential-customer/{potentialCustomerId}")]
        public async Task<ActionResult<IEnumerable<QuotationGetDto>>> GetQuotationsByPotentialCustomer(long potentialCustomerId)
        {
            try
            {
                var quotations = await _quotationService.GetQuotationsByPotentialCustomerIdAsync(potentialCustomerId);
                return Ok(quotations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Temsilciye göre teklifleri getirir
        /// </summary>
        /// <param name="representativeId">Temsilci ID</param>
        /// <returns>Teklif listesi</returns>
        [HttpGet("by-representative/{representativeId}")]
        public async Task<ActionResult<IEnumerable<QuotationGetDto>>> GetQuotationsByRepresentative(long representativeId)
        {
            try
            {
                var quotations = await _quotationService.GetQuotationsByRepresentativeIdAsync(representativeId);
                return Ok(quotations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Duruma göre teklifleri getirir
        /// </summary>
        /// <param name="status">Durum</param>
        /// <returns>Teklif listesi</returns>
        [HttpGet("by-status/{status}")]
        public async Task<ActionResult<IEnumerable<QuotationGetDto>>> GetQuotationsByStatus(int status)
        {
            try
            {
                var quotations = await _quotationService.GetQuotationsByStatusAsync(status);
                return Ok(quotations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
