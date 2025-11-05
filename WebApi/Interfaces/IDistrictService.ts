import { ApiResponse } from '../Models/ApiResponse';
import { DistrictGetDto, DistrictCreateDto, DistrictUpdateDto } from '../Models/DistrictDto';

export interface IDistrictService {
  getAllDistricts(): Promise<ApiResponse<DistrictGetDto[]>>;
  getDistrictById(id: number): Promise<ApiResponse<DistrictGetDto>>;
  createDistrict(districtCreateDto: DistrictCreateDto): Promise<ApiResponse<DistrictGetDto>>;
  updateDistrict(id: number, districtUpdateDto: DistrictUpdateDto): Promise<ApiResponse<DistrictGetDto>>;
  deleteDistrict(id: number): Promise<ApiResponse<object>>;
}