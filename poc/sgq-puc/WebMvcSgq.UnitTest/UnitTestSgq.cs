using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using WebMvcSgq.ClassTeste;
using WebMvcSgq.Models;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;
using Assert = NUnit.Framework.Assert;
namespace WebMvcSgq.UnitTest
{
    [TestFixture]
    [TestClass]
    public class UnitTestSgq
    {

        #region GestaoAcesso

        private GestaoAcesso _getAcesso;
        private Mock<IAcessoRepositorio> _mockAces;

        [TestCase]
        [TestMethod]
        public void GetAcessos()
        {
            _mockAces = new Mock<IAcessoRepositorio>();
            _getAcesso = new GestaoAcesso(_mockAces.Object);

            IList<tbl_Acessos> esperado = new List<tbl_Acessos>();

            long idFuncao = 1;

            _mockAces.Setup(x => x.GetAcessosFuncao(It.IsAny<long>())).Returns(esperado);

            IList<tbl_Acessos> obtido = _getAcesso.GetAcessosFuncao(idFuncao);
            Assert.AreEqual(esperado, obtido);
        }

        #endregion

        #region GestaoAtividade

        private GestaoAtividade _getAtividade;
        private Mock<IAtividadeRepositorio> _mockAtiv;

        [TestCase]
        [TestMethod]
        public void SalvarAtividade()
        {
            _mockAtiv = new Mock<IAtividadeRepositorio>();
            _getAtividade = new GestaoAtividade(_mockAtiv.Object);

            tbl_atividades ativ = new tbl_atividades();

            _mockAtiv.Setup(x => x.SalvarAtividade(It.IsAny<tbl_atividades>()));

            _getAtividade.SalvarAtividade(ativ);
        }

        [TestCase]
        [TestMethod]
        public void GetAtividade()
        {
            _mockAtiv = new Mock<IAtividadeRepositorio>();
            _getAtividade = new GestaoAtividade(_mockAtiv.Object);

            List<tbl_atividades> ativ = new List<tbl_atividades>();

            long idAtividade = 2;

            _mockAtiv.Setup(x => x.GetAtividade(It.IsAny<long>())).Returns(ativ);

            IEnumerable<tbl_atividades> obtido = _getAtividade.GetAtividade(idAtividade);
            Assert.AreEqual(ativ, obtido);

        }

        #endregion

        #region GestaoAtividadeDiaria

        private GestaoAtividadeDiaria _getAtividadeDiaria;
        private Mock<IAtividadeDiariaRepositorio> _mockAtivDia;

        [TestCase]
        [TestMethod]
        public void AdicionaAtividadeDiaria()
        {
            _mockAtivDia = new Mock<IAtividadeDiariaRepositorio>();
            _getAtividadeDiaria = new GestaoAtividadeDiaria(_mockAtivDia.Object);

            Tbl_Atividade_Diaria ativ = new Tbl_Atividade_Diaria();

            _mockAtivDia.Setup(x => x.AdicionaAtividadeDiaria(It.IsAny<Tbl_Atividade_Diaria>()));

            _getAtividadeDiaria.AdicionaAtividadeDiaria(ativ);
        }

        [TestCase]
        [TestMethod]
        public void DetalhesDiaria()
        {
            _mockAtivDia = new Mock<IAtividadeDiariaRepositorio>();
            _getAtividadeDiaria = new GestaoAtividadeDiaria(_mockAtivDia.Object);

            Tbl_Atividade_Diaria ativ = new Tbl_Atividade_Diaria();

            int idAtividade = 2;

            _mockAtivDia.Setup(x => x.Detalhes(It.IsAny<int>())).Returns(ativ);

            Tbl_Atividade_Diaria obtido = _getAtividadeDiaria.Detalhes(idAtividade);
            Assert.AreEqual(ativ, obtido);

        }

