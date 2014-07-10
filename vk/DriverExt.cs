using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk
{
    public interface IWebDriverExt : IWebDriver
    {
        IWebElement FindElementAndWait(By by);
        IWebElement FindElementAndWait(By by, int seconds);
    }
    public class FirefoxDriverExt : FirefoxDriver, IWebDriverExt
    {
        public IWebElement FindElementAndWait(By by)
        {
            try
            {
                var element = DriverWait.Instance.Until<IWebElement>(d =>
                {
                    var elements = Driver.Instance.FindElements(by);
                    if (elements.Count > 0)
                        return elements[0];
                    else
                        return null;
                });
                return element;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public IWebElement FindElementAndWait(By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);
            try
            {
                var element = DriverWait.Instance.Until<IWebElement>(d =>
                {
                    var elements = Driver.Instance.FindElements(by);
                    if (elements.Count > 0)
                        return elements[0];
                    else
                        return null;
                });
                return element;
            }
            catch (Exception)
            {

                return null;
            }           
        }
    }
}
