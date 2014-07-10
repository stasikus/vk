using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Windows.Forms;

namespace vk
{
    public class LoginPage
    {
        public static void GoTo(string server)
        {
            Driver.Instance.Navigate().GoToUrl("http://"+server);
        }

        public static bool tryLogin(string login, string pass)
        {
            var errorSubmit = Driver.Instance.FindElementAndWait(By.Id("message_text"), 1);
            if (errorSubmit == null)
            {
                var loginVal = Driver.Instance.FindElement(By.Id("quick_email"));
                loginVal.Clear();
                loginVal.SendKeys(login);

                var passVal = Driver.Instance.FindElement(By.Id("quick_pass"));
                passVal.Clear();
                passVal.SendKeys(pass);

                Driver.Instance.FindElement(By.Id("quick_login_button")).Click();

                return recheckIf();
            }
            else
            {
                var loginVal = Driver.Instance.FindElement(By.Id("email"));
                loginVal.Clear();
                loginVal.SendKeys(login);

                var passVal = Driver.Instance.FindElement(By.Id("pass"));
                passVal.Clear();
                passVal.SendKeys(pass);

                Driver.Instance.FindElement(By.XPath("//div[@class='button_blue']/button[@onclick='quick_login();return cancelEvent(event);']")).Click();
                System.Threading.Thread.Sleep(300);

                return recheckIf();
            }
        }

        public static bool recheckIf()
        {
            var errorSubmitAgain = Driver.Instance.FindElementAndWait(By.Id("message_text"), 1);
            if (errorSubmitAgain == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isLogined()
        {
            var isLogin = Driver.Instance.FindElementAndWait(By.XPath("//div[@id='side_bar']/ol"), 1);
            if (isLogin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isCaptcha()
        {

            var captchWin = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='captcha']"));
            if (captchWin != null)
            {
                Driver.Instance.FindElement(By.XPath("//div[@class='box_x_button']")).Click();
                return true;
            }
            return false;
        }
        
    }
}
