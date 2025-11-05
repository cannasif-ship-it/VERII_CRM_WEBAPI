import { ApiResponse } from '../Models/ApiResponse';
import { RII_VW_CARI } from '../Models/RII_VW_CARI';
import { RII_VW_DEPO } from '../Models/RII_VW_DEPO';
import { RII_VW_STOK } from '../Models/RII_VW_STOK';
import { RII_VW_PROJE } from '../Models/RII_VW_PROJE';
import { RII_FN_ONHANDQUANTITY } from '../Models/RII_FN_ONHANDQUANTITY';

export interface IErpService {
  getAllCari(): Promise<ApiResponse<RII_VW_CARI[]>>;
  getAllDepo(): Promise<ApiResponse<RII_VW_DEPO[]>>;
  getAllStok(): Promise<ApiResponse<RII_VW_STOK[]>>;
  getAllProje(): Promise<ApiResponse<RII_VW_PROJE[]>>;

  getOnHandQuantityWithSerial(params: {
    depoKodu?: number;
    stokKodu?: string;
    seriNo?: string;
    projeKodu?: string;
  }): Promise<ApiResponse<RII_FN_ONHANDQUANTITY[]>>;

  healthCheck(): Promise<ApiResponse<object>>;
}