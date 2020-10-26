using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.App.ViewModels
{
    public class ColaboradorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 7)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Senha { get; set; }

        /*EF Relations */

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Perfil")]
        public int PerfilId { get; set; }

        [NotMapped]
        public PerfilViewModel Perfil { get; set; }

        [NotMapped]
        public IEnumerable<PerfilViewModel> Perfis { get; set; }
        [NotMapped]
        public IEnumerable<HistoricoViewModel> Historicos { get; set; }
    }
}
