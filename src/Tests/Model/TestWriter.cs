using System;

namespace Tests.Model
{
    public interface ITestWriter
    {
        public void CanWrite();
    }

    public class TestWriter : ITestWriter
    {
        public void CanWrite()
        {
            Console.WriteLine("I can write text");

        }
    }
}
