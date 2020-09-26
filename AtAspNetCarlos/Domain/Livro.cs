using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Ano { get; set; }

        [JsonIgnore]
        public virtual Autor Autor { get; set; }
    }

    public class LivroResponse
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Ano { get; set; }

        public virtual Autor Autor { get; set; }
    }
}
