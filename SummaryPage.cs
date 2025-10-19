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
    public partial class SummaryPage : UserControl
    {
        ScenarioType scenarioType;
        public SummaryPage(ScenarioType scenarioType, string message)
        {
            this.scenarioType = scenarioType;
            InitializeComponent();
            uxMessageBox.Text = message;
        }

        private void uxBackClick(object sender, EventArgs e)
        {
            MainForm? main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new MenuPage());
            }
        }

        private void uxNewClick(object sender, EventArgs e)
        {
            MainForm? main = this.FindForm() as MainForm;
            if (main != null)
            {
                main.LoadPage(new ScenarioPage(scenarioType));
            }
        }
    }
}
