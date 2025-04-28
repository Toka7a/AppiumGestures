using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;


namespace ScrollTest
{
    public class ScrollTest
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
        public void Test_Scroll()
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();

            var listsElement = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Lists\"))"));
            listsElement.Click();

            var firstElementInList = driver.FindElement(MobileBy.AccessibilityId("01. Array"));

            Assert.That(firstElementInList, Is.Not.Null);
        }

        [OneTimeTearDown]   
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}