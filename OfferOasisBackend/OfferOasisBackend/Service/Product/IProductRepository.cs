﻿using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service;

public interface IProductRepository : IGenericRepository<Product>
{
    public string TestGetAllProducts();
}