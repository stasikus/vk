using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vk
{
    public partial class vkForm : Form
    {
        public vkForm()
        {
            InitializeComponent();
            Driver.Initialize();
            DriverWait.Initialize(10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loginToVk();
        }

        public void loginToVk()
        {
            LoginPage.GoTo("vk.com");
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            bool ifCorrectCred = LoginPage.tryLogin(loginTB.Text, passTB.Text);
            if (!ifCorrectCred)
            {
                errorLabel.Visible = true;
            }

            bool ifCaptcha = LoginPage.isCaptcha();
            if (ifCaptcha)
            {
                errorLabel.Visible = true;
            }

            bool ifLogined = LoginPage.isLogined();
            if (ifLogined)
            {
                loginTB.Enabled = false;
                passTB.Enabled = false;
            }
        }
    }
}