        [TestCase]
        [TestMethod]
        public void EditarDiaria()
        {
            _mockAtivDia = new Mock<IAtividadeDiariaRepositorio>();
            _getAtividadeDiaria = new GestaoAtividadeDiaria(_mockAtivDia.Object);

            Tbl_Atividade_Diaria ativ = new Tbl_Atividade_Diaria();
            List<tbl_atividades> listaAtividade = new List<tbl_atividades>();

            _mockAtivDia.Setup(x => x.EditarAtividadeDiaria(It.IsAny<Tbl_Atividade_Diaria>(), It.IsAny<List<tbl_atividades>>()));

            _getAtividadeDiaria.EditarAtividadeDiaria(ativ, listaAtividade);

        }

        [TestCase]
        [TestMethod]
        public void DeletarAtividadeDiaria()
        {
            _mockAtivDia = new Mock<IAtividadeDiariaRepositorio>();
            _getAtividadeDiaria = new GestaoAtividadeDiaria(_mockAtivDia.Object);

            long idAtividadeDiaria = 2;

            _mockAtivDia.Setup(x => x.DeletarAtividadeDiaria(It.IsAny<long>()));

            _getAtividadeDiaria.DeletarAtividadeDiaria(idAtividadeDiaria);

        }

        [TestCase]
        [TestMethod]
        public void GetAtividadeDiaria()
        {
            _mockAtivDia = new Mock<IAtividadeDiariaRepositorio>();
            _getAtividadeDiaria = new GestaoAtividadeDiaria(_mockAtivDia.Object);

            List<Tbl_Atividade_Diaria> list = new List<Tbl_Atividade_Diaria>();

            _mockAtivDia.Setup(x => x.GetAtividadeDiaria()).Returns(list);

            IEnumerable<Tbl_Atividade_Diaria> obtido = _getAtividadeDiaria.GetAtividadeDiaria();

            Assert.AreEqual(list, obtido);

        }

        [TestCase]
        [TestMethod]
        public void GetAtividadePorID()
        {
            _mockAtivDia = new Mock<IAtividadeDiariaRepositorio>();
            _getAtividadeDiaria = new GestaoAtividadeDiaria(_mockAtivDia.Object);

            Tbl_Atividade_Diaria ativ = new Tbl_Atividade_Diaria();
            int ativiDiaria = 2;

            _mockAtivDia.Setup(x => x.GetAtividadePorID(It.IsAny<long>())).Returns(ativ);

            Tbl_Atividade_Diaria obtido = _getAtividadeDiaria.GetAtividadePorID(ativiDiaria);

            Assert.AreEqual(ativ, obtido);
        }

        [TestCase]
        [TestMethod]
        public void GetAtividadeDiariaPorID()
        {
            _mockAtivDia = new Mock<IAtividadeDiariaRepositorio>();
            _getAtividadeDiaria = new GestaoAtividadeDiaria(_mockAtivDia.Object);

            AtiviModelView ativ = new AtiviModelView();

            long ativiDiaria = 2;

            _mockAtivDia.Setup(x => x.GetAtividadeDiariaPorID(It.IsAny<long>())).Returns(ativ);

            AtiviModelView obtido = _getAtividadeDiaria.GetAtividadeDiariaPorID(ativiDiaria);

            Assert.AreEqual(ativ, obtido);
        }

        [TestCase]
        [TestMethod]
        public void EditarAtividadeDiaria()
        {
            _mockAtivDia = new Mock<IAtividadeDiariaRepositorio>();
            _getAtividadeDiaria = new GestaoAtividadeDiaria(_mockAtivDia.Object);

            AtiviModelView ativ = new AtiviModelView();


            _mockAtivDia.Setup(x => x.EditarAtividadeDiaria(It.IsAny<AtiviModelView>()));

            _getAtividadeDiaria.EditarAtividadeDiaria(ativ);

        }


        #endregion

        #region GestaoEtapa

        private GestaoEtapa _getEtapa;
        private Mock<IEtapaRepositorio> _mockEtapa;

