using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator.Validation;

namespace Extensao.Shared.Commands
{
    public interface ICommand : IValidatable
    {
        bool Valid();
    }

}
