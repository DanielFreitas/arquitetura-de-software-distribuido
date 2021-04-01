using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;

namespace WebMvcSgq.Sessao
{
    public  class SessaoUsuario
    {
        public static tbl_Funcionario SessaoUsuarios { get; set; }

        public static Boolean VerificarLogin()
        {
            bool retorno = false;

            if (SessaoUsuarios == null)
                retorno = true;

            return retorno;
        }

    }
}