using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIChatBotClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            GetData();
        }

        async Task GetData()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 요청할 URL 설정
                    string apiUrl = "https://8fbe425d347b1e0a2d.gradio.live/predict";

                    // POST 요청에 전송할 데이터
                    string jsonData = "{\"data\":[\"" + textBox1.Text + "\"]}";

                    // 데이터를 HttpContent로 변환
                    HttpContent content = new StringContent(jsonData);

                    // 요청 헤더 설정
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    // POST 요청 보내기
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // 응답 확인
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        label1.Text = responseContent;
                    }
                    else
                    {
                        label1.Text = "오류 발생: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    label1.Text = "오류 발생: " + ex.Message;
                }
            }
        }

    }
}
