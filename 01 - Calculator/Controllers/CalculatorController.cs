using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapi_dotnet_core_doc_swagger_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        
        [HttpGet("{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber,string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid value");
        }
        private decimal ConvertToDecimal(string number) {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue)){
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string number)
        {    
            double numberConverted ;       
            bool isNumber = double.TryParse(number, 
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo , out numberConverted);
            return isNumber;
        }
    }
}
