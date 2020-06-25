using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FifteenGUIDynamic
{
	public partial class ReSize : Form
	{
       
		public ReSize()
		{
			InitializeComponent();
            size = -1;
        }
        int size;
        public int Size
        {
            get => size;
        }

        private void Size2_Click(object sender, EventArgs e)
        {
            size = 2;
            Close();
        }

        private void Size3_Click(object sender, EventArgs e)
        {
            size = 3;
            Close();
        }

        private void Size4_Click(object sender, EventArgs e)
        {
            size = 4;
            Close();
        }

        private void Size5_Click(object sender, EventArgs e)
        {
            size = 5;
            Close();
        }
    }
}
