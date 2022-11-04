﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ajandek.Abstractions
{
    public abstract class Toy:Label
    {
        public Toy()
        {
            AutoSize = false;
            Height = 50;
            Width = 50;
            Paint += Ball_Paint;

        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        protected abstract void DrawImage(Graphics g);
               

        public virtual void MoveBall()
        {
            Left += 1;
        }


    }
}

