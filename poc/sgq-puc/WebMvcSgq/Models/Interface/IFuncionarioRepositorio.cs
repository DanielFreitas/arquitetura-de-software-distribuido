using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMvcSgq.Models.Interface
{
    public interface IFuncionarioRepositorio
    {
        tbl_Funcionario GetLoginFuncionario(tbl_Funcionario funcionarioLogin);
     
    }
}
