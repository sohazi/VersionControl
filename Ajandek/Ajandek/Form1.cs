using Ajandek.Entities;
using Ajandek.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajandek
{
    public partial class Form1 : Form
    {
        private List<Toy> _toy = new List<Toy>();
        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _toy.Add((Ball)ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxpos = 0;
            foreach (var ball in _toy)
            {
               ball.MoveBall();
                if(ball.Left > maxpos)
                    maxpos = ball.Left;

            }

            if (maxpos > 1000)
            {
                var oldestBall = _toy[0];
                mainPanel.Controls.Remove(oldestBall);
                _toy.Remove(oldestBall);
            }
        }
    }
}
