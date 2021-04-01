using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMvcSgq.Models.Interface
{
   public interface IAcessoRepositorio
    {
        IList<tbl_Acessos> GetAcessosFuncao(long idFuncao);
    }
}
