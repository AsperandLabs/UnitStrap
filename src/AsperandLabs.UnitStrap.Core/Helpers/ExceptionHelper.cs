using System;

namespace AsperandLabs.UnitStrap.Core.Helpers
{
    public static class ExceptionHelper
    {
        public static void ThrowInvalidOperation(string message)
        {
            throw new InvalidOperationException(message);
        }
    }
}