using System;
using System.Collections.Generic;
using System.Text;

namespace Extensao.Domain.Proposta.Queries
{
    public class TipoAtividadeQuery
    {
        public Guid IdTipoAtividade { get; set; }
        public String DescricaoTipoAtividade { get; set; }
        public bool Ativo { get; set; }
        public int Ordem { get; set; }
        public DateTime Criado { get; set; }
        public string CriadoPor { get; set; }
        public DateTime Alterado { get; set; }
        public string AlteradoPor { get; set; }
    }
}
