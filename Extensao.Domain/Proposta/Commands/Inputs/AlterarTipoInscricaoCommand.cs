using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;
using Extensao.Shared.Commands;

namespace Extensao.Domain.Proposta.Commands.Inputs
{
    public class AlterarTipoInscricaoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public string AliasUsuario { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }

        bool ICommand.Valid()
        {
            throw new NotImplementedException();
        }
    }
}
