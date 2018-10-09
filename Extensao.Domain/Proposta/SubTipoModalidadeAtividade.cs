using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentValidator.Validation;
using Extensao.Shared.Entities;

namespace Extensao.Domain.Proposta
{
    public class SubTipoModalidadeAtividade : Entity
    {
        public SubTipoModalidadeAtividade(
           string descricao,
           bool status,
           DateTime dataAlteracao,
           string usuarioCriacao,
           DateTime dataCriacao,
           string usuarioAlteracao,
           string complemento
           )
        {

            Descricao = descricao;
            Status = status;
            DataAlteracao = dataAlteracao;
            UsuarioCriacao = usuarioCriacao;
            DataCriacao = dataCriacao;
            UsuarioAlteracao = usuarioAlteracao;
            Complemento = complemento;
            Validar();
        }


        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public string UsuarioCriacao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public string UsuarioAlteracao { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public string Complemento { get; private set; }


        private void Validar()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Descricao, 3, "Descricao", "A Descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Descricao, 100, "Descricao", "A Descrição deve conter no máximo 100 caracteres")
           );
        }

    }
}
