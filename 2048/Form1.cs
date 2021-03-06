﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        BlockManager manager = new BlockManager(12, 12, 40 ,40, 10, 10); //커스텀 가능
        public Form1()
        {
            InitializeComponent();
            manager.BlockControl.Location = new Point(15, 105);
            this.Controls.Add(manager.BlockControl);

            foreach(Control c in this.Controls)
            {
                c.KeyDown += Form1_KeyDown;
            }

            this.label2.Text = manager.MaxValue().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manager.Restart();
            this.label2.Text = manager.MaxValue().ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (manager.CheckGameOver())
            {
                MessageBox.Show("게임 오버! 최대 수 : " + label2.Text);
                return;
            }
            if(e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                manager.Move(BlockManager.Arrow.LEFT);
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                manager.Move(BlockManager.Arrow.UP);
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                manager.Move(BlockManager.Arrow.RIGHT);
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                manager.Move(BlockManager.Arrow.DOWN);
            }

            this.label2.Text = manager.MaxValue().ToString();
        }
    }
}
