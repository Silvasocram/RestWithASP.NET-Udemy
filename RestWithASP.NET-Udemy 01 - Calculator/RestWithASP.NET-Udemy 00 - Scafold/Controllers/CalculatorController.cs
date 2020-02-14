using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASP.NET_Udemy_00___Scafold.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values/5/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(result);
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, /*System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo,*/ out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string number)
        {
            decimal result;

            return decimal.TryParse(number, /*System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo,*/ out result);
        }
    }
}
