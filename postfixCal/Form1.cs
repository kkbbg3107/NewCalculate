using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using postfixCal.Models;
using System.Web;

namespace postfixCal
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// WebApi地址
        /// </summary>
        private static readonly string UrlCal = "https://localhost:5001/api/Calculate/PostResult";

        /// <summary>
        /// 數字0-9 運算子呼叫
        /// </summary>
        private static readonly string UrlNum = "https://localhost:5001/api/Calculate/PostText";

        /// <summary>
        /// C的呼叫 清空TEXTBOX
        /// </summary>
        private static readonly string UrlClear = "https://localhost:5001/api/Calculate/PostClear";
        
        /// <summary>
        /// 開根號
        /// </summary>
        private static readonly string UrlSquare = "https://localhost:5001/api/Calculate/PostSquare";

        /// <summary>
        /// 變號
        /// </summary>
        private static readonly string UrlNegative = "https://localhost:5001/api/Calculate/PostNegative";

        public Form1()
        {
            this.InitializeComponent();
        }

        private static HttpClient client;
        static Form1()
        {
            client = new HttpClient();
        }

        bool isOperationPerformed = false;

        /// <summary>
        /// 點擊對應按鈕textbox顯示v相應數值
        /// </summary>
        /// <param name="sender">引發事件的物件</param>
        /// <param name="e">事件的額外細項</param>
        private async void ButtonClick(object sender, EventArgs e)
        {            
            Button btn = sender as Button;

            // 呼叫webApi post方法 
            if (btn.Text == "api")
            {
                string text = lblText.Text;

                string json = JsonConvert.SerializeObject(text);  // 把post的參數值轉成json

                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json"); // 定義json內容

                HttpResponseMessage response = await client.PostAsync(UrlCal, contentPost); // webapi 回傳的物件
                response.EnsureSuccessStatusCode();

                var ans = response.Content.ReadAsStringAsync().Result;
                if (lblText.Text != string.Empty)
                {
                    var result = JsonConvert.DeserializeObject(ans);
                    textBox2.Text = result.ToString();
                }
                                                               
            }
            else if (btn.Text == "C") // 呼叫web API get方法
            {

                string text = btn.Text;
                string json = JsonConvert.SerializeObject(text);

                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(UrlClear, contentPost);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var resultObj = JsonConvert.DeserializeObject<NumBtn>(responseBody);
                lblText.Text = resultObj.text;
                textBox3.Text = resultObj.text;
               
            }  
            else if(btn.Text == "√")
            {
                string text = textBox3.Text;
                
                string json = JsonConvert.SerializeObject(text);

                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(UrlSquare, contentPost);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var resultObj = JsonConvert.DeserializeObject<NumBtn>(responseBody);
                textBox3.Text = resultObj.text;
            }
            else if(btn.Text == "+/-")
            {
                string text = textBox3.Text;

                string json = JsonConvert.SerializeObject(text);

                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(UrlNegative, contentPost);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var resultObj = JsonConvert.DeserializeObject<NumBtn>(responseBody);
                textBox3.Text = resultObj.text;
            }
            else // 呼叫web API post方法
            {
                
                string text = btn.Text;

                string json = JsonConvert.SerializeObject(text);

                HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json"); // 定義json內容


                HttpResponseMessage response = await client.PostAsync(UrlNum, contentPost);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();                    
                var resultObj = JsonConvert.DeserializeObject<NumBtn>(responseBody);

                //限制不能再按運算子                       

                if ((textBox3.Text == "0") || (isOperationPerformed))
                {
                    textBox3.Clear();
                }
                isOperationPerformed = false;

                if(btn.Text == ".")
                {
                    if (!textBox3.Text.Contains("."))
                    {
                        textBox3.Text = textBox3.Text + btn.Text;
                    }
                }
                else
                {
                    switch (btn.Text)
                    {
                        case "+":
                        case "-":
                        case "*":
                        case "/":
                            try
                            {
                                lblText.Text += textBox3.Text;
                                if (lblText.Text.Substring(lblText.Text.Length - 1) == "+" || lblText.Text.Substring(lblText.Text.Length - 1) == "-" || lblText.Text.Substring(lblText.Text.Length - 1) == "*" || lblText.Text.Substring(lblText.Text.Length - 1) == "/")
                                {
                                    lblText.Text = lblText.Text.Substring(0, lblText.Text.Length - 1);
                                    lblText.Text += resultObj.text;
                                    isOperationPerformed = false;
                                }
                                else
                                {
                                    lblText.Text += resultObj.text;
                                    textBox3.Text = string.Empty;
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("運算子不能再最前方");
                            }                                                  
                            break;
                        case ")":

                            lblText.Text += textBox3.Text + resultObj.text;
                            textBox3.Text = string.Empty;
                            break;
                        case "(": //後面只能接數字  
                            
                            lblText.Text += resultObj.text;                         
                            break;
                        case "=":

                            lblText.Text += textBox3.Text;
                            textBox3.Text = string.Empty;
                            break;
                        case "Back":

                            if(textBox3.Text != string.Empty)
                            {
                                textBox3.Text = textBox3.Text.Substring(0, textBox3.TextLength - 1);
                            }                           
                            break;
                        default:

                            textBox3.Text += resultObj.text;
                            break;
                    }               
                }             
            }
        }        
    }
}