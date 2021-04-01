using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;

namespace WebMvcSgq.ClassTeste
{
    public class GestaoAtividadeDiaria
    {
        private readonly IAtividadeDiariaRepositorio _ipr;
        public GestaoAtividadeDiaria(IAtividadeDiariaRepositorio proId)
        {
            this._ipr = proId;
        }

        public void AdicionaAtividadeDiaria(Tbl_Atividade_Diaria ativDiaria)
        {
            _ipr.AdicionaAtividadeDiaria(ativDiaria);
        }

        public void EditarAtividadeDiaria(Tbl_Atividade_Diaria ativ, List<tbl_atividades> listaAtividade)
        {
            _ipr.EditarAtividadeDiaria(ativ, listaAtividade);
        }

        public void DeletarAtividadeDiaria(long idAtividadeDiaria)
        {
           _ipr.DeletarAtividadeDiaria(idAtividadeDiaria);
        }

        public Tbl_Atividade_Diaria Detalhes(int idAtivDiaria)
        {
           return _ipr.Detalhes(idAtivDiaria);
        }

        public IEnumerable <Tbl_Atividade_Diaria> GetAtividadeDiaria()
        {
            return _ipr.GetAtividadeDiaria();
        }

        public Tbl_Atividade_Diaria GetAtividadePorID(int idAtivDiaria)
        {
            return _ipr.GetAtividadePorID(idAtivDiaria);
        }

        public AtiviModelView GetAtividadeDiariaPorID(long idAtivDiaria)
        {
            return _ipr.GetAtividadeDiariaPorID(idAtivDiaria);
        }

        public void EditarAtividadeDiaria(AtiviModelView ativi)
        {
            _ipr.EditarAtividadeDiaria(ativi);
        }

    }
}