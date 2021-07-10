using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZoomInClass
{
    public partial class Form1 : Form
    {
        public DiscordRpcClient client;

        [DllImport("user32")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        public Form1()
        {
            InitializeComponent();

            Visible = false;
            Hide();
            ShowInTaskbar = false;

            client = new DiscordRpcClient("839191670145679400");
            client.Logger = new ConsoleLogger() {Level = LogLevel.Warning};

            //Subscribe to events
            client.OnReady += (_sender, _e) => { Console.WriteLine("Received Ready from user {0}", _e.User.Username); };

            client.OnPresenceUpdate += (_sender, _e) => { Console.WriteLine("Received Update! {0}", _e.Presence); };

            //Connect to the RPC
            client.Initialize();
            Console.WriteLine("Initialized.");

            timer1.Start();
        }

        void Deinitialize()
        {
            client.Dispose();
        }

        Timestamps ts;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] ps = Process.GetProcesses();
            bool isZoomClassing = false;
            foreach (Process p in ps)
            {
                try
                {
                    if ((p.MainWindowTitle.Contains("Zoom Meeting") || p.MainWindowTitle.Contains("Zoom Webinar") || p.ProcessName.Equals("CptHost")) && !p.ProcessName.Equals("ZoomInClass"))
                        isZoomClassing = true;
                    else
                        isZoomClassing = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }

            if (isZoomClassing)
            {
                if (ts == null)
                {
                    ts = Timestamps.Now;
                }

                client.SetPresence(new RichPresence()
                {
                    Details = "In Meeting",
                    Assets = new Assets()
                    {
                        LargeImageKey = "logo",
                    },
                    Timestamps = ts
                });
            }
            else
            {
                client.ClearPresence();
                ts = null;
            }
        }
    }
}