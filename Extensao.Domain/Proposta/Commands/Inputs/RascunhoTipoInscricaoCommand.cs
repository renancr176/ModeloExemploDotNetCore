using System;
using FluentValidator;
using Extensao.Shared.Commands;

namespace Extensao.Domain.Proposta.Commands.Inputs
{
    public class RascunhoTipoInscricaoCommand : Notifiable, ICommand
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; }
        public bool? Status { get; set; }
        public string AliasUsuario { get; set; }

        public void Validate()
        {
        }

        bool ICommand.Valid()
        {
            throw new System.NotImplementedException();
        }
    }
}
