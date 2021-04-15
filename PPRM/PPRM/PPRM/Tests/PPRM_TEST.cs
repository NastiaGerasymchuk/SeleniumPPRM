using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PPRM.Data;
using PPRM.Data.TestData;
using System;

namespace PPRM.Tests
{
    public class PPRM_TEST
    {        
        private WebDriverWait wait;
        private IWebDriver driver;
        private const string URL = "http://localhost:8888/";
        private const string CHROME_PATH = @"C:\Users\Admin\Desktop";
        private const double TIME_WAITING = 10;
        private const string FAIL_TEST_FOLDER = @"C:\Users\Admin\Desktop\SeleniumCourseWork\PPRM\PPRM\PPRM\FailedTests\";
        
        [SetUp]
        public virtual void SetUp()
        {
            driver = new ChromeDriver(CHROME_PATH);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_WAITING));
        }
        
        public Polynom GetBeginningPage()
        {
            driver.Navigate().GoToUrl(URL);
            return new Polynom(driver);
        }
        [Test]
        public void BeginningValues()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            Assert.That(polynom.DisplayedTable, Is.True);
            Assert.That(polynom.DisplayedFastFunctionInput, Is.True);
            Assert.That(polynom.DisplayedVectorPol, Is.True);
            Assert.That(polynom.DisplayedFastVectorInput, Is.True);            
            Assert.That(polynom.DisplayedCriterious, Is.True);
            Assert.That(polynom.DisplayedBtnFind, Is.True);            
            //Assert.That(polynom.TitleResValue(), Is.EqualTo(BEGIN_TITLE_VALUE));
            //Assert.That(polynom.PolynomResValue, Is.EqualTo(BEGIN_RES_VALUE));

        }
        [Test]
        public void BeginningTableData()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            Assert.That(polynom.GetBullFunctionTitleValue, Is.EqualTo(BaseSelectorData.BullFunctionTitle));
            Assert.That(polynom.GetBullFunctionChangeCountValue, Is.EqualTo(BaseSelectorData.ChangeCountTitle));
            Assert.That(polynom.GetKzfValue, Is.EqualTo(BaseSelectorData.KZF));
            Assert.That(polynom.EnabledKzfValue, Is.False);
            Assert.That(polynom.AllFunctionZeroes, Is.True);
        }
        [Test]
        public void BeginningFastFunctionData()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            Assert.That(polynom.GetFastFunctionLegendTitle, Is.EqualTo(BaseSelectorData.FastFunctionLegend));
            Assert.That(polynom.GetAllZeroFunctionValue, Is.EqualTo(BaseSelectorData.AllZeroes));
            Assert.That(polynom.GetAllOneFunctionValue, Is.EqualTo(BaseSelectorData.AllOnes));
            Assert.That(polynom.GetAllQuestionFunctionValue, Is.EqualTo(BaseSelectorData.AllQuestions));
        }
        [Test]
        public void BeginningvectorPolData()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            Assert.That(polynom.GetVectorPolLegendTitle, Is.EqualTo(BaseSelectorData.VectorPolLegend));
            Assert.That(polynom.AllVectorZeroes, Is.True);

        }
        [Test]
        public void BeginningFastVectorData()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            Assert.That(polynom.GetFastVectorLegendTitle, Is.EqualTo(BaseSelectorData.FastVectorLegend));
            Assert.That(polynom.GetAllZeroVectorValue, Is.EqualTo(BaseSelectorData.AllZeroes));
            Assert.That(polynom.GetAllOneVectorValue, Is.EqualTo(BaseSelectorData.AllOnes));
            Assert.That(polynom.GetAllQuestionVectorValue, Is.EqualTo(BaseSelectorData.AllQuestions));
        }
        [Test]
        public void BeginningCriteriousData()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            Assert.That(polynom.GetCriteriousLegendTitle, Is.EqualTo(BaseSelectorData.CriteriousLegend));
            Assert.That(polynom.GetOpCountTitle, Is.EqualTo(BaseSelectorData.MinOpCount));
            Assert.That(polynom.GetAddCountTitle, Is.EqualTo(BaseSelectorData.MinAddCount));
            Assert.That(polynom.GetChangeCountTitle, Is.EqualTo(BaseSelectorData.MinChangeCount));
            Assert.That(polynom.IsSelectedMinOPCount, Is.True);
        }
        [Test]
        public void BtnFindPolynom()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            Assert.That(polynom.GetBtnFindPolynomValue, Is.EqualTo(BaseSelectorData.FindPolynom));
            Assert.That(polynom.EnabledBtnFindPolynom, Is.True);
        }
        [Test]
        public void AllOneFunctionClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.AllFunctionOneClick();
            Assert.That(polynom.AllFunctionOnes(), Is.True);
        }
        [Test]
        public void AllQuestionFunctionClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.AllFunctionQuestionClick();
            Assert.That(polynom.AllFunctionQuestions(), Is.True);
        }
        [Test]
        public void AllZeroesFunctionClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.AllFunctionZeroClick();
            Assert.That(polynom.AllFunctionZeroes(), Is.True);
        }
        [Test]
        public void CeilChangesClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.AllFunctionZeroClick();
            Assert.That(polynom.AllFunctionZeroes(), Is.True);
        }
        [Test]
        public void CeilValuesChangesClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.FirstSeilClick();
            Assert.That(polynom.FirstSeilValue, Is.EqualTo("1"));
            polynom.FirstSeilClick();
            Assert.That(polynom.FirstSeilValue, Is.EqualTo("?"));
            polynom.FirstSeilClick();
            Assert.That(polynom.FirstSeilValue, Is.EqualTo("0"));
        }
        [Test]
        public void AllOneVectorClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.AllVectorOneClick();
            Assert.That(polynom.AllVectorOnes(), Is.True);
        }
        [Test]
        public void AllQuestionVectorClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.AllVectorQuestionClick();
            Assert.That(polynom.AllVectorQuestions(), Is.True);
        }
        [Test]
        public void AllZeroesVectorClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.AllVectorZeroClick();
            Assert.That(polynom.AllVectorZeroes(), Is.True);
        }
        [Test]
        public void CeilValuesVectorClick()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.FirstSeilVectorClick();
            Assert.That(polynom.FirstSeilVectorValue(), Is.EqualTo("1"));
            polynom.FirstSeilVectorClick();
            Assert.That(polynom.FirstSeilVectorValue(), Is.EqualTo("?"));
        }
        [Test]
        public void ChangeMinOpCount()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.MinOPCountClick();
            Assert.That(polynom.IsSelectedMinOPCount, Is.True);
        }
        [Test]
        public void ChangeMinAddCount()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.MinAddCountClick();
            Assert.That(polynom.IsSelectedMinAddCount, Is.True);
        }
        [Test]
        public void ChangeMinChangeCount()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.MinChangeCountClick();
            Assert.That(polynom.IsSelectedMinChangeCount(), Is.True);
        }

        [TestCaseSource(typeof(BeginningPolynom))]
        public void FindPolynomBeginningValues(string title,string polynomRes)
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.FindPolynomClick();
            Assert.That(polynom.TitleResValue(), Is.EqualTo(title));
            Assert.That(polynom.PolynomResValue, Is.EqualTo(polynomRes));
        }
        [TestCaseSource(typeof(MinOpCountExample))]
        public void ExamlePolynomByMinOpCount(string title, string polynomRes)
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.SetExampleFunction();
            polynom.MinOPCountClick();
            polynom.FindPolynomClick();
            Assert.That(polynom.TitleResValue(), Is.EqualTo(title));
            Assert.That(polynom.PolynomResValue, Is.EqualTo(polynomRes));
            
        }
        [TestCaseSource(typeof(MinAddCountExample))]
        public void ExamlePolynomByMinAddCount(string title, string polynomRes)
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.SetExampleFunction();
            polynom.MinAddCountClick();
            polynom.FindPolynomClick();
            Assert.That(polynom.TitleResValue(), Is.EqualTo(title));
            Assert.That(polynom.PolynomResValue, Is.EqualTo(polynomRes));

        }
        [TestCaseSource(typeof(MinChangeCountExample))]
        public void ExamlePolynomByMinChangeCount(string title, string polynomRes)
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.SetExampleFunction();
            polynom.MinChangeCountClick();
            polynom.FindPolynomClick();
            Assert.That(polynom.TitleResValue(), Is.EqualTo(title));
            Assert.That(polynom.PolynomResValue, Is.EqualTo(polynomRes));

        }
        [Test]
        public void ClearOutputData1()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.FindPolynomClick();
            polynom.FirstSeilClick();
        }
        [Test]
        public void ClearOutputData()
        {
            driver.Navigate().GoToUrl(URL);
            Polynom polynom = new Polynom(driver);
            polynom.FindPolynomClick();
            polynom.FirstSeilClick();
            Assert.That(polynom.PolynomResValue, Is.EqualTo(""));

        }
        private void GetScreen(string name)
        {
            string path = FAIL_TEST_FOLDER;
            string fullPath = path + name;
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);

        }

        [TearDown]
        public virtual void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                GetScreen(testName);
            }
            driver.Close();
        }
    }
}
