using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;

    public class CheckUpdate
    {
        private static CheckUpdate instance;
        private UpdateInfoData updateInfo;

        private CheckUpdate()
        {
            // 在构造函数中获取更新信息
            updateInfo = GetUpdateInfo();
        }

        public static CheckUpdate Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CheckUpdate();
                }
                return instance;
            }
        }

        private UpdateInfoData GetUpdateInfo()
        {
            string apiUrl = "https://jhacks.xiaojiang233.top/version.json";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<UpdateInfoData>(json);
                    }
                    else
                    {
                        return null; // 处理无法获取更新信息的情况
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
                return null; // 处理发生异常的情况
            }
        }

        public string GetVersion()
        {
            if (updateInfo != null)
            {
                return updateInfo.version;
            }
            else
            {
                return "无法获取版本号";
            }
        }

        public string GetAttribute()
        {
            if (updateInfo != null)
            {
                return updateInfo.attribute;
            }
            else
            {
                return "无法获取属性";
            }
        }

        public string GetTime()
        {
            if (updateInfo != null)
            {
                return updateInfo.time;
            }
            else
            {
                return "无法获取日期";
            }
        }

        public string GetUpdate()
        {
            if (updateInfo != null)
            {
                return updateInfo.update;
            }
            else
            {
                return "无法获取更新内容";
            }
        }

        public string Link()
        {
            if (updateInfo != null)
            {
                return updateInfo.link;
            }
            else
            {
                return "None"; // 默认为非重要
            }
        }
    }

    public class UpdateInfoData
    {
        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("attribute")]
        public string attribute { get; set; }

        [JsonProperty("time")]
        public string time { get; set; }

        [JsonProperty("update")]
        public string update { get; set; }

        [JsonProperty("link")]
        public string link { get; set; }
    }

}
