using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace DevFreela.Application.Vallidators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("E-mail não válido!");

            RuleFor(p => p.Password)
            .Must(ValidPassword)
            .WithMessage("Senha deve ter pelo menos 8 caracteres, um número, uma letra maiúscula e uma minúscula");

            RuleFor(p => p.FullName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome invalido");
        }

        public bool ValidPassword(string password){
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }
            
    }
}