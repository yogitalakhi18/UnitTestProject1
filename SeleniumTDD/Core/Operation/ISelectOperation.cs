using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTDD.Core.Operation
{
    public interface ISelectOperation<T>
    {
        void SelectItemByValue(T t, string itemToSelect);

        void SelectItemByText(T t, string text);

        void SelectItemByIndex(T t, int index);
    }
}
