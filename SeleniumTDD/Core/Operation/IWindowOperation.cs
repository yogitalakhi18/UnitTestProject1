using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTDD.Core.Operation
{
    public interface IWindowOperation
    {
        void SwitchToLastTab();

        void SwitchToFirstTab();

        void CloseTab();

        void WaitTillMultipleTabOpens();
    }
}
