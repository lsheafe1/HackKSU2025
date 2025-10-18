using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackKSU2025
{
    public partial class MenuPage : UserControl
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void uxParentClick(object sender, EventArgs e)
        {
            MainForm? main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new ScenarioPage(ScenarioType.Parent));
            }


        }
    }
}
