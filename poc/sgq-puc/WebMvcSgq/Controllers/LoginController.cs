using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Interface;
using WebMvcSgq.Sessao;

namespace WebMvcSgq.Controllers
{
    public class LoginController : Controller
    {

        private IFuncionarioRepositorio rep = null/* TODO Change to default(_) if this is not a reference type */;

        public LoginController()
        {
            this.rep = new FuncionarioRepositorio();
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_Funcionario login)
        {
            tbl_Funcionario funcionario = rep.GetLoginFuncionario(login);

            if (funcionario != null) {
                Session["Usuario"] = funcionario;
                SessaoUsuario.SessaoUsuarios = funcionario;
                Response.Redirect(Constants.Constants.PAGINA_HOME);
            }
            else
            {
                ViewBag.Message = "Usuário ou Senha estão errados!";
            }

            return View();
        }
    }
}