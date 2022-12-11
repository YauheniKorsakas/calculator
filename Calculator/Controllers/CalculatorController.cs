using Calculator.Web.Operations;
using Calculator.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Calculator.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly Lazy<IPlusOperation> plusOperation;
        private readonly Lazy<IGetAllCalculatorOperationsOperation> getAllOperationsOperation;
        private readonly Lazy<IGetCalculatorOperationOperation> getCalculatorOperationOperation;

        public CalculatorController(
            Lazy<IPlusOperation> plusOperation,
            Lazy<IGetAllCalculatorOperationsOperation> getAllOperationsOperation,
            Lazy<IGetCalculatorOperationOperation> getCalculatorOperationOperation
        ) {
            this.plusOperation = plusOperation ?? throw new ArgumentNullException(nameof(plusOperation));
            this.getAllOperationsOperation = getAllOperationsOperation ?? throw new ArgumentNullException(nameof(getAllOperationsOperation));
            this.getCalculatorOperationOperation = getCalculatorOperationOperation ?? throw new ArgumentNullException(nameof(getCalculatorOperationOperation));
        }

        [HttpPost("operations/plus")]
        public IActionResult Plus(double first, double second) {
            plusOperation.Value.Execute(first, second);

            return Ok();
        }

        [HttpGet("operations")]
        public IReadOnlyCollection<CalculatorOperationViewModel> Get() {
            var result = getAllOperationsOperation.Value.Execute();

            return result;
        }

        [HttpGet("operations/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculatorOperationViewModel))]
        public ActionResult<CalculatorOperationViewModel> Get(string id) {
            var operation = getCalculatorOperationOperation.Value.Execute(id);
            if (operation is null) {
                return NotFound("There is no such operation.");
            };

            return Ok(operation);
        }
    }
}
