using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using ClassLibrary1.Model;



namespace postfixCal
{
    public partial class Form1 : Form 
    {
        /// <summary>
        /// post api 取得計算機邏輯
        /// </summary>
        private static readonly string UrlCal = "https://localhost:5001/api/Calculate/PostAll";
      
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// api 連線設定
        /// </summary>
        private static readonly HttpClient client;
        static Form1()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// 點擊對應按鈕textbox顯示相應數值
        /// </summary>
        /// <param name="sender">引發事件的物件</param>
        /// <param name="e">事件的額外細項</param>
        private async void ButtonClick(object sender, EventArgs e)
        {            
            Button btn = sender as Button;
             
            var cal = new Calculate()
            {
                Button = btn.Text,
                Label = lblText.Text,
                TextboxFirst = textBox3.Text,
                TextboxResult = textBox2.Text,
            };

            string json = JsonConvert.SerializeObject(cal);

            HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json"); // 定義json內容

            HttpResponseMessage response = await client.PostAsync(UrlCal, contentPost);
            response.EnsureSuccessStatusCode();

            var ans = response.Content.ReadAsStringAsync().Result;
     
            var result = JsonConvert.DeserializeObject<Calculate>(ans);

            // 控制向改變狀態
            textBox2.Text = result.TextboxResult;
            textBox3.Text = result.TextboxFirst;
            lblText.Text = result.Label;
            btn.Text = result.Button;
        }
    }
}