using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo02
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("\n--------------------\nTesting with integers:\n--------------------\n");
            TestInt();
            Console.WriteLine("\n--------------------\nTesting with strings:\n--------------------\n");
            TestString();
            Console.WriteLine("\n--------------------\nTesting with objects:\n--------------------\n");
            TestObject();
            Console.WriteLine("\n--------------------\nTest completed\n--------------------\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            void TestInt()
            {
                MyStack<int> stack = new MyStack<int>();

                stack.Pop();                            // special case: empty stack
                stack.Peek();                           // special case: empty stack
                stack.Push(1);                          // filling stack
                stack.Push(2);                          // filling stack
                stack.Push(1);                          // filling stack
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                stack.Pop();                            // special case: empty stack
                stack.Peek();                           // special case: empty stack
            }

            void TestString()
            {
                MyStack<string> stack = new MyStack<string>();

                stack.Pop();                            // special case: empty stack
                stack.Peek();                           // special case: empty stack
                stack.Push(null);                       // special case: pushing null value
                stack.Push("one");                      // filling stack
                stack.Push("two");                      // filling stack
                stack.Push("three");                    // filling stack
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                stack.Pop();                            // special case: empty stack
                stack.Peek();                           // special case: empty stack
            }

            void TestObject()
            {

                TestObject one = new TestObject("object one");
                TestObject two = new TestObject("object two");
                TestObject three = new TestObject("object three");

                MyStack<Object> stack = new MyStack<Object>();

                stack.Pop();                            // special case: empty stack
                stack.Peek();                           // special case: empty stack
                stack.Push(null);                       // special case: pushing null value
                stack.Push(one);                        // filling stack
                stack.Push(two);                        // filling stack
                stack.Push(three);                      // filling stack
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                Console.WriteLine(stack.Peek());        // checking current value
                Console.WriteLine(stack.Pop());         // removing value
                stack.Pop();                            // special case: empty stack
                stack.Peek();                           // special case: empty stack
            }
        }
    }

    public class TestObject
    {
        string value;

        public TestObject(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return this.value;
        }
    }

}
