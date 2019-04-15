using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace WpfAppUI.Services
{
    public class OverrideCursor : IDisposable
    {
        static Stack<Cursor> s_Stack = new Stack<Cursor>();

        public OverrideCursor(Cursor changeToCursor)
        {
            s_Stack.Push(changeToCursor);

            if (Mouse.OverrideCursor != changeToCursor)
                Mouse.OverrideCursor = changeToCursor;
        }

        public void Dispose()
        {
            s_Stack.Pop();

            Cursor cursor = s_Stack.Count > 0 ? s_Stack.Peek() : null;

            if (cursor != Mouse.OverrideCursor)
                Mouse.OverrideCursor = cursor;
        }

        public static OverrideCursor GetWaitOverrideCursor()
        {
            return new OverrideCursor(Cursors.Wait);
        }

    }
}
