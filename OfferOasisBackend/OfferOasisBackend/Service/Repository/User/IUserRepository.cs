﻿using OfferOasisBackend.Model;

namespace OfferOasisBackend.Service;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmail(string email);
}