using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Reflection;
using System.Net;

namespace ZoomTest
{
    public class ZoomTest
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

        public void ZoomIn(int startX1, int startY1, int endX1, int endY1, int startX2, int startY2, int endX2, int endY2)
        {
            var finger1 = new PointerInputDevice(PointerKind.Touch);
            var finger2 = new PointerInputDevice(PointerKind.Touch);

            var zoomIn1 = new ActionSequence(finger1);
            
            zoomIn1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, startX1, startY1,
                TimeSpan.Zero));
            zoomIn1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
            zoomIn1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, endX1, endY1,
                TimeSpan.FromSeconds(1)));
            zoomIn1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

            var zoomIn2 = new ActionSequence(finger2);

            zoomIn2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, startX2, startY2,
                TimeSpan.Zero));
            zoomIn2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
            zoomIn2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, endX2, endY2,
                TimeSpan.FromSeconds(1)));
            zoomIn2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { zoomIn1, zoomIn2 });
        }

        public void ZoomOut(int startX1, int startY1, int endX1, int endY1, int startX2, int startY2, int endX2, int endY2)
        {
            var finger1 = new PointerInputDevice(PointerKind.Touch);
            var finger2 = new PointerInputDevice(PointerKind.Touch);

            var zoomOut1 = new ActionSequence(finger1);

            zoomOut1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, startX1, startY1,
                TimeSpan.Zero));
            zoomOut1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
            zoomOut1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, endX1, endY1,
                TimeSpan.FromSeconds(1)));
            zoomOut1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

            var zoomOut2 = new ActionSequence(finger2);

            zoomOut2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, startX2, startY2,
                TimeSpan.Zero));
            zoomOut2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
            zoomOut2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, endX2, endY2,
                TimeSpan.FromSeconds(1)));
            zoomOut2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { zoomOut1, zoomOut2 });
        }

        [Test]
        public void Test_ZoomIn()
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();
            var webView = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"WebView\"))"));
            webView.Click();

            ZoomIn(170, 682, 207, 500, 170, 788, 170, 940);


        }

        [Test]
        public void Test_ZoomOut()
        {
            
            ZoomOut(207, 500, 170, 682, 170, 940, 170, 788);

        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}