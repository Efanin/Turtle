using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp11
{
    public partial class Form2 : Form
    {
        List<Command> cmds;
        public Form2(List<Command> cmds)
        {
            InitializeComponent();
            this.cmds = cmds;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            int x = 200;
            int y = 200;
            double angel = 0;
            double forward = 0;
            int newx = 0;
            int newy = 0;
            for (int i = 0; i < cmds.Count; i++)
            {
                if (cmds[i].key== "right")
                    angel += double.Parse(cmds[i].value);
                if (cmds[i].key == "left")
                    angel -= double.Parse(cmds[i].value);
                if (cmds[i].key == "forward")
                    forward = double.Parse(cmds[i].value);
                newx = (int)(forward * Math.Cos(angel / 180 * Math.PI));
                newy = (int)(forward * Math.Sin(angel / 180 * Math.PI));
                Point point1 = new Point(x, y);
                x += newx;
                y += newy;
                Point point2 = new Point(x, y);
                e.Graphics.DrawLine(pen, point1, point2);
                forward = 0;
            }
        }
    }
}
