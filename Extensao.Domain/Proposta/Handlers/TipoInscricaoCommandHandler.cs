using System;
using Extensao.Domain.Proposta.Commands.Inputs;
using Extensao.Domain.Proposta.Repositories;
using Extensao.Shared.Commands;
using FluentValidator;

namespace Extensao.Domain.Proposta.Handlers
{
    public class TipoInscricaoCommandHandler : Notifiable,
        ICommandHandler<InserirTipoInscricaoCommand>,
        ICommandHandler<AlterarTipoInscricaoCommand>,
        ICommandHandler<RascunhoTipoInscricaoCommand>
    {
        private readonly ITipoInscricaoRepository _tipoInscricaoRepository;

        public TipoInscricaoCommandHandler(ITipoInscricaoRepository tipoInscricaoRepository)
        {
            _tipoInscricaoRepository = tipoInscricaoRepository;
        }

        public ICommandResult Handle(InserirTipoInscricaoCommand command)
        {
            if (_tipoInscricaoRepository.DescricaoExists(command.Descricao))
            {
                AddNotification("Descrição", "Já existe um tipo de inscrição com esta descrição.");
                return null;
            }

            var tipoInscricao = new TipoInscricao(command.Descricao, command.Status, command.AliasUsuario);

            //AddNotification(tipoInscricao.Notifications);

            if (!tipoInscricao.Valid)
            {
                return null;
            }

            return _tipoInscricaoRepository.CadastrarTipoInscricao(tipoInscricao);
        }

        public ICommandResult Handle(AlterarTipoInscricaoCommand command)
        {
            if (_tipoInscricaoRepository.ObtemTipoInscricaoPorId(command.Id) == null)
            {
                AddNotification("Tipo Inscrição", "Tipo de inscrição inexistente.");
                return null;
            }

            var tipoInscricao = TipoInscricao.TipoInscricaoFactory.TipoInscricaoFull(command.Id, command.Descricao, command.Status, command.AliasUsuario);

            //AddNotification(tipoInscricao.Notifications);

            if (!tipoInscricao.Valid)
            {
                return null;
            }

            return _tipoInscricaoRepository.AlterarTipoInscricao(tipoInscricao);
        }

        public ICommandResult Handle(RascunhoTipoInscricaoCommand command)
        {
            var tipoInscricao = TipoInscricao.TipoInscricaoFactory.TipoInscricaoFull(command.Id, command.Descricao,
                command.Status, command.AliasUsuario);
                    
            return _tipoInscricaoRepository.RascunhoTipoInscricao(tipoInscricao);
        }
    }
}
