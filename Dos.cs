using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gis
{
    public partial class Dos : Form
    {
        public Dos()
        {
            InitializeComponent();
        }

        private void Dos_Load(object sender, EventArgs e)
        {
            comboCommand.Items.Add("ipconfig");
            comboCommand.Items.Add("dir");

            if(comboCommand.Items.Count > 0)
                comboCommand.SelectedIndex = 0;
        }

        private void btnExecuteDos_Click(object sender, EventArgs e)
        {
            string command = "/c " + comboCommand.Text.Trim();

            if(string.IsNullOrEmpty(command))
            {
                MessageBox.Show("명령어를 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = command,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = new Process { StartInfo = psi };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            string ipv4 = "";
            foreach(string line in output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if(line.Contains("IPv4 주소"))
                {
                    int idx = line.IndexOf(":");
                    if(idx != -1)
                    {
                        ipv4 = line.Substring(idx + 1).Trim();
                        break;
                    }
                }
            }

            if(psi.Arguments.Equals("/c ipconfig"))
                txtOutput.Text = string.IsNullOrEmpty(ipv4) ? "IPv4 주소를 찾을 수 없습니다." : $"IPv4 주소: {ipv4}";
            else
                txtOutput.Text = output;

            if (!string.IsNullOrEmpty(error))
                Console.WriteLine($"에러: {error}");
        }

        
    }
}
