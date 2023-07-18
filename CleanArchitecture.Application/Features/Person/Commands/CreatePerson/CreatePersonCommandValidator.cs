﻿using FluentValidation;

namespace CleanArchitecture.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommandRequest>
    {
        //TODO: Revisar validacion
        public CreatePersonCommandValidator()
        {
            RuleFor(p => p.Dni)
                .NotEmpty().WithMessage("{Dni} no puede estar en blanco")
                .NotNull().WithMessage("{Dni} no puede ser vacio")
                .Length(9).WithMessage("{Dni} deben ser 9 caracteres")
                .Must(ValidateDni).WithMessage("{Dni} no es válido");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{Password} no puede estar en blanco")
                .NotNull().WithMessage("{Dni} no puede ser vacio")
                .MaximumLength(10).WithMessage("{Password} deben ser máximo 10 caracteres")
                .MinimumLength(10).WithMessage("{Password} deben ser mínimo 8 caracteres");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{Email} no puede estar en blanco")
                .NotNull()
                .EmailAddress().WithMessage("{Email} deben ser un correo electrónico válido");
        }

        private bool ValidateDni(string value)
        {
            var numsDni = value.Substring(0, 8);
            var letterDni = value.Substring(8, 1);
            var validLetter = "TRWAGMYFPDXBNJZSQVHLCKE";

            if (int.TryParse(numsDni, out int dni))
            {
                int indiceLetra = dni % 23;
                char letraEsperada = validLetter[indiceLetra];

                return letterDni.Equals(letraEsperada.ToString(), StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}
