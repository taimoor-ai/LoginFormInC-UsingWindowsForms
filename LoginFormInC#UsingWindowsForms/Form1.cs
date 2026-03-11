using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LoginFormInC_UsingWindowsForms
{
    public partial class Form1 : Form
    {
        private Panel cardPanel;
        private Label lblLogo;
        private RoundedTextBox txtUsername;
        private RoundedPasswordBox txtPassword;
        private Label placeholderUser;
        private Label placeholderPass;
        private GradientButton btnLogin;
        private LinkLabel lnkForgot;
        private Label lblOrDivider;
        private Button btnFacebook;
        private Label lblSignup;
        private LinkLabel lnkSignup;
        private Label lblError;
        private Panel footerPanel;
        private Label lblGetApp;
        private Button btnAppStore;
        private Button btnGooglePlay;

        public Form1()
        {
            InitForm();
            BuildUI();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitForm()
        {
            this.Text = "Instagram";
            this.Size = new Size(420, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(250, 250, 250);
            this.Font = new Font("Segoe UI", 10f);
        }

        private void BuildUI()
        {
            cardPanel = new Panel();
            cardPanel.Size = new Size(350, 440);
            cardPanel.Location = new Point(35, 40);
            cardPanel.BackColor = Color.White;
            cardPanel.Paint += CardPanel_Paint;

            lblLogo = new Label();
            lblLogo.Text = "Instagram";
            lblLogo.Font = new Font("Brush Script MT", 36f);
            lblLogo.Size = new Size(350, 60);
            lblLogo.Location = new Point(0, 32);
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            txtUsername = new RoundedTextBox();
            txtUsername.Size = new Size(268, 40);
            txtUsername.Location = new Point(40, 110);

            placeholderUser = MakePlaceholder("Phone number, username, or email", 53, 124);

            txtPassword = new RoundedPasswordBox();
            txtPassword.Size = new Size(268, 40);
            txtPassword.Location = new Point(40, 162);

            placeholderPass = MakePlaceholder("Password", 53, 176);

            lblError = new Label();
            lblError.Size = new Size(268, 36);
            lblError.Location = new Point(40, 210);
            lblError.ForeColor = Color.Red;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;

            btnLogin = new GradientButton();
            btnLogin.Size = new Size(268, 40);
            btnLogin.Location = new Point(40, 252);
            btnLogin.Text = "Log in";
            btnLogin.ForeColor = Color.White;
            btnLogin.Click += BtnLogin_Click;

            lnkForgot = new LinkLabel();
            lnkForgot.Text = "Forgot password?";
            lnkForgot.Size = new Size(268, 24);
            lnkForgot.Location = new Point(40, 304);
            lnkForgot.TextAlign = ContentAlignment.MiddleCenter;

            Panel leftLine = new Panel();
            leftLine.Size = new Size(100, 1);
            leftLine.Location = new Point(40, 346);
            leftLine.BackColor = Color.LightGray;

            lblOrDivider = new Label();
            lblOrDivider.Text = "OR";
            lblOrDivider.Size = new Size(40, 14);
            lblOrDivider.Location = new Point(152, 339);
            lblOrDivider.TextAlign = ContentAlignment.MiddleCenter;

            Panel rightLine = new Panel();
            rightLine.Size = new Size(100, 1);
            rightLine.Location = new Point(208, 346);
            rightLine.BackColor = Color.LightGray;

            btnFacebook = new Button();
            btnFacebook.Size = new Size(268, 36);
            btnFacebook.Location = new Point(40, 362);
            btnFacebook.Text = "Log in with Facebook";

            lblSignup = new Label();
            lblSignup.Text = "Don't have an account?";
            lblSignup.Location = new Point(40, 408);

            lnkSignup = new LinkLabel();
            lnkSignup.Text = "Sign up";
            lnkSignup.Location = new Point(210, 408);

            cardPanel.Controls.Add(lblLogo);
            cardPanel.Controls.Add(txtUsername);
            cardPanel.Controls.Add(txtPassword);
            cardPanel.Controls.Add(btnLogin);
            cardPanel.Controls.Add(lblError);
            cardPanel.Controls.Add(lnkForgot);
            cardPanel.Controls.Add(leftLine);
            cardPanel.Controls.Add(lblOrDivider);
            cardPanel.Controls.Add(rightLine);
            cardPanel.Controls.Add(btnFacebook);
            cardPanel.Controls.Add(lblSignup);
            cardPanel.Controls.Add(lnkSignup);

            this.Controls.Add(cardPanel);
        }

        private Label MakePlaceholder(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Size = new Size(240, 40);
            lbl.Location = new Point(x, y);
            lbl.ForeColor = Color.Gray;
            return lbl;
        }

        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            e.Graphics.DrawRectangle(Pens.LightGray, 0, 0, panel.Width - 1, panel.Height - 1);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text;

            if (user == "taimoor" && pass == "password123")
            {
                MessageBox.Show("Login Successful", "Instagram",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                HomeForm home = new HomeForm();
                home.welcome.Text = "Welcome to Home Page 🎉"+user;
                home.Show();

                this.Hide();
            }
            else
            {
                lblError.Text = "Invalid username or password";
                lblError.Visible = true;
            }
        }
    }

    public class RoundedTextBox : TextBox
    {
        public RoundedTextBox()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }

    public class RoundedPasswordBox : TextBox
    {
        public RoundedPasswordBox()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.PasswordChar = '●';
        }
    }

    public class GradientButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                Color.Orange,
                Color.Purple);

            g.FillRectangle(brush, this.ClientRectangle);

            TextRenderer.DrawText(g, this.Text, this.Font,
                this.ClientRectangle, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            brush.Dispose();
        }
    }
}