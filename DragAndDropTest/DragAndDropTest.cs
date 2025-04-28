using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;

namespace DragAndDropTest
{
    public class DragAndDropTest
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
        public void Test_DragAndDrop()
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();
            var dragAndDrop = driver.FindElement(MobileBy.AccessibilityId("Drag and Drop"));
            dragAndDrop.Click();

            var dot1 = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_dot_1"));
            var dot2 = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_dot_2"));

            var scriptArguments = new Dictionary<string, object>
            {
                {"elementId", dot1 },
                {"endX", dot2.Location.X + (dot2.Size.Width / 2)},
                {"endY", dot2.Location.Y + (dot2.Size.Height / 2)},
                {"speed", 2500 }
            };

            driver.ExecuteScript("mobile: dragGesture", scriptArguments);

            var resultMessage = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_result_text")).Text;
            Assert.That(resultMessage, Is.EqualTo("Dropped!"));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}