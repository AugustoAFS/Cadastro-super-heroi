using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationService.Dtos.Requests.Heroi
{
    public class CreateHeroiRequest
    {
        [Required(ErrorMessage = "O nome real é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome de herói é obrigatório")]
        public string NomeHeroi { get; set; }

        public DateTime DataNascimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }

        public List<int> SuperpoderesIds { get; set; } = new List<int>();
    }
}