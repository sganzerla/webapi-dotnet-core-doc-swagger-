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
        
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber,string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid value");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Subtraction(string firstNumber,string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid value");
        }
         [HttpGet("division/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Division(string firstNumber,string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid value");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Multiplication(string firstNumber,string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid value");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Mean(string firstNumber,string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var result = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
                return Ok(result.ToString());
            }
            return BadRequest("Invalid value");
        }

        
        [HttpGet("square-root/{number}")]
        public ActionResult<string> SquareRoot(string number )
        {
            if(IsNumeric(number) ){
                var result = Math.Sqrt((double)ConvertToDecimal(number)) ;
                return Ok(result.ToString());
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
            //GLobalization mantém formato númerico
            return isNumber;
        }
    }
}
