﻿using GameForum.Models;
using GameForum.Repositories.Interfaces;
using GameForum.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GameForum.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly UserManager<User> _userManager;

        public UserService(IRepositoryWrapper repo, UserManager<User> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return _repo.UserRepository.FindByCondition(u => u.Id == id).FirstOrDefault();
        }

        public async Task UpdateProfileAsync(string id, string newUsername, string aboutMe, string newImg)
        {
            var user = _repo.UserRepository.FindByCondition(u => u.Id == id).FirstOrDefault();
            if (user == null) return;

            user.UserName = newUsername;
            user.AboutMe = aboutMe;
            user.ProfileImg = newImg;
            _repo.UserRepository.Update(user);
        }
    }

}
