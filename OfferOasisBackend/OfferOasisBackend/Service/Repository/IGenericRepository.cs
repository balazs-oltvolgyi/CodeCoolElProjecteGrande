﻿

namespace OfferOasisBackend.Service;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetById(int id);
    Task<IEnumerable<T?>> GetAll();
    Task<bool> Add(T entity);
    Task<T?> Remove(int id);
}