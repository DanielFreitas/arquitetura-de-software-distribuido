using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoQualidadeAutomotiva.API.PUC.Lib
{
    public class LinkInfo
    {
        [Key]
        internal int LinkInfoId { get; private set; }
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }

        public LinkInfo(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
