﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialDataDownload
{
    public partial class SelectPortForm : Form
    {
        private bool exit = true;

        public SelectPortForm()
        {
            InitializeComponent();
        }

        private void SelectPortForm_Load(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames();
            Array.Sort(names);
            PortsDropDown.Items.Clear();
            foreach (String name in names)
            {
                PortsDropDown.Items.Add(name);
            }
            if (PortsDropDown.Items.Count >= 2)
            {
                PortsDropDown.SelectedIndex = 1;
            }
            else
            {
                PortsDropDown.SelectedIndex = 0;
            }            
        }

        private void SelectPortButton_Click(object sender, EventArgs e)
        {
            exit = false;

            SerialConnection conn = new SerialConnection(PortsDropDown.SelectedItem.ToString());            
            this.Close();
            conn.Show();
        }

        private void SelectPortForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (exit) Application.Exit();
        }
    }
}
