using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediator.User
{
    public class AddUserValidator : AbstractValidator<AddUserNotification>
    {
        public AddUserValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.Comment).NotEmpty().WithMessage("Каммент пустой!");
        }
    }
}
