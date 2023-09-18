using FluentValidation;

namespace AgreementManagement.Validation.CustomErrorConfiguration
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string errorMessage)
        {
            return rule.WithMessage(errorMessage);
        }
    }
}
