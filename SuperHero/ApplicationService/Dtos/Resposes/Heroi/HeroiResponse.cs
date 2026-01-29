using ApplicationService.Dtos.Resposes.Superpoder;
using System.Collections.Generic;
using System;

namespace ApplicationService.Dtos.Resposes.Heroi
{
    public class HeroiResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime? DataNascimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }

        public List<SuperpoderResponse> Superpoderes { get; set; } = new List<SuperpoderResponse>();
    }
}

