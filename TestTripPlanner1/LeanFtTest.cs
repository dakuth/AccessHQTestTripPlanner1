using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HP.LFT.SDK;
using HP.LFT.SDK.Web;
using HP.LFT.Verifications;

namespace TestTripPlanner1
{
    [TestClass]
    public class LeanFtTest : UnitTestClassBase<LeanFtTest>
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GlobalSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            string fromCode = "10101112";
            string toCode = "10101101";

            IBrowser browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.Navigate("https://transportnsw.info/trip#/?from=" + fromCode + "&to=" + toCode);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string fromText = "North Sydney Station";
            string toText = "Town Hall Station";
            
            IBrowser browser = BrowserFactory.Launch(BrowserType.Chrome);
            browser.Navigate("https://transportnsw.info/trip");
            var fromBox = browser.Describe<IEditField>(new EditFieldDescription
            {
                Type = @"text",
                TagName = @"INPUT",
                Name = @"search-input-From"
            });

            Boolean doesExits = fromBox.Exists(5);
            if (doesExits == true)
            {
                Reporter.ReportEvent("Box Exist Check", "Verify that Box exists value is= " + doesExits, HP.LFT.Report.Status.Passed);
                fromBox.SetValue(fromText);
                fromBox.Submit();
            }
            else
            {
                Reporter.ReportEvent("Box Exist Check", "Verify that Box exists value is= " + doesExits, HP.LFT.Report.Status.Failed);
            }

            var toBox = browser.Describe<IEditField>(new EditFieldDescription
            {
                Type = @"text",
                TagName = @"INPUT",
                Name = @"search-input-To"
            });

            doesExits = toBox.Exists(5);
            if (doesExits == true)
            {
                Reporter.ReportEvent("Box Exist Check", "Verify that Box exists value is= " + doesExits, HP.LFT.Report.Status.Passed);
                toBox.SetValue(toText);
                toBox.Submit();
            }
            else
            {
                Reporter.ReportEvent("Box Exist Check", "Verify that Box exists value is= " + doesExits, HP.LFT.Report.Status.Failed);
            }

            var goButton = browser.Describe<IButton>(new ButtonDescription
            {
                ButtonType = @"button",
                Role = string.Empty,
                AccessibilityName = string.Empty,
                TagName = @"BUTTON",
                Name = @"Go",
                Index = 0
            });

            doesExits = goButton.Exists(5);
            if (doesExits == true)
            {
                Reporter.ReportEvent("Button Exist Check", "Verify that Button exists value is= " + doesExits, HP.LFT.Report.Status.Passed);
                goButton.Click();
            }
            else
            {
                Reporter.ReportEvent("Button  Exist Check", "Verify that Button exists value is= " + doesExits, HP.LFT.Report.Status.Failed);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            GlobalTearDown();
        }
    }
}
