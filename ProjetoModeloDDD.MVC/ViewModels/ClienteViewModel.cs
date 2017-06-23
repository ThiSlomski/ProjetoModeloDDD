using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha campo nome")]
        [MaxLength(150, ErrorMessage = "Nome maximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Nome mínimo 150 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha campo E-mail")]
        [MaxLength(150, ErrorMessage = "E-mail maximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "E-mail mínimo 150 caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha campo Email")]
        [MaxLength(250, ErrorMessage = "Email maximo 250 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Description = "E-mail")]
        public string Email { get; set; }
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
          public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }


    }
}