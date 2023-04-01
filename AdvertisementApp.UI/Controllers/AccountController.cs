using AdvertisementApp.Bussniess.Interfaces;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService userService, IMapper mapper, IValidator<AppUserLoginDto> loginDtoValidator)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _userService = userService;
            _mapper = mapper;
            _loginDtoValidator = loginDtoValidator;
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel();
            model.Genders = new SelectList(response.Data, "Id", "Definition");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _userService.CreateWithRoleAsync(dto, (int)RoleType.Member); //look up tablelerde
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.ErrorMessage, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            return View(model);
        }


        public async Task<IActionResult> SignIn()
        {
            return View(new AppUserLoginDto());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _userService.CheckUser(dto);
            if (result.ResponseType == Common.ResponseType.Success)
            {
                //Claims oluştur
                var claims = new List<Claim>();


                var roleResult = await _userService.GetRoles(result.Data.Id);
                if (roleResult.ResponseType == Common.ResponseType.Success)
                {
                    foreach (var rol in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Definition));
                    }
                }
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));



                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError("Kullanıcı adı veya şifre yanlış", result.Message);
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
