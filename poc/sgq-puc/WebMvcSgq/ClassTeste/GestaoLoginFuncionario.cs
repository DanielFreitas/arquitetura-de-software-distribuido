using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.ClassTeste
{
    public class GestaoLoginFuncionario
    {

        private readonly IFuncionarioRepositorio _Ifr;
        public GestaoLoginFuncionario(IFuncionarioRepositorio ifr)
        {
            this._Ifr = ifr;
        }

        public GestaoLoginFuncionario()
        {
            this._Ifr = new FuncionarioRepositorio();
        }

        public tbl_Funcionario GetFuncionario(tbl_Funcionario func)
        {
            tbl_Funcionario funcRet = _Ifr.GetLoginFuncionario(func);

            return funcRet;
        }

    }
}