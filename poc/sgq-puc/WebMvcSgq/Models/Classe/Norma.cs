using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebMvcSgq.Models.Classe
{
    public partial class LinksWrapper<T>
    {
        [JsonProperty("Content")]
        public T Content { get; set; }

        [JsonProperty("Links")]
        public List<LinkInfo> Links { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("NormaId")]
        public long NormaId { get; set; }

        [JsonProperty("Titulo")]
        public string Titulo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [JsonProperty("DataPublicacao")]
        public DateTimeOffset DataPublicacao { get; set; }

        [JsonProperty("Comite")]
        public string Comite { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Organismo")]
        public string Organismo { get; set; }

        [JsonProperty("Objetivo")]
        public string Objetivo { get; set; }

        [JsonProperty("UrlDocumento")]
        public string UrlDocumento { get; set; }
    }

    public partial class LinkInfo
    {
        [JsonProperty("Href")]
        public Uri Href { get; set; }

        [JsonProperty("Rel")]
        public string Rel { get; set; }

        [JsonProperty("Method")]
        public string Method { get; set; }
    }
}
