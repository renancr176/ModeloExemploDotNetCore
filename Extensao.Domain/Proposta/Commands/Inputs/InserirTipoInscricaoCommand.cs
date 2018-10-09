using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;
using Extensao.Shared.Commands;

namespace Extensao.Domain.Proposta.Commands.Inputs
{
    public class InserirTipoInscricaoCommand : Notifiable, ICommand
    {
        #region TipoInscricao

        public Guid? Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public string AliasUsuario { get; set; }


        public void Validate()
        {
            
        }

        #endregion

        bool ICommand.Valid()
        {
            throw new NotImplementedException();
        }

    }
}
