using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Domain.ValueObjects;
using Extensao.Shared.Entities;



namespace Extensao.Domain.Proposta
{
   public class Anexos : Entity
    {
        public Anexos(ArquivoAnexo arquivo)
        {
            Arquivo = arquivo;

        }

        public ArquivoAnexo Arquivo { get; private set; }
    }
}
