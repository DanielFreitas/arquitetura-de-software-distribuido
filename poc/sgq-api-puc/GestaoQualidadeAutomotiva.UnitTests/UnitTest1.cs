using GestaoQualidadeAutomotiva.API.PUC.Domain.Repositories;
using GestaoQualidadeAutomotiva.API.PUC.Domain.Models;
using GestaoQualidadeAutomotiva.API.PUC.Services;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Assert = NUnit.Framework.Assert;
using GestaoQualidadeAutomotiva.API.PUC.Domain.Services;
using sgq_api_puc.Persistence.Repositories;
using System.Linq;

namespace GestaoQualidadeAutomotiva.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        private readonly Mock<INormaService> ns;

        public UnitTest1()
        {
            this.ns = new Mock<INormaService>();
        }

        #region NormaService

        [Fact]
        public void AddNormaTeste()
        {
            Norma norma = new Norma
            {
                NormaId = 1,
                Status = "ok",
                Titulo = "Norma Ajuste Bateria",
                DataPublicacao = DateTime.Now,
                Objetivo = "Corrigir o ajuste de bateria",
                Organismo = "TECMINAS - Engenharia e Inspeção Veicular",
                UrlDocumento = "norma automotiva regulamentada",
                Comite = "Norma ajustada"
            };

            var response = ns.Setup(x => x.AddNorma(It.IsAny<Norma>()));
        }

        [Fact]
        public void GetNormaId()
        {
            Norma norma = new Norma
            {
                NormaId = 1,
                Status = "ok",
                Titulo = "Norma Ajuste Bateria",
                DataPublicacao = DateTime.Now,
                Objetivo = "Corrigir o ajuste de bateria",
                Organismo = "TECMINAS - Engenharia e Inspeção Veicular",
                UrlDocumento = "norma automotiva regulamentada",
                Comite = "Norma ajustada"
            };
            Task<Norma> i = Task.FromResult(norma);
            var response = ns.Setup(x => x.GetNorma(It.IsAny<int>())).Returns(i);

        }

        [Fact]
        public void GetListNormaTeste()
        {
            IEnumerable<Norma> ls = new List<Norma> { new Norma() {NormaId = 1 } };
            Task<IEnumerable<Norma>> listTeste = Task.FromResult(ls);
            var response = ns.Setup(x => x.GetListNorma()).Returns(listTeste);
        }


        [Fact]
        public void UpdateNormaTeste()
        {
            Norma norma = new Norma
            {
                NormaId = 1,
                Status = "ok",
                Titulo = "Norma Ajuste Bateria",
                DataPublicacao = DateTime.Now,
                Objetivo = "Corrigir o ajuste de bateria",
                Organismo = "TECMINAS - Engenharia e Inspeção Veicular",
                UrlDocumento = "norma automotiva regulamentada",
                Comite = "Norma ajustada"
            };

            ns.Setup(x => x.UpdateNorma(It.IsAny<Norma>()));
        }

        [Fact]
        public void DeleteNormaTeste()
        {
            Norma norma = new Norma
            {
                NormaId = 1,
                Status = "ok",
                Titulo = "Norma Ajuste Bateria",
                DataPublicacao = DateTime.Now,
                Objetivo = "Corrigir o ajuste de bateria",
                Organismo = "TECMINAS - Engenharia e Inspeção Veicular",
                UrlDocumento = "norma automotiva regulamentada",
                Comite = "Norma ajustada"
            };

            ns.Setup(x => x.DeleteNorma(It.IsAny<Norma>()));
        }

        #endregion

    }
}
