using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Backend.Api.dto;
using Backend.Api.Models;
using Backend.Api.Repositories;
using Backend.Api.Utils.Errors.Types;

namespace Backend.Api.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;
        private readonly AuthService _authService;

        public UserService(UserRepository repository, AuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }


        public User Signup(SignupDto user)
        {
            User? emailExists = _repository.FindByEmail(user.Email);
            if (emailExists != null)
            {
                throw new BadRequestException("Email address already used");
            }

            User newUser = new();
            newUser.Name = user.Name;
            newUser.Email = user.Email;
            newUser.IsAdmin = user.IsAdmin;
            newUser.Password = user.Password; // criptografar com PasswordHasher em produção, não utilizar texto direto!
            _repository.Add(newUser);
            return newUser;
        }


        public TokenDto Signin(SigninDto signinDto)
        {
            User user = FindByEmail(signinDto.Email);
            bool match = CheckPassword(signinDto.Password, user);
            if (!match)
            {
                throw new NotFoundException("Invalid credentials");
            }

            string jwtToken = _authService.GenerateJwtToken(user);
            TokenDto tokenDto = new()
            {
                Email = user.Email,
                Name = user.Name,
                Token = jwtToken
            };
            return tokenDto;
        }

        private User FindByEmail(string email)
        {
            var user = _repository.FindByEmail(email) ?? throw new NotFoundException("Email not found");
            return user;
        }


        private bool CheckPassword(string password, User user)
        {
            if (password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> FindAll()
        {
            return _repository.FindAll();
        }

        public void Remove(string email)
        {
            User? userToRemove = _repository.FindByEmail(email) ?? throw new NotFoundException("Email not found");
            _repository.Remove(userToRemove);
        }



    }
}