using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTDD.Core.Operation
{
    public interface IFrameOperation<T>
    {
        void SwitchToFrame(T identifier);

        void SwitchToFrameContainingText(string identifier);

        void SwitchToFrameByIndex(int index);
    }
}
