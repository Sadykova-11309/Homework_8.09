using FluentValidation;
using Homework_8._09.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.Service.Validators
{
	public class CreateRequestValidator : AbstractValidator<CreateRequest>
	{
		public CreateRequestValidator()
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

			RuleFor(x => x.Sex)
				.Must(x => x == 0 || x == 1)
				.WithMessage("Пол должен быть 0 (мужской) или 1 (женский)");

			RuleFor(x => x.RoleId)
				.NotNull().WithMessage("Роль обязательна")
				.InclusiveBetween(1,2).WithMessage("Роль должена быть 1 (Админ) или 2 (Пользователь)");

			RuleFor(x => x.PositionId)
				.NotNull().WithMessage("Должность обязательна")
				.InclusiveBetween(1, 5).WithMessage("Роль должена быть 1 (Backend Developer), 2 (Frontend Developer), 3 (QA), 4 (SEO) или 5 (Team Lead)");
		}
	}
}
