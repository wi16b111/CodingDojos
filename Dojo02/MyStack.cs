using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo02
{

    class MyStack<T>
    {
        private MyContainer<T> stack = new MyContainer<T>();
        
        public void Push(T item)
        {
            if (item == null)
            {
                Console.WriteLine("Cannot push null item");
                return;
            }
            stack.container[stack.next++] = item;
            stack.Resize();
        }
        
        public T Pop()
        {
            if (stack.next == 0)
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            T item = stack.container[--stack.next];
            stack.Resize();
            return item;
        }

        public T Peek()
        {
            if (stack.next == 0)
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            return stack.container[stack.next - 1];
        }


        // Internal simulation of ArrayList

        private class MyContainer<T>
        {
            public T[] container;
            public int next = 0;

            public MyContainer() {

                this.container = new T[1];
                this.next = 0;
            }

            public void Resize()
            {
                if (next >= container.Length)
                {
                    T[] tmp = new T[next*2];
                    for (int i=0; i<next; i++)
                    {
                        tmp[i] = container[i];
                    }
                    container = tmp;
                }

                if (next <= container.Length / 2)
                {
                    T[] tmp = new T[next+1];
                    for (int i = 0; i < next; i++)
                    {
                        tmp[i] = container[i];
                    }
                    container = tmp;
                }
            }
        }
    }
}
