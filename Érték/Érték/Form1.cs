using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Érték
{
    public partial class Form1 : Form
    {
        new PortfolioEntities context = new PortfolioEntities();

        List<Tick> Ticks = new List<Tick>();
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Ticks.ToList();
            dataGridView1.DataSource = Ticks;
        }
    }
}
