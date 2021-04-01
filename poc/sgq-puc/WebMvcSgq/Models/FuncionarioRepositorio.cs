using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models.Interface;
using WebMvcSgq.Utils;

namespace WebMvcSgq.Models
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        db_sgqEntities db = new db_sgqEntities(AppSettings.GetConnectionStringByName("SqlConnectionString"));

        tbl_Funcionario IFuncionarioRepositorio.GetLoginFuncionario(tbl_Funcionario funcionarioLogin)
        {
            try
            {
                tbl_Funcionario func = db.tbl_Funcionario.SingleOrDefault(x => x.DsSenha == funcionarioLogin.DsSenha && x.DsUsuario == funcionarioLogin.DsUsuario);

                return func;   
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }


    }
}