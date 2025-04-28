using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.Interactions;
using System.Drawing;


namespace SeekBarTest
{
    public class SeekBarTest
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

        public void MoveSeekbar(int startX, int startY, int endX, int endY)
        {
            var finger = new PointerInputDevice(PointerKind.Touch);

            var startPoint = new Point(startX, startY);
            var endPoint = new Point(endX, endY);

            var swipeSequence = new ActionSequence(finger);

            swipeSequence.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startPoint.X, startPoint.Y,
                TimeSpan.Zero));
            swipeSequence.AddAction(finger.CreatePointerDown(MouseButton.Left));
            swipeSequence.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, endPoint.X, endPoint.Y,
                TimeSpan.FromSeconds(1)));
            swipeSequence.AddAction(finger.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { swipeSequence });
        }

        [Test]
        public void Test_SeekBar()
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();
            var seekbar = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Seek Bar\"))"));
            seekbar.Click();

            MoveSeekbar(540, 313, 1037, 313);
            
            
            var resultMessage = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/progress")).Text;
            Assert.That(resultMessage, Is.EqualTo("100 from touch=true"));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}