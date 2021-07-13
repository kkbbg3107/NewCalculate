using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text;
using WebApi.Models;
using WebApi.InterFace;


namespace WebApi.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly IPostText _text;
        private readonly IPostClear _clear;
        private readonly IDataService _dataService;
        private readonly ISquareRoot _square;
        private readonly INegative _negative;
        private readonly ILogger<CalculateController> _logger;


        /// <summary>
        /// 建立相依
        /// </summary>
        /// <param name="dataService">抽象servie邏輯</param>
        /// <param name="logger">檢查api輸入正確性</param>
        public CalculateController(IPostText text, IPostClear clear, IDataService dataService, ISquareRoot square, INegative negative, ILogger<CalculateController> logger)
        {
            this._text = text;
            this._clear = clear;
            this._dataService = dataService;
            this._square = square;
            this._negative = negative;
            this._logger = logger;
        }
        // POST api/<CalculateController>
        [HttpPost("PostResult")]
        public NumGroup.NumSingleResult PostResult([FromBody] string data) 
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"CalculateController的PostResult方法被呼叫,傳入的參數為{data}");

            this._logger.LogWarning(2001, inform.ToString());

            var result =  this._dataService.PostNumber(data);
            return result;
        }

        [HttpPost("PostText")]
        public async Task<Num> PostResultNum([FromBody] string data)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"CalculateController的PostResultNum方法被呼叫,傳入的參數為{data}");

            this._logger.LogWarning(2001, inform.ToString());

            var result = await _text.PostText(data);
            return result;
        }

        [HttpPost("PostClear")]
        public async Task<Num> PostBlank([FromBody]string text)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"CalculateController的PostBlank方法被呼叫,傳入參數為{text}");

            _logger.LogWarning(2001, inform.ToString());

            var result = await _clear.PostBlank(text);
            return result;
        }

        [HttpPost("PostSquare")]
        public async Task<Num> PostSquare([FromBody]string text)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"CalculateController的PostSquare方法被呼叫,傳入參數為{text}");

            _logger.LogWarning(2001, inform.ToString());

            var result = await _square.PostSquare(text);
            return result;
        }

        [HttpPost("PostNegative")]
        public async Task<Num> PostNegative([FromBody] string text)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"CalculateController的PostSquare方法被呼叫,傳入參數為{text}");

            _logger.LogWarning(2001, inform.ToString());

            var result = await _negative.PostNegative(text);
            return result;
        }
    }
}
