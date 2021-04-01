using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebMvcSgq.Models.Classe;
using WebMvcSgq.Models.Interface;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using SecureAPIClient;
using System.Data.Entity;
using WebMvcSgq.Utils;

namespace WebMvcSgq.Models
{
    public class NormaRepositorio : INormaRepositorio
    {
       readonly db_sgqEntities db = new db_sgqEntities(AppSettings.GetConnectionStringByName("SqlConnectionString"));

        public IEnumerable<LinksWrapper<Content>> GetAll()
        {            
            string responseBody = RunAsync("api/Norma").GetAwaiter().GetResult();

            if (!String.IsNullOrEmpty(responseBody))
            {
                return JsonConvert.DeserializeObject<IEnumerable<LinksWrapper<Content>>>(responseBody);
            }

            return null;
        }
         
        private static async Task<dynamic> RunAsync(string uri)
        {
            String responseBody = "";

            AuthConfig config = AuthConfig.ReadFromXML();                             

            IConfidentialClientApplication app;

            app = ConfidentialClientApplicationBuilder.Create(config.ClientId)
                .WithClientSecret(config.ClientSecret)
                .WithAuthority(new Uri(config.Authority))
                .Build();

            string[] ResourceIds = new string[] { config.ResourceID };

            AuthenticationResult result = null;
            try
            {
                result = await app.AcquireTokenForClient(ResourceIds).ExecuteAsync().ConfigureAwait(false);
            }
            catch (MsalClientException ex)
            {
            }

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                var httpClient = new HttpClient();
                var defaultRequestHeaders = httpClient.DefaultRequestHeaders;

                if (defaultRequestHeaders.Accept == null ||
                   !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new
                      MediaTypeWithQualityHeaderValue("application/json"));
                }
                defaultRequestHeaders.Authorization =
                  new AuthenticationHeaderValue("Bearer", result.AccessToken);

                //chamando a api pela url
                HttpResponseMessage response = await httpClient.GetAsync(config.BaseAddress + uri);               

                //se retornar com sucesso busca os dados
                if (response.IsSuccessStatusCode)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                }
            }

            return responseBody;
        }

        public LinksWrapper<Content> GetNormaById(Int64 normaId)
        {
            string responseBody = RunAsync("api/Norma/" + normaId.ToString()).GetAwaiter().GetResult();

            if (!String.IsNullOrEmpty(responseBody))
            {
                return JsonConvert.DeserializeObject<LinksWrapper<Content>>(responseBody);
            }

            return null;
        }

        void INormaRepositorio.Atualiza(ICollection<Tbl_NaoConformidade_x_Norma> naoConformidade_x_Norma)
        {
            try
            {
                var item = naoConformidade_x_Norma.FirstOrDefault();
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
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

        void INormaRepositorio.DeleteNaoConformidade_x_Norma(ICollection<Tbl_NaoConformidade_x_Norma> naoConformidade_x_Norma)
        {
            try
            {
                var item = naoConformidade_x_Norma.FirstOrDefault();
                db.Entry(item).State = EntityState.Modified;
                db.Tbl_NaoConformidade_x_Norma.Remove(item);
                db.SaveChanges();
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

        void INormaRepositorio.AdicionaNaoConformidade_x_Norma(ICollection<Tbl_NaoConformidade_x_Norma> naoConformidade_x_Norma)
        {
            try
            {
                var item = naoConformidade_x_Norma.FirstOrDefault();
                db.Entry(item).State = EntityState.Modified;
                db.Tbl_NaoConformidade_x_Norma.Add(item);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((db == null))
                    db.Dispose();
            }
        }

    }
}