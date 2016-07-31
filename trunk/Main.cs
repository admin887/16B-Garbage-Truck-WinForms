﻿using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenGL;

namespace Garage_Truck_WinfoForms
{
    
    public partial class Main : Form
    {
        public enum eCarMoving
        {
            Move,
            Reset,
            DoNothing
        }
        public static int moving;
        public enum eCameraMovig
        {
            DO_NOTHING,
            Forward,
            Backward,
            Right,
            Left
        }
        public static eCameraMovig cam;
        private bool isTruckMoving;
        cOGL c;

        int LastX=-1;
        int LastY=-1;


        public Main()
        {
            InitializeComponent();
            c = new cOGL(panel2);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            c.Draw();
        }
     

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            moving = 0;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                c.Draw(c.angle = scroll1.Value, c.angle = scrool2.Value, c.angle = scrool3.Value, scroll1.Value, scrool2.Value,0, (int)eCarMoving.Move);
            }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            c.Draw(c.angle = scroll1.Value, c.angle = scrool2.Value, c.angle = scrool3.Value, scroll1.Value, scrool2.Value, 0, (int)eCarMoving.Reset);
            //timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            c.Draw();
        }

        private void scroll9_Scroll(object sender, ScrollEventArgs e)
        {
            timer1.Interval = scroll9.Value;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            LastX = e.X;
            LastY = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            LastX = -1;
            LastY = -1;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void panel2_Move(object sender, EventArgs e)
        {
         
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
         // if (LastX != -1 && LastY != -1)
         // {
         //
         //     if (LastX != e.X)
         //     {
         //      //   c.Draw(scroll1.Value, e.X, e.Y, 0);
         //
         //
         // }
         //
        }

        private void scroll1_ValueChanged(object sender, EventArgs e)
        {
            c.Draw(c.angle = scroll1.Value,c.angle=scrool2.Value, c.angle = scrool3.Value, scroll1.Value, scrool2.Value,scroll4.Value, (int)eCarMoving.DoNothing);
        }

        private void scrool2_ValueChanged(object sender, EventArgs e)
        {
            c.Draw(c.angle = scroll1.Value, c.angle = scrool2.Value, c.angle = scrool3.Value, scroll1.Value, scrool2.Value, scroll4.Value, (int)eCarMoving.DoNothing);

            //   scroll1.Value = scrool2.Value;
        }

        private void scroll1_Leave(object sender, EventArgs e)
        {
      

        }

        private void scrool2_Leave(object sender, EventArgs e)
        {
            //scrool2.Maximum = scrool2.Value * 2;
        }

        private void scrool3_Scroll(object sender, ScrollEventArgs e)
        {
            c.Draw(c.angle = scroll1.Value, c.angle = scrool2.Value, c.angle = scrool3.Value, scroll1.Value, scrool2.Value, scroll4.Value, (int)eCarMoving.DoNothing);

        }

        private void scroll1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void scroll4_Scroll(object sender, ScrollEventArgs e)
        {
            c.Draw(c.angle = scroll1.Value, c.angle = scrool2.Value, c.angle = scrool3.Value, scroll1.Value, scrool2.Value, scroll4.Value, (int)eCarMoving.DoNothing);
        }

        private void scroll5_Scroll(object sender, ScrollEventArgs e)
        {
            //c.Draw(c.angle = scroll1.Value, c.angle = scrool2.Value, c.angle = scrool3.Value, scroll1.Value, scrool2.Value, scroll4.Value);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F)
            {
                moving = 1;
            }
            if (e.KeyData == Keys.B)
            {
                moving = -1;
            }
            if (e.KeyData == Keys.W)
            {
                cam = eCameraMovig.Forward;
            }
            if (e.KeyData == Keys.S)
            {
                cam = eCameraMovig.Backward;
            }
            if (e.KeyData == Keys.D)
            {
                cam = eCameraMovig.Right;
            }
            if (e.KeyData == Keys.A)
            {
                cam = eCameraMovig.Left;
            }
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            moving = 0;
            cam = eCameraMovig.DO_NOTHING;
        }
        private void tmrPaint_Tick(object sender, EventArgs e)
        {
            // clean opengl to draw
            //GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            Console.WriteLine(scrool2.Value);
            c.Draw(c.angle = scroll1.Value, c.angle = scrool2.Value, c.angle = scrool3.Value, scroll1.Value, scrool2.Value, scroll4.Value, (int)eCarMoving.DoNothing);

            //GL.glFlush();
        }
    }
}