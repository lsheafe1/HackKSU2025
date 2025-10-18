using System.Windows.Forms;

namespace HackKSU2025
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadPage(new MenuPage());
            ScenarioPage.RetrieveStartingPrompt();
        }
        public void LoadPage(UserControl page)
        {
            uxPanelContainer.Controls.Clear();
            page.Dock = DockStyle.Fill;
            uxPanelContainer.Controls.Add(page);
        }
    }
}
