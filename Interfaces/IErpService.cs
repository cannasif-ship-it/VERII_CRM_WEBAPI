using depoWebAPI.Models;
using cms_webapi.DTOs;
using cms_webapi.Data;

namespace cms_webapi.Interfaces
{
    public interface IErpService
    {
        // VW (View) Operations - Sadece GET işlemleri
        Task<ApiResponse<IEnumerable<RII_VW_CARI>>> GetAllCariAsync();
        Task<ApiResponse<IEnumerable<RII_VW_DEPO>>> GetAllDepoAsync();
        Task<ApiResponse<IEnumerable<RII_VW_STOK>>> GetAllStokAsync();
        Task<ApiResponse<IEnumerable<RII_VW_PROJE>>> GetAllProjeAsync();

        // FN (Function) Operations - Parametreli sorgular
        Task<ApiResponse<IEnumerable<RII_FN_ONHANDQUANTITY>>> GetOnHandQuantityWithSerialAsync(
            ErpCmsDbContext context, 
            int? depoKodu = null, 
            string? stokKodu = null, 
            string? seriNo = null, 
            string? projeKodu = null);

        Task<ApiResponse<IEnumerable<RII_FN_GetProductPricing>>> GetProductPricingAsync(ErpCmsDbContext context, string stokKodu);

        // Health Check
        Task<ApiResponse<object>> HealthCheckAsync();
    }
}
