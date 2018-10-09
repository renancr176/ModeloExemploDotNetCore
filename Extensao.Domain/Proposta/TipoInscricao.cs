using System;
using FluentValidator.Validation;
using Extensao.Shared.Entities;

namespace Extensao.Domain.Proposta
{
    public class TipoInscricao :Entity
    {
        public TipoInscricao(
            string descricao,
            bool status,
            string aliasUsuario
            )
        {
            Descricao = descricao;
            Status = status;
            AliasUsuario = aliasUsuario;

            Validar();
        }

        public TipoInscricao()
        {
        }

       
        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public string AliasUsuario { get; private set; }

        private void Validar()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Descricao, 3, "Descricao", "A Descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Descricao, 300, "Descricao", "A Descrição deve conter no máximo 300 caracteres")
                .IsNotNullOrEmpty(AliasUsuario, "Usuário", "Usuário não identificado ou inválido.")
            );
        }

        public static class TipoInscricaoFactory
        {
            public static TipoInscricao TipoInscricaoFull(Guid? id, string descricao, bool? status, string aliasUsuario)
            {
                var tipoInscricao = new TipoInscricao()
                {
                    Descricao = descricao,
                    AliasUsuario = aliasUsuario
                };

                if (id.HasValue)
                    tipoInscricao.Id = id.Value;

                if (status.HasValue)
                    tipoInscricao.Status = status.Value;
 
                return tipoInscricao;
            }
        }
    }
    
}