        [TestCase]
        [TestMethod]
        public void GetEtapas()
        {
            _mockEtapa = new Mock<IEtapaRepositorio>();
            _getEtapa = new GestaoEtapa(_mockEtapa.Object);

            IList<tbl_etapa> esperado = new List<tbl_etapa>();

            long idFuncao = 1;

            _mockEtapa.Setup(x => x.GetEtapas(It.IsAny<long>())).Returns(esperado);

            IEnumerable<tbl_etapa> obtido = _getEtapa.GetEtapas(idFuncao);
            Assert.AreEqual(esperado, obtido);
        }

        [TestCase]
        [TestMethod]
        public void GetEtapaPorID()
        {
            _mockEtapa = new Mock<IEtapaRepositorio>();
            _getEtapa = new GestaoEtapa(_mockEtapa.Object);

            tbl_etapa esperado = new tbl_etapa();

            long idProcesso = 2;

            _mockEtapa.Setup(x => x.GetEtapaByID(It.IsAny<long>())).Returns(esperado);

            tbl_etapa obtido = _getEtapa.GetEtapaByID(idProcesso);
            Assert.AreEqual(esperado, obtido);
        }

        #endregion

        #region GestaoLoginFuncionario

        private GestaoLoginFuncionario _getlogin;
        private Mock<IFuncionarioRepositorio> _mock;

        [TestCase]
        [TestMethod]
        public void LoginFuncionario()
        {
            _mock = new Mock<IFuncionarioRepositorio>();
            _getlogin = new GestaoLoginFuncionario(_mock.Object);

            tbl_Funcionario esperado = new tbl_Funcionario()
            {
                IdFuncionario = 3,
                IdFuncao = 2,
                DsFuncionario = "Ralph Baitinga",
                DsSenha = "ralph#",
                DsUsuario = "ralph#",
                Dt_Alteracao = null,
                Dt_Cadastro = DateTime.Parse("2020-03-19 16:28:04.183"),
            };

            _mock.Setup(x => x.GetLoginFuncionario(It.IsAny<tbl_Funcionario>())).Returns(esperado);

            tbl_Funcionario obtido = _getlogin.GetFuncionario(esperado);
            Assert.AreEqual(esperado, obtido);
        }

        #endregion

        #region GestaoNaoConformidade

        private GestaoNaoConformidade _getNaoConf;
        private Mock<INaoConformidadeRepositorio> _mockNaoConf;

        [TestCase]
        [TestMethod]
        public void AdicionaNaoConformidade()
        {
            _mockNaoConf = new Mock<INaoConformidadeRepositorio>();
            _getNaoConf = new GestaoNaoConformidade(_mockNaoConf.Object);

            tbl_NaoConformidade ativ = new tbl_NaoConformidade();

            _mockNaoConf.Setup(x => x.AdicionaNaoConformidade(It.IsAny<tbl_NaoConformidade>()));

            _getNaoConf.AdicionaNaoConformidade(ativ);
        }

        [TestCase]
        [TestMethod]
        public void AtualizaNaoConformidade()
        {
            _mockNaoConf = new Mock<INaoConformidadeRepositorio>();
            _getNaoConf = new GestaoNaoConformidade(_mockNaoConf.Object);

            tbl_NaoConformidade ativ = new tbl_NaoConformidade();

            _mockNaoConf.Setup(x => x.AtualizaNaoConformidade(It.IsAny<tbl_NaoConformidade>()));

            _getNaoConf.AtualizaNaoConformidade(ativ);
        }

        [TestCase]
        [TestMethod]
        public void Detalhes()
        {
            _mockNaoConf = new Mock<INaoConformidadeRepositorio>();
            _getNaoConf = new GestaoNaoConformidade(_mockNaoConf.Object);

            tbl_NaoConformidade ativ = new tbl_NaoConformidade();
            long naoConf = 2;

            _mockNaoConf.Setup(x => x.Detalhes(It.IsAny<long>())).Returns(ativ);

            tbl_NaoConformidade obtido = _getNaoConf.Detalhes(naoConf);

            Assert.AreEqual(ativ, obtido);

        }


