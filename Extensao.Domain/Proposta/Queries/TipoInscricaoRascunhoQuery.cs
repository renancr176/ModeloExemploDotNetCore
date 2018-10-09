using System;

namespace Extensao.Domain.Proposta.Queries
{
    public class TipoInscricaoRascunhoQuery
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public string AliasUsuario { get; set; }
    }
}
