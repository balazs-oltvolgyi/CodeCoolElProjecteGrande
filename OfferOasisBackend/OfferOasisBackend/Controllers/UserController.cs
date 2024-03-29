﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Service;

namespace OfferOasisBackend.Controllers;

//TODO [Authorize]
[ApiController, Route("/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;

    public UserController(ILogger<UserController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }
    [HttpGet]
    public IActionResult GetByEmail(string email)
    {
        return Ok(_userRepository.GetByEmail(email));
    }
}