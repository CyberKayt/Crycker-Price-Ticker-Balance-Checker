using System;

namespace Crycker.Types
{
    public class IntEventArgs : EventArgs
    {
        public int Value { get; private set; }

        public IntEventArgs(int value)
        {
            Value = value;
        }
    }
}
