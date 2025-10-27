using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void btnExecuteDos_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c ipconfig",
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

            txtCommand.Text = psi.Arguments;
            txtOutput.Text = output;

            if(!string.IsNullOrEmpty(error))
                Console.WriteLine($"에러: {error}");
        }

    }
}
