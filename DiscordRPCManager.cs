using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace Jhacks_NextGen
{
    class DiscordRPCManager : IDisposable
    {
        private DiscordRpcClient client;
        private const string DefaultApplicationId = "1157951285652369490"; // 默认的应用程序ID
        private bool isRPCStarted = false;
        public DiscordRPCManager(string applicationId = DefaultApplicationId)
        {
            client = new DiscordRpcClient(applicationId);
            Initialize();
        }

        public void Initialize()
        {
            
            if (!isRPCStarted)
            {
                client.Initialize();
                isRPCStarted = true;
            }
        }

        public void UpdatePresence(string details, string state, string largeImageKey, string largeImageText, string smallImageKey, string smallImageText)
        {
            var presence = new RichPresence()
            {
                Details = details,
                State = state,
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageText,
                    SmallImageKey = smallImageKey,
                    SmallImageText = smallImageText
                }
            };

            client.SetPresence(presence);
        }

        public void StartRPC()
        {
            if (!isRPCStarted)
            {
                Initialize();
                isRPCStarted = true;
            }
        }

        public void StopRPC()
        {
            if (isRPCStarted)
            {
                client.ClearPresence();
                client.Deinitialize();
                isRPCStarted = false;
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public static void DiscordRPC(bool isPlaying, string details, string state, string largeImageKey, string largeImageText, string smallImageKey, string smallImageText, bool startRPC)
        {
            using (var rpcManager = new DiscordRPCManager(DefaultApplicationId))
            {
                if (startRPC)
                {
                    rpcManager.StartRPC();
                    rpcManager.UpdatePresence(details, state, largeImageKey, largeImageText, smallImageKey, smallImageText);
                    DevConsole.Instance.WriteLine("Discord RPC服务已启动");
                    MessageBox.Show("Discord RPC服务已启动", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rpcManager.StopRPC();
                    DevConsole.Instance.WriteLine("Discord RPC服务已停止");
                    MessageBox.Show("Discord RPC服务已停止", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
