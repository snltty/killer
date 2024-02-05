using System.Diagnostics;
using System.Runtime.InteropServices;

namespace killer.win
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void OnKillerClick(object sender, EventArgs e)
        {
            try
            {
                if (uint.TryParse(tbPid.Text, out uint pid))
                {
                    int res = ProcessKiller(pid);
                    if (res == 0)
                    {
                        tbPid.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Ê§°Ü!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            try
            {
                LoadDriver("processKiller", Path.GetFullPath(Path.Join("./", "killer.sys")));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Closing(object sender, EventArgs e)
        {
            Execute("cmd.exe", string.Empty, new string[] {
                "sc stop processKiller",
                "sc delete processKiller",
            });
        }

        [DllImport("killer.dll")]
        public static extern int LoadDriver(string serviceName, string driverPath);

        [DllImport("killer.dll")]
        public static extern int ProcessKiller(uint pid);

        public static string Execute(string fileName, string arg, string[] commands, bool readResult = true)
        {
            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = Path.GetFullPath(Path.Join("./"));
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.Arguments = arg;
            proc.StartInfo.Verb = "runas";
            proc.Start();

            if (commands.Length > 0)
            {
                for (int i = 0; i < commands.Length; i++)
                {
                    proc.StandardInput.WriteLine(commands[i]);
                }
            }

            proc.StandardInput.AutoFlush = true;
            proc.StandardInput.WriteLine("exit");
            proc.StandardInput.Close();

            if (readResult)
            {
                string output = proc.StandardOutput.ReadToEnd();
                string error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();
                proc.Close();
                proc.Dispose();

                return output;
            }
            return string.Empty;
        }
    }
}
