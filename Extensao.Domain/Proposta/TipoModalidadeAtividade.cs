using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentValidator.Validation;
using Extensao.Shared.Entities;


namespace Extensao.Domain.Proposta
{
   public class TipoModalidadeAtividade:Entity
    {
        public TipoModalidadeAtividade(
            string descricao,
            bool status,
            string usuarioCriacao,
            DateTime dataCriacao,
            string usuarioAlteracao,
            DateTime dataAlteracao,
            int sequencia
            )
        {
            Descricao = descricao;
            Status = status;
            UsuarioCriacao = usuarioAlteracao;
            DataCriacao = dataCriacao;
            UsuarioAlteracao = usuarioAlteracao;
            DataAlteracao = dataAlteracao;
            Sequencia = sequencia;
            Validar();
        }


        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public string UsuarioCriacao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public string UsuarioAlteracao { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public int Sequencia { get; private set; }


        private void Validar()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Descricao, 3, "Descricao", "A Descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Descricao, 300, "Descricao", "A Descrição deve conter no máximo 300 caracteres")
           );
        }
    }
}
