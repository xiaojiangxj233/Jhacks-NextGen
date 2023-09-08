using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    public class QQNumberExtractor
    {
        private string FetchPageContent(string url)
        {
            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }

        public string ExtractSingleQQNumber()
        {
            string pageContent = FetchPageContent("http://ui.ptlogin2.qq.com/cgi-bin/login?hide_title_bar=0&low_login=0&qlogin_auto_login=1&no_verifyimg=1&link_target=blank&appid=636014201&target=self&s_url=http%3A//www.qq.com/qq2012/loginSuccess.htm");

            string extractedQQNumber = Match_Str("uin=\"", "\"", pageContent);
                
            return extractedQQNumber;
        }

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
            catch (Exception ex)
            {
                // Handle the exception
            }
            return "";
        }
    }
}

