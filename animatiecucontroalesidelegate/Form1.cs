using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace animatiecucontroalesidelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void changemytextdelagate(Control ctrl, string text);

        public static void moveto(Control ctrl, int n)
        {
            for (int i = 0; i < n; i++)
            {
                ctrl.Left += i;

            } 
        }

        public static void changemytext(Control ctrl, string text)
        {
            if(ctrl.InvokeRequired)
            {
                changemytextdelagate del = new changemytextdelagate(changemytext);
                ctrl.Invoke(del, ctrl, text);
               
            }
            else
            {
                ctrl.Text = text;
            }
        }
        private Thread thread2 = null;

        public void makeanim()
        {
            changemytext(this.button1,"alfa");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(new ThreadStart(makeanim));
            thread2.Start();
            Thread.Sleep(1);
        }
    }
}
