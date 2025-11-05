import { ApiResponse } from '../Models/ApiResponse';
import { ActivityDto, CreateActivityDto, UpdateActivityDto } from '../Models/ActivityDto';

export interface IActivityService {
  getAllActivities(): Promise<ApiResponse<ActivityDto[]>>;
  getActivityById(id: number): Promise<ApiResponse<ActivityDto>>;
  createActivity(createActivityDto: CreateActivityDto): Promise<ApiResponse<ActivityDto>>;
  updateActivity(id: number, updateActivityDto: UpdateActivityDto): Promise<ApiResponse<ActivityDto>>;
  deleteActivity(id: number): Promise<ApiResponse<object>>;
}