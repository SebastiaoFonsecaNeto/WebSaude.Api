using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSaude.Api.Models;
using WebSaude.Domain.Contracts.Services;
using WebSaude.Domain.Dtos;

namespace WebSaude.Api.Controllers
{
    /// <inheritdoc />
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IProfissionalService _profissionalService;

        /// <inheritdoc />
        public AuthController(IProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;
        }

        /// <summary>
        /// Autenticar profissional para uso da api
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Profissional relacionado ao Id </returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<LoginModel> Login([FromBody] LoginDto login)
        {
            try
            {
                return  LoginModel.Create(_profissionalService.Login(login));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Refresh autenticação do profissional para uso da api
        /// </summary>
        /// <returns>Profissional relacionado ao Id </returns>
        [AllowAnonymous]
        [HttpPost("refresh")]
        public ActionResult<LoginModel> Refresh([FromBody] string token)
        {
            try
            {
                return LoginModel.Create(_profissionalService.RefreshToken(token));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Refresh autenticação do profissional para uso da api
        /// </summary>
        /// <returns>Profissional relacionado ao Id </returns>
        [HttpGet("{userId}/menu")]
        public ActionResult<List<MenuModel>> ConsultaMenu([FromRoute] int userId)
        {
            try
            {
                var permissao = _profissionalService.ConsultaMenu(userId);

                return MenuModel.CreateList(permissao.Itens);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
