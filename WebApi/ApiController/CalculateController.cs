using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text;
using WebApi.InterFace;
using ClassLibrary1.Model;

namespace WebApi.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        /// <summary>
        /// logger提示欄位
        /// </summary>
        private readonly ILogger<CalculateController> _logger;

        /// <summary>
        /// 介面欄位
        /// </summary>
        private readonly IFactory _all;

        /// <summary>
        /// 建立相依
        /// </summary>
        /// <param name="dataService">抽象servie邏輯</param>
        /// <param name="logger">檢查api輸入正確性</param>
        public CalculateController(IFactory all, ILogger<CalculateController> logger)
        {
            this._all = all;
            this._logger = logger;
        }

        /// <summary>
        /// PostApi 計算邏輯
        /// </summary>
        /// <param name="cal">控制項物件</param>
        /// <returns>控制項物件</returns>
        [HttpPost("PostAll")]
        public IButton PostCal([FromBody] Calculate cal)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"CalculateController的PostSquare方法被呼叫,傳入參數為{cal}");

            _logger.LogWarning(2001, inform.ToString());

            var result = _all.UseButton(cal);

            return result;
        }
    }
}
