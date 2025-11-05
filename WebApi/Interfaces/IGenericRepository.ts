export interface IGenericRepository<T> {
  getById(id: number): Promise<T | null>;
  getAll(): Promise<T[]>;
  find(predicate: (item: T) => boolean): Promise<T[]>;
  firstOrDefault(predicate: (item: T) => boolean): Promise<T | null>;
  add(entity: T): Promise<T>;
  update(entity: T): Promise<T>;
  delete(id: number): Promise<void>;
  softDelete(id: number): Promise<void>;
  exists(id: number): Promise<boolean>;
  count(): Promise<number>;
  countWhere(predicate: (item: T) => boolean): Promise<number>;
  getPaged(pageNumber: number, pageSize: number): Promise<T[]>;
  getPagedFiltered(pageNumber: number, pageSize: number, predicate: (item: T) => boolean): Promise<T[]>;
}