export interface UserAuthorityDto {
  id: number;
  title: string;
}

export interface CreateUserAuthorityDto {
  title: string;
}

export interface UpdateUserAuthorityDto {
  title?: string;
}