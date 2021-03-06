﻿using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Shared.Commands;

namespace Extensao.Domain.Proposta.Commands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
