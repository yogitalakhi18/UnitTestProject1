using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTDD.Core.Operation
{
    public interface IWebOperation<T, R>
    {
        R WaitForElement(T t);

        void MoveToElement(T t);

        void ClickButton(T t);

        bool HasElement(T t);

        bool HasNoElementAsExpected(T t);

        void WaitForElementGone(T t);

        void HandledSleep(int sleepInSeconds);

        bool VerifyElementSelected(T t, bool selected);

        void ScrollToElementAndClick(T t);

        void ScrollToElement(T t);

        string GetTextFromElement(T by);

        void SelectRadioButtonByValue(T t, string ValueToSelect);

        int CountElements(T t, long waitTime);

        void SendValuesToWebElement(T t, string value);

        bool IsDisabled(T t);

        bool IsEnabled(T t);
    }
}
