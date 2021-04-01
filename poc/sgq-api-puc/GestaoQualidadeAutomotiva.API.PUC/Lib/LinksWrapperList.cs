using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace GestaoQualidadeAutomotiva.API.PUC.Lib
{
    public class LinksWrapper<T> where T : class
    {
        public T Content { get; set; }
        public List<LinkInfo> Links { get; set; }
    }
}
