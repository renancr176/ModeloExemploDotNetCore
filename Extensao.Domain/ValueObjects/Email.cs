using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using FluentValidator;
using FluentValidator.Validation;

namespace Extensao.Domain.ValueObjects
{
    public class Email: Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            Validar();
        }

        private void Validar()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Endereco, "Email", "O E-mail é inválido")
                .HasMinLen(Endereco, 5, "Email", "O Email deve conter pelo menos 5 caracteres")
                .HasMaxLen(Endereco, 50, "Email", "O Email deve conter no máximo 50 caracteres")
            );
        }

        public string Endereco { get; private set; }

        public override string ToString()
        {
            return Endereco;
        }
    }
}
