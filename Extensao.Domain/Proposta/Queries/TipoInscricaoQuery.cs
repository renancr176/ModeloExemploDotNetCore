using System;
using System.Collections.Generic;
using System.Text;

namespace Extensao.Domain.Proposta.Queries
{
   public class TipoInscricaoQuery
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public string UsuarioCriacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
