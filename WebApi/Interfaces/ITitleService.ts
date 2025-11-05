import { ApiResponse } from '../Models/ApiResponse';
import { TitleDto, CreateTitleDto, UpdateTitleDto } from '../Models/TitleDto';

export interface ITitleService {
  getAllTitles(): Promise<ApiResponse<TitleDto[]>>;
  getTitleById(id: number): Promise<ApiResponse<TitleDto>>;
  createTitle(createTitleDto: CreateTitleDto): Promise<ApiResponse<TitleDto>>;
  updateTitle(id: number, updateTitleDto: UpdateTitleDto): Promise<ApiResponse<TitleDto>>;
  deleteTitle(id: number): Promise<ApiResponse<object>>;
}