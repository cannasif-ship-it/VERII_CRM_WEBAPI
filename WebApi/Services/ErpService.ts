import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IErpService } from '../Interfaces/IErpService';
import { ApiResponse } from '../Models/ApiResponse';
import { RII_VW_CARI } from '../Models/RII_VW_CARI';
import { RII_VW_DEPO } from '../Models/RII_VW_DEPO';
import { RII_VW_STOK } from '../Models/RII_VW_STOK';
import { RII_VW_PROJE } from '../Models/RII_VW_PROJE';
import { RII_FN_ONHANDQUANTITY } from '../Models/RII_FN_ONHANDQUANTITY';

const api = axios.create({
  baseURL: API_BASE_URL + '/Erp',
  timeout: DEFAULT_TIMEOUT,
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
    'X-Language': CURRENTLANGUAGE,
  },
});

api.interceptors.request.use((config: AxiosRequestConfig) => {
  const token = getAuthToken();
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

export class ErpService implements IErpService {
  async getAllCari(): Promise<ApiResponse<RII_VW_CARI[]>> {
    try {
      const response = await api.get<ApiResponse<RII_VW_CARI[]>>('/cari');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<RII_VW_CARI[]>(error);
    }
  }

  async getAllDepo(): Promise<ApiResponse<RII_VW_DEPO[]>> {
    try {
      const response = await api.get<ApiResponse<RII_VW_DEPO[]>>('/depo');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<RII_VW_DEPO[]>(error);
    }
  }

  async getAllStok(): Promise<ApiResponse<RII_VW_STOK[]>> {
    try {
      const response = await api.get<ApiResponse<RII_VW_STOK[]>>('/stok');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<RII_VW_STOK[]>(error);
    }
  }

  async getAllProje(): Promise<ApiResponse<RII_VW_PROJE[]>> {
    try {
      const response = await api.get<ApiResponse<RII_VW_PROJE[]>>('/proje');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<RII_VW_PROJE[]>(error);
    }
  }

  async getOnHandQuantityWithSerial(params: { depoKodu?: number; stokKodu?: string; seriNo?: string; projeKodu?: string; }): Promise<ApiResponse<RII_FN_ONHANDQUANTITY[]>> {
    try {
      const query = new URLSearchParams();
      if (params.depoKodu !== undefined && params.depoKodu !== null) query.append('depoKodu', String(params.depoKodu));
      if (params.stokKodu) query.append('stokKodu', params.stokKodu);
      if (params.seriNo) query.append('seriNo', params.seriNo);
      if (params.projeKodu) query.append('projeKodu', params.projeKodu);

      const response = await api.get<ApiResponse<RII_FN_ONHANDQUANTITY[]>>(`/onHandQuantity?${query.toString()}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<RII_FN_ONHANDQUANTITY[]>(error);
    }
  }

  async healthCheck(): Promise<ApiResponse<object>> {
    try {
      const response = await api.get<ApiResponse<object>>('/health');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}