        [TestMethod]
        public void DeletaNaoConformidade()
        {
            _mockNaoConf = new Mock<INaoConformidadeRepositorio>();
            _getNaoConf = new GestaoNaoConformidade(_mockNaoConf.Object);

            long naoConformidade = 2;

            _mockNaoConf.Setup(x => x.DeletaNaoConformidade(It.IsAny<long>()));

            _getNaoConf.DeletaNaoConformidade(naoConformidade);
        }

        [TestCase]
        [TestMethod]
        public void GetNaoConformidade()
        {
            _mockNaoConf = new Mock<INaoConformidadeRepositorio>();
            _getNaoConf = new GestaoNaoConformidade(_mockNaoConf.Object);

            IList<tbl_NaoConformidade> list = new List<tbl_NaoConformidade>();

            _mockNaoConf.Setup(x => x.GetNaoConformidade());

            IEnumerable<tbl_NaoConformidade> obtido = _getNaoConf.GetNaoConformidade();

            Assert.AreEqual(list, obtido);

        }


        [TestCase]
        [TestMethod]
        public void GetNaoConformidadeRelatorio()
        {
            _mockNaoConf = new Mock<INaoConformidadeRepositorio>();
            _getNaoConf = new GestaoNaoConformidade(_mockNaoConf.Object);

            IList<NaoConformidades> list = new List<NaoConformidades>();
            RelatNaoConformidadeClass relat = new RelatNaoConformidadeClass();

            _mockNaoConf.Setup(x => x.GetNaoConformidadeRelatorio(ref relat)).Returns(list);

            IList<NaoConformidades> obtido = _getNaoConf.GetNaoConformidadeRelatorio(ref relat);

            Assert.AreEqual(list, obtido);

        }

        [TestCase]
        [TestMethod]
        public void GetNaoConformidadePorID()
        {
            _mockNaoConf = new Mock<INaoConformidadeRepositorio>();
            _getNaoConf = new GestaoNaoConformidade(_mockNaoConf.Object);

            tbl_NaoConformidade naoCon = new tbl_NaoConformidade();
            long idNaoConf = 2;

            _mockNaoConf.Setup(x => x.GetNaoConformidadePorID(It.IsAny<long>())).Returns(naoCon);

            tbl_NaoConformidade obtido = _getNaoConf.GetNaoConformidadePorID(idNaoConf);

            Assert.AreEqual(naoCon, obtido);

        }

        #endregion

        #region GestaoNormaRepositorio

        private GestaoNormaRepositorio _getnorma;
        private Mock<INormaRepositorio> _mockNorma;

        [TestMethod]
        public void GetNorma()
        {
            _mockNorma = new Mock<INormaRepositorio>();
            _getnorma = new GestaoNormaRepositorio(_mockNorma.Object);

            LinksWrapper<Content> esperado = new LinksWrapper<Content>()
            {

            };

            long normaId = 2;

            _mockNorma.Setup(x => x.GetNormaById(It.IsAny<long>())).Returns(esperado);

            LinksWrapper<Content> obtido = _getnorma.GetNormaId(normaId);
            Assert.AreEqual(esperado, obtido);
        }

        #endregion

        #region GestaoProcesso

        private GestaoProcesso _getprocesso;
        private Mock<IProcessoRepositorio> _mockProc;

        [TestMethod]
        public void GetDetalheProcesso()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            tbl_Processo esperado = new tbl_Processo()
            {
                IdProcesso = 2,
                Nome = "Pinturas",
                Dt_Alteracao = DateTime.Parse("2020-06-11 15:47:25.560"),
                Dt_Cadastro = DateTime.Parse("2020-03-19 12:00:49.027"),
            };

            long IdProcesso = 2;

            _mockProc.Setup(x => x.Detalhes(It.IsAny<long>())).Returns(esperado);

            tbl_Processo obtido = _getprocesso.GetDetalheProcesso(IdProcesso);
            Assert.AreEqual(esperado, obtido);
        }


        [TestCase]
        [TestMethod]
        public void AdicionaProcesso()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            tbl_Processo ativ = new tbl_Processo();

            _mockProc.Setup(x => x.AdicionaProcesso(It.IsAny<tbl_Processo>()));

            _getprocesso.AdicionaProcesso(ativ);
        }


        [TestCase]
        [TestMethod]
        public void AtualizaProcesso()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            tbl_Processo ativ = new tbl_Processo();

            _mockProc.Setup(x => x.AtualizaProcesso(It.IsAny<tbl_Processo>()));

            _getprocesso.AtualizaProcesso(ativ);
        }

        [TestCase]
        [TestMethod]
        public void DeletaProcesso()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            long IdProcesso = 3;

            _mockProc.Setup(x => x.DeletaProcesso(It.IsAny<long>()));

            _getprocesso.DeletaProcesso(IdProcesso);
        }


        [TestMethod]
        public void DetalhesProcesso()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            tbl_Processo esperado = new tbl_Processo()
            {
                IdProcesso = 2,
                Nome = "Pinturas",
                Dt_Alteracao = DateTime.Parse("2020-06-11 15:47:25.560"),
                Dt_Cadastro = DateTime.Parse("2020-03-19 12:00:49.027"),
            };

            long IdProcesso = 2;

            _mockProc.Setup(x => x.Detalhes(It.IsAny<long>())).Returns(esperado);

            tbl_Processo obtido = _getprocesso.Detalhes(IdProcesso);
            Assert.AreEqual(esperado, obtido);
        }


        [TestMethod]
        public void DetalhesLong()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            tbl_Processo esperado = new tbl_Processo()
            {
                IdProcesso = 2,
                Nome = "Pinturas",
                Dt_Alteracao = DateTime.Parse("2020-06-11 15:47:25.560"),
                Dt_Cadastro = DateTime.Parse("2020-03-19 12:00:49.027"),
            };

            long IdProcesso = 2;

            _mockProc.Setup(x => x.Detalhes(It.IsAny<long>())).Returns(esperado);

            tbl_Processo obtido = _getprocesso.Detalhes(IdProcesso);
            Assert.AreEqual(esperado, obtido);
        }

        [TestMethod]
        public void GetProcessos()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            IEnumerable<tbl_Processo> list = new List<tbl_Processo>();

            _mockProc.Setup(x => x.GetProcessos()).Returns(list);

            IEnumerable<tbl_Processo> obtido = _getprocesso.GetProcessos();
            Assert.AreEqual(list, obtido);
        }

        [TestMethod]
        public void GetProcessoRelatorio()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            IList<RelatorioProcesso> list = new List<RelatorioProcesso>();
            RelatorioClass relatCl = new RelatorioClass();

            _mockProc.Setup(x => x.GetProcessoRelatorio(ref relatCl)).Returns(list);

            IList<RelatorioProcesso> obtido = _getprocesso.GetProcessoRelatorio(ref relatCl);
            Assert.AreEqual(list, obtido);
        }

        [TestMethod]
        public void GetProcessoPorID()
        {
            _mockProc = new Mock<IProcessoRepositorio>();
            _getprocesso = new GestaoProcesso(_mockProc.Object);

            tbl_Processo tbl = new tbl_Processo();
            long idProcesso = 2;

            _mockProc.Setup(x => x.GetProcessoPorID(It.IsAny<long>())).Returns(tbl);

            tbl_Processo obtido = _getprocesso.GetProcessoPorID(idProcesso);
            Assert.AreEqual(tbl, obtido);
        }

        #endregion

    }
}
