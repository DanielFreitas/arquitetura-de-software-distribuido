using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.Sessao
{
    public class Acessos
    {
        private IAcessoRepositorio rep = null;

        public Acessos()
        {
            this.rep = new AcessoRepositorio();
        }

        public string HOME = "/HOME";
        public string HOME_ABOUT = "/HOME/ABOUT";
        public string HOME_CONTACT = "/HOME/CONTACT";
        public string PROCESSO = "/PROCESSO";
        public string PROCESSO_ADICIONAPROCESSO = "/PROCESSO/ADICIONARPROCESSO";
        public string PROCESSO_EDITARPROCESSO = "/PROCESSO/EDITARPROCESSO";
        public string PROCESSO_DELETARPROCESSO = "/PROCESSO/DELETARPROCESSO";
        public string PROCESSO_DETALHES = "/PROCESSO/DETALHES";
        public string LOGIN_LOGIN = "/LOGIN/LOGIN";
        public string ATIVIDADEDIARIA = "/ATIVIDADEDIARIA";
        public string ATIVIDADEDIARIA_INDEX = "/ATIVIDADEDIARIA/INDEX";
        public string ATIVIDADEDIARIA_ADICIONAATIVIDADEDIARIA = "/ATIVIDADEDIARIA/ADICIONAATIVIDADEDIARIA";
        public string ATIVIDADEDIARIA_DELETARATIVIDADEDIARIA = "/ATIVIDADEDIARIA/DELETARATIVIDADEDIARIA";
        public string ATIVIDADEDIARIA_EDITARATIVIDADEDIARIA = "/ATIVIDADEDIARIA/EDITARATIVIDADEDIARIA";
        public string ATIVIDADEDIARIA_DETALHES = "/ATIVIDADEDIARIA/DETALHES";
        public string NAOCONFORMIDADE = "/NAOCONFORMIDADE";
        public string NAOCONFORMIDADE_INDEX = "/NAOCONFORMIDADE/INDEX";
        public string RELATORIO = "/RELATORIO";
        public string RELATORIO_INDEX = "/RELATORIO/INDEX";
        public string RELATORIONAOCONFORMIDADE = "/RELATORIONAOCONFORMIDADE";
        public string RELATORIONAOCONFORMIDADE_INDEX = "/RELATORIONAOCONFORMIDADE/INDEX";
        public string NORMA = "/NORMA";
        public string NORMA_INDEX = "/NORMA/INDEX";
        public string ETAPA = "/ETAPA";
        public string ETAPA_ADICIONARETAPA = "/ETAPA/ADICIONARETAPA";
        public string ETAPA_EDITARETAPA = "/ETAPA/EDITARETAPA";
        public string ETAPA_DELETARETAPA = "/ETAPA/DELETARETAPA";
        public string ETAPA_DETALHES = "/ETAPA/DETALHES";
        public string ETAPA_INDEX = "/ETAPA/INDEX";

        public bool ConsultaAcesso(string caminhoUrl)
        {
            bool validar = false;

            if (caminhoUrl.Equals("/"))
                caminhoUrl = "/Home";

            tbl_Funcionario usuario = SessaoUsuario.SessaoUsuarios;

            IList<tbl_Acessos> lista = rep.GetAcessosFuncao(usuario.IdFuncao.Value);

            if (lista.Where(p => p.DsAcesso.ToUpper().Equals(caminhoUrl.ToUpper())).Count() > 0)
                validar = true;

            return validar;
        }



        public List<String> listaAcessos()
        {
            List<String> lista = new List<string>();

            lista.Add(HOME);
            lista.Add(HOME_ABOUT);
            lista.Add(HOME_CONTACT);
            lista.Add(PROCESSO);
            lista.Add(PROCESSO_ADICIONAPROCESSO);
            lista.Add(PROCESSO_EDITARPROCESSO);
            lista.Add(PROCESSO_DELETARPROCESSO);
            lista.Add(PROCESSO_DETALHES);
            lista.Add(LOGIN_LOGIN);
            lista.Add(ATIVIDADEDIARIA);
            lista.Add(ATIVIDADEDIARIA_ADICIONAATIVIDADEDIARIA);
            lista.Add(ATIVIDADEDIARIA_DELETARATIVIDADEDIARIA);
            lista.Add(ATIVIDADEDIARIA_EDITARATIVIDADEDIARIA);
            lista.Add(ATIVIDADEDIARIA_DETALHES);
            lista.Add(NAOCONFORMIDADE);
            lista.Add(NAOCONFORMIDADE_INDEX);
            lista.Add(RELATORIO);
            lista.Add(RELATORIO_INDEX);
            lista.Add(RELATORIONAOCONFORMIDADE);
            lista.Add(RELATORIONAOCONFORMIDADE_INDEX);
            lista.Add(NORMA);
            lista.Add(NORMA_INDEX);
            lista.Add(ETAPA);
            lista.Add(ETAPA_ADICIONARETAPA);
            lista.Add(ETAPA_EDITARETAPA);
            lista.Add(ETAPA_DELETARETAPA);
            lista.Add(ETAPA_DETALHES);
            lista.Add(ETAPA_INDEX);

            return lista;
        }

    }
}