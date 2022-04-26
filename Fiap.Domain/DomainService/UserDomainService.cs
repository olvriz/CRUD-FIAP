using Microsoft.IdentityModel.Tokens;
using Fiap.Domain.Auth;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Entities;
using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;
using Fiap.Domain.ServiceInterface;
using Fiap.Domain.Strings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainService
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly IAccountRepository _accountRepository;

        public UserDomainService(IUserRepository userRepository, IAuthenticatorService authenticatorService, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _authenticatorService = authenticatorService;
            _accountRepository = accountRepository;
        }

        private User ValidateAndGetUser(string email)
        {
            var user = _userRepository.GetUser(email);

            if (user == null)
                throw new ApplicationException(ErrorMessages.InvalidCredentials);

            return user;
        }       

        public AccessToken GetUserAccessToken(AuthenticateRequest authenticate)
        {
            var user = ValidateAndGetUser(authenticate.Email);

            if (!user.IsValidPassword(authenticate.Password))
                throw new ApplicationException(ErrorMessages.InvalidCredentials);

            return _authenticatorService.GenerateAccessToken(user.UserId);
        }

        public async Task<bool> RegisytryUser(UserCreateRequest userCreate)
        {
            var alreadyExists = await _userRepository.UserAlreadyExists(userCreate.Email);

            if (alreadyExists)
                throw new ApplicationException(ErrorMessages.UserAlreadyExists);

            var IsCreated = await _userRepository.RegistryUser(userCreate);

            if (!IsCreated)
                throw new Exception(ErrorMessages.DefaultErrorMessage);

            var userId = await _userRepository.GetUserId(userCreate.Email);

            await _accountRepository.CreateUserAccount(userId);

            var accountId = await _accountRepository.GetUserAccountId(userId);

            if (accountId == null)
                throw new ApplicationException(ErrorMessages.NotAccountHolder);

            return await _accountRepository.InsertInitialAccountBalance(accountId.Value);                        
        }
    }
}
