using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Presentation.Controllers
{
    [Controller]
    public class BaseController : Controller
    {
        #region Fields

        protected readonly IMediator _Mediator;
        #endregion
        #region Constructor
        public BaseController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        #endregion

    }
}
