using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;

namespace Extensao.Domain.ValueObjects
{
   public class ArquivoAnexo : Notifiable
    {
        public ArquivoAnexo(
           string anexoMineType,
           string arquivo)
        {
            AnexoMineType = anexoMineType;
            Arquivo = arquivo;           

            Validar();
        }

        private void Validar()
        {
            try
            {
                AddNotifications(new ValidationContract()
                    .Requires()
                    .IsNullOrEmpty(AnexoMineType, "ArquivoMimeType", "O tipo do arquivo é obrigatório")
                    .IsNullOrEmpty(Arquivo, "Arquivo", "O arquivo é obrigatório")
                );

                if (IsValid)
                    ValidarTamanho();
            }
            catch (Exception e)
            {
                string erro = e.Message;
            }
        }

        private void ValidarTamanho()
        {
            AddNotifications(new ValidationContract()
                    .Requires()
                .HasMinLen(AnexoMineType, 2, "ArquivoMimeType", "O tipo do arquivo deve conter pelo menos 2 caracteres")
                .HasMaxLen(AnexoMineType, 300, "ArquivoMimeType", "O tipo do arquivo deve conter no máximo 300 caracteres")
                .HasMinLen(Arquivo, 3, "Arquivo", "O arquivo deve conter pelo menos 3 caracteres")
                //.HasMinLen(Descricao, 2, "Descricao", "A descrição do arquivo deve conter pelo menos 2 caracteres")
                //.HasMaxLen(Descricao, 200, "Descricao", "A descrição do arquivo deve conter no máximo 200 caracteres")

                );
        }

        public string AnexoMineType { get; private set; }

        public string Arquivo { get; private set; }        
        public bool IsValid { get; private set; }

        //public override string ToString()
        //{
        //    return $"{Descricao}";
        //}
    }
}
