import { BaseEntity } from './BaseEntity';
import type { UserAuthority } from './UserAuthority';
import type { UserSession } from './UserSession';

export interface User extends BaseEntity {
  username: string;
  email: string;
  passwordHash: string;
  firstName?: string;
  lastName?: string;
  phoneNumber?: string;
  roleId: number;
  roleNavigation?: UserAuthority;
  lastLoginDate?: string;
  isEmailConfirmed: boolean;
  isActive: boolean;
  refreshToken?: string;
  refreshTokenExpiryTime?: string;
  fullName?: string;
  sessions?: UserSession[];
}