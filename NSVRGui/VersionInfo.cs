﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSVRGui
{
	public partial class VersionInfo : Form
	{
		private Label serviceVersion;
		private Label clientVersion;
		private string installPath;
		public VersionInfo(DllVersions version)
		{
			InitializeComponent();
			serviceVersion = (Label)Controls["serviceversion"];
			clientVersion = (Label)Controls["clientversion"];
			serviceVersion.Text = version.Service.ToString();
			clientVersion.Text = version.Client.ToString();
			Rectangle r = Screen.PrimaryScreen.WorkingArea;
			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);

			RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Hardlight VR\\Service", false);
			if (rk != null)
			{
				installPath = (string)rk.GetValue("InstallPath");
			}
	
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (installPath != null)
			{
				System.Diagnostics.Process.Start(installPath +
					@"/release_notes.txt");
			} else
			{
				MessageBox.Show("Couldn't find the release notes. Check release_notes.txt in your install directory");
			}

		}

		private void serviceversion_Click(object sender, EventArgs e)
		{

		}

		private void VersionInfo_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
