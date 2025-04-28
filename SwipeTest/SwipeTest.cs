using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace SwipeTest
{
    public class SwipeTest
    {
        private AndroidDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UiAutomator2",
                DeviceName = "Pixel_9_API_35",
                App = "C:\\Users\\Toka7\\Downloads\\ApiDemos-debug.apk"

            };
            driver = new AndroidDriver(appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Test_Swipe()
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();
            var gallery = driver.FindElement(MobileBy.AccessibilityId("Gallery"));
            gallery.Click();
            var photos = driver.FindElement(MobileBy.AccessibilityId("1. Photos"));
            photos.Click();

            var pic1 = driver.FindElements(MobileBy.ClassName("android.widget.ImageView"))[0];

            var action = new Actions(driver);
            var swipe = action.ClickAndHold(pic1)
                              .MoveByOffset(-200, 0)
                              .Release()
                              .Build();
            swipe.Perform();

            var pic3 = driver.FindElements(MobileBy.ClassName("android.widget.ImageView"))[2];
            Assert.That(pic3, Is.Not.Null); 
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}