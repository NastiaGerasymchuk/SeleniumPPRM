using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PPRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRM
{
    public class Polynom
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        private const double TIME_WAITING = BaseData.SecondsWaintings;
        private const string CRITERIOUS_TITLE = "#Criterious > label:nth-child(";
        private const int opNumber = 2;
        private const int dodNumber = 4;
        private const int changeCountNumber = 6;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.TableStyleId)]
        private IWebElement tableFunction;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.FastFunctionInputCss)]
        private IWebElement fastFunctionInput;
        [FindsBy(How=How.Id,Using = BaseSelectorValues.VectorPolId)]
        private IWebElement vectorPol;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.FastVectorInputCss)]
        private IWebElement fastVectorInput;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.CriteriousId)]
        private IWebElement criterious;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.BtnFindPolynomId)]
        private IWebElement btnFindPolynom;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.TitleResId)]
        private IWebElement titleRes;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.PolynomResId)]
        private IWebElement polynomRes;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.BullFunctionTitleCss)]
        private IWebElement cssBullFunctionTitle;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.BullFunctionTitleCss)]
        private IWebElement cssBullFunctionChangeTitle;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.KZFId)]
        private IWebElement kzf;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.FastFunctionLegendCss)]
        private IWebElement fastFunctionLegendCss;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.AllFunctionZeroId)]
        private IWebElement allFunctionZeroBtnId;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.AllFunctionOneId)]
        private IWebElement allFunctionOneBtnId;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.AllFunctionQuestionId)]
        private IWebElement allFunctionQuestionBtnId;
        [FindsBy(How = How.Id, Using = BaseSelectorValues.VectorPolLegendId)]
        private IWebElement vectorPolLegendId;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.FastVectorLegendCss)]
        private IWebElement fastVectorLegendCss;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.CriteriousLegendCss)]
        private IWebElement criteriousLegend;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.IncreaseChangeCountCss)]
        private IWebElement increaseChangeCountCss;
        [FindsBy(How = How.CssSelector, Using = BaseSelectorValues.DecreaseChangeCountCss)]
        private IWebElement decreaseChangeCountCss;


        public Polynom(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_WAITING));
        }
        public bool DisplayedTable()
        {

          return Displayed(tableFunction);
        }
        public bool DisplayedFastFunctionInput()
        {
            return Displayed(fastFunctionInput);
        }
        public bool DisplayedVectorPol()
        {
            return Displayed(vectorPol);
        }
        public bool DisplayedFastVectorInput()
        {
            return Displayed(fastVectorInput);
        }
        public bool DisplayedCriterious()
        {
            return Displayed(criterious);
        }
        public bool DisplayedBtnFind()
        {
            return Displayed(btnFindPolynom);
        }
        public bool DisplayedPolynomRes()
        {
            return Displayed(polynomRes);
        }
        public bool DisplayedTitleRes()
        {            
            return Displayed(titleRes);
        }
        private bool Displayed(IWebElement webElement)
        {
            return webElement.Displayed;
        }
        public string PolynomResValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.PolynomResId))).Text;
        }
        public string TitleResValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.TitleResId))).Text;
        }
        //private string GetValue(string webSelector,string attributeName)
        //{
        //   return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(webSelector))).GetAttribute(attributeName);            
        //}
        public string GetBullFunctionTitleValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(BaseSelectorValues.BullFunctionTitleCss))).Text;
        }
        public string GetBullFunctionChangeCountValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(BaseSelectorValues.ChangeCountTitleCss))).Text;
        }
        public string GetKzfValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.KZFId))).GetAttribute("value");
        }
        public bool EnabledKzfValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.KZFId))).Enabled;
        }
        public string GetCeilByIdValue(string id)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).GetAttribute("value");
        }
        public BoolFunctionValue GetTableValues()
        {
            int changeCount = Convert.ToInt32(GetKzfValue());
            int changeFunctionCount = Convert.ToInt32(Math.Pow(changeCount, 2));
            string beginIdTable = "Fzn";
            BoolFunctionValue boolFunction = new BoolFunctionValue();
            for(int i = 1; i <= changeFunctionCount; i++)
            {
                string id = beginIdTable + i;
                string ceilValue = GetCeilByIdValue(id);
                if (ceilValue == "0")
                {
                    boolFunction.zeroCount += 1;
                }
                else if(ceilValue == "1")
                {
                    boolFunction.oneCount += 1;
                }
                else
                {
                    boolFunction.questionsCount += 1;
                }
            }
            return boolFunction;
        }
        public bool AllFunctionZeroes()
        {
            int changeCount = Convert.ToInt32(GetKzfValue());
            BoolFunctionValue boolFunction = GetTableValues();
            return boolFunction.zeroCount == changeCount;
        }
        public bool AllFunctionOnes()
        {
            int changeCount = Convert.ToInt32(GetKzfValue());
            BoolFunctionValue boolFunction = GetTableValues();
            return boolFunction.oneCount == changeCount;
        }
        public bool AllFunctionQuestions()
        {
            int changeCount = Convert.ToInt32(GetKzfValue());
            BoolFunctionValue boolFunction = GetTableValues();
            return boolFunction.questionsCount == changeCount;
        }
        public string GetFastFunctionLegendTitle()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(BaseSelectorValues.FastFunctionLegendCss))).Text;
        }
        public string GetAllZeroFunctionValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllFunctionZeroId))).GetAttribute("value");
        }
        public string GetAllOneFunctionValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllFunctionOneId))).GetAttribute("value");
        }
        public string GetAllQuestionFunctionValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllFunctionQuestionId))).GetAttribute("value");
        }
        public string GetVectorPolLegendTitle()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(BaseSelectorValues.VectorPolLegendId))).Text;
        }
        public BoolFunctionValue GetVectorValues()
        {
            int changeCount = Convert.ToInt32(GetKzfValue());
            string beginIdTable = "vzn";
            BoolFunctionValue boolFunction = new BoolFunctionValue();
            for (int i = 1; i <= changeCount; i++)
            {
                string id = beginIdTable + i;
                string ceilValue = GetCeilByIdValue(id);
                if (ceilValue == "0")
                {
                    boolFunction.zeroCount += 1;
                }
                else if (ceilValue == "1")
                {
                    boolFunction.oneCount += 1;
                }
                else
                {
                    boolFunction.questionsCount += 1;
                }
            }
            return boolFunction;
        }
        public bool AllVectorZeroes()
        {
            int changeCount = Convert.ToInt32(GetKzfValue());
            BoolFunctionValue boolFunction = GetVectorValues();
            return boolFunction.zeroCount == changeCount;
        }
        public bool AllVectorOnes()
        {
            int changeCount = Convert.ToInt32(GetKzfValue());
            BoolFunctionValue boolFunction = GetVectorValues();
            return boolFunction.oneCount == changeCount;
        }
        public bool AllVectorQuestions()
        {
            int changeCount = Convert.ToInt32(GetKzfValue());
            BoolFunctionValue boolFunction = GetVectorValues();
            return boolFunction.questionsCount == changeCount;
        }

        public string GetFastVectorLegendTitle()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(BaseSelectorValues.FastVectorLegendCss))).Text;
        }
        public string GetAllZeroVectorValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllVectorZeroId))).GetAttribute("value");
        }
        public string GetAllOneVectorValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllVectorOneId))).GetAttribute("value");
        }
        public string GetAllQuestionVectorValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllVectorQuestionId))).GetAttribute("value");
        }
        public string GetCriteriousLegendTitle()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(BaseSelectorValues.CriteriousLegendCss))).Text;
        }
        public string GetOpCountTitle()
        {


            string opTitle = CRITERIOUS_TITLE+opNumber+")";
            Console.WriteLine(opTitle);
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(opTitle))).Text;
        }                                                                           
        public string GetAddCountTitle()
        {
            string addTitle = $"{CRITERIOUS_TITLE}{dodNumber})";
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(addTitle))).Text;
        }
        public string GetChangeCountTitle()
        {
            string changeTitle = $"{CRITERIOUS_TITLE}{changeCountNumber})";
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(changeTitle))).Text;
        }
        public bool IsSelectedMinOPCount()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.CriteriousMinOpCountId))).Selected;
        }
        public bool IsSelectedMinAddCount()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.CriteriousMinAddCountId))).Selected;
        }
        public void MinChangeCountClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.CriteriousMinChangeCountId))).Click();
        }
        public void MinOPCountClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.CriteriousMinOpCountId))).Click();
        }
        public void MinAddCountClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.CriteriousMinAddCountId))).Click();
        }
        public bool IsSelectedMinChangeCount()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.CriteriousMinChangeCountId))).Selected;
        }
        public string GetBtnFindPolynomValue()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.BtnFindPolynomId))).GetAttribute("value");
        }
        public bool EnabledBtnFindPolynom()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.BtnFindPolynomId))).Enabled;
        }
        public void FindPolynomClick()
        {
             wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.BtnFindPolynomId))).Click();
        }
        public void AllFunctionZeroClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllFunctionZeroId))).Click();
        }
        public void AllFunctionOneClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllFunctionOneId))).Click();
        }
        public void AllFunctionQuestionClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllFunctionQuestionId))).Click();
        }
        public void FirstSeilClick()
        {
            string firstCeilId = "Fzn1";
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(firstCeilId))).Click();
        }
        public string FirstSeilValue()
        {
           string firstCeilId = "Fzn1";
           return GetCeilByIdValue(firstCeilId);
        }
        public void AllVectorZeroClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllFunctionZeroId))).Click();
        }
        public void AllVectorOneClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllVectorOneId))).Click();
        }
        public void AllVectorQuestionClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(BaseSelectorValues.AllVectorQuestionId))).Click();
        }
        public void FirstSeilVectorClick()
        {
            string firstCeilId = "vzn1";
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(firstCeilId))).Click();
        }
        public string FirstSeilVectorValue()
        {
            string firstCeilId = "vzn1";
            return GetCeilByIdValue(firstCeilId);
        }
        public void SetOneToCeil(string idCeil)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCeil))).Click();

        }
        public void SetQuestionToCeil(string idCeil)
        {
            int number = 2;
            for(int i = 0; i < number; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCeil))).Click();
            }
        }
        public void SetZeroToCeil(string idCeil)
        {
            int number = 3;
            for (int i = 0; i < number; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCeil))).Click();
            }
        }
        public void IncreaseClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(BaseSelectorValues.IncreaseChangeCountCss))).Click();
        }
        public void DecreaseClick()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(BaseSelectorValues.DecreaseChangeCountCss))).Click();
        }
        public void SetExampleFunction()
        {
            string[] arrFunction = new string[] { "0", "0", "1", "?", "0", "1", "?", "1" };
            string[] arrVector = new string[] { "0", "?", "1"};
            int changeCount = arrVector.Length;
            string functionCeilId = "Fzn";
            string vectorCeilId = "vzn";
            for (int i = 0; i < changeCount - 1; i++)
            {
                IncreaseClick();
            }
            for (int i = 0; i < arrFunction.Length; i++)
            {
                string currentCeilId = $"{functionCeilId}{i + 1}";
                if (arrFunction[i] == "0")
                {
                    SetZeroToCeil(currentCeilId);
                }
                else if (arrFunction[i] == "1")
                {
                    SetOneToCeil(currentCeilId);
                }
                else
                {
                    SetQuestionToCeil(currentCeilId);
                }
            }
            for (int i = 0; i < arrVector.Length; i++)
            {
                string currentCeilId = $"{vectorCeilId}{i + 1}";
                if (arrVector[i] == "0")
                {
                    SetZeroToCeil(currentCeilId);
                }
                else if (arrVector[i] == "1")
                {
                    SetOneToCeil(currentCeilId);
                }
                else
                {
                    SetQuestionToCeil(currentCeilId);
                }
            }

        }

        //private string GetAttribute(By by, string attributeName)
        //{
        //    return wait.Until(ExpectedConditions.ElementIsVisible(by)).GetAttribute(attributeName);
        //}

    }
}
