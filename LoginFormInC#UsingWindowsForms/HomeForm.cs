using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginFormInC_UsingWindowsForms
{
    public partial class HomeForm : Form
    {
        public Label welcome = new Label();

        public HomeForm()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text = "Instagram Home";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

          
            welcome.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            welcome.AutoSize = true;
            welcome.Location = new Point(150, 200);

            this.Controls.Add(welcome);
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}