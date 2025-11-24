using FluentValidation;
using Homework_8._09.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.Service.Validators
{
	public class LoginRequestValidator : AbstractValidator<LoginRequest>
	{
		public LoginRequestValidator()
		{
			RuleFor(x => x.Login)
				.NotEmpty().WithMessage("Login обязателен")
				.MaximumLength(256);

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Пароль обязателен")
				.MinimumLength(8).WithMessage("Пароль должен быть не менее 8 символов")
				.Matches(@"[A-Z]").WithMessage("Пароль должен содержать хотя бы одну заглавную букву")
				.Matches(@"[a-z]").WithMessage("Пароль должен содержать хотя бы одну строчную букву")
				.Matches(@"[0-9]").WithMessage("Пароль должен содержать хотя бы одну цифру")
				.Matches(@"[^a-zA-Z0-9]").WithMessage("Пароль должен содержать хотя бы один спецсимвол");
		}
	}
}
