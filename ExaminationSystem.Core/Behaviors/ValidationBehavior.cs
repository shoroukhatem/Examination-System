using FluentValidation;
using MediatR;

namespace ExaminationSystem.Core.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        #region Fields
        private readonly IEnumerable<IValidator<TRequest>> _Validators;

        #endregion
        #region Constructor
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _Validators = validators;
        }
        #endregion
        #region Actions
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_Validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_Validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                {
                    var message = failures.Select(x => x.PropertyName + ": " + x.ErrorMessage).FirstOrDefault();
                    throw new ValidationException(message);

                }
            }
            return await next();
        }
        #endregion
    }
}
