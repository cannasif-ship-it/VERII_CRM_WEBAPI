export interface UserDto {
  id: number;
  firstName: string;
  lastName: string;
  fullName: string;
  email: string;
  username: string;
  phoneNumber?: string;
  role: string;
  lastLoginDate?: string;
  isEmailConfirmed: boolean;
  createdDate: string;
  isDeleted: boolean;
}

export interface CreateUserDto {
  firstName: string;
  lastName: string;
  email: string;
  username: string;
  password: string;
  phoneNumber?: string;
  role: string;
}

export interface UpdateUserDto {
  firstName?: string;
  lastName?: string;
  email?: string;
  phoneNumber?: string;
  role?: string;
  isActive?: boolean;
}

export interface ChangePasswordDto {
  currentPassword: string;
  newPassword: string;
}