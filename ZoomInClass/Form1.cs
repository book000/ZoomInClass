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
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public DiscordRpcClient client;

        public Form1()
        {
            InitializeComponent();

            string[] cmds = Environment.GetCommandLineArgs();
            bool isDebugMode = false;
            foreach (string cmd in cmds)
            {
                if (cmd.Equals("--debug"))
                {
                    isDebugMode = true;
                }
            }

            Visible = false;
            Hide();
            ShowInTaskbar = false;

            // Debug Mode
            if (isDebugMode) {
                AllocConsole();
            }

            client = new DiscordRpcClient("762930592865714216")
            {
                Logger = new ConsoleLogger() { Level = LogLevel.Info }
            };

            // Subscribe to events
            client.OnReady += (_sender, _e) => {
                Console.WriteLine("Received Ready from user {0}", _e.User.Username);
            };

            client.OnPresenceUpdate += (_sender, _e) => { Console.WriteLine("Received Update! {0}", _e.Presence); };

            // Connect to the RPC
            bool isIntialized = client.Initialize();
            if (isIntialized) {
                Console.WriteLine("Initialized.");
            }
            else
            {
                MessageBox.Show("Error", "Failed to initialize! Is Discord running? If not, please start it.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            timer1.Start();
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
                    if ((p.MainWindowTitle.Contains("Zoom Meeting") ||
                        p.MainWindowTitle.Contains("Zoom Webinar") ||
                        p.MainWindowTitle.Contains("Zoom ミーティング") ||
                        p.ProcessName.Equals("CptHost")) &&
                        !p.ProcessName.Equals("ZoomInClass"))
                    {
                        isZoomClassing = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }

            Console.WriteLine("isZoomClassing: {0}", isZoomClassing);

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Dispose();
        }
    }
}