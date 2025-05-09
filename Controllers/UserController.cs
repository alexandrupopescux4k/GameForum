﻿using GameForum.Models;
using GameForum.Services;
using GameForum.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userService.GetUserByIdAsync(userId);
        return View(user);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateProfile(User updatedUser)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _userService.UpdateProfileAsync(userId, updatedUser.UserName, updatedUser.AboutMe, updatedUser.ProfileImg);
        return RedirectToAction("Profile");
    }
}
