using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha campo nome")]
        [MaxLength(150, ErrorMessage = "Nome maximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Nome mínimo 150 caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999")]
        [Required(ErrorMessage = "Preencha campo valor")]
        public decimal Valor { get; set; }

        [Display(Description = "Disponível")]
        public bool Disponivel { get; set; }

        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }


    }
}