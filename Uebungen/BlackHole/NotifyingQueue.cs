using System.Threading;

namespace BlackHole {

    class NotifyingQueue<T> {

        private const int SIZE = 10;
        private T[] queue = new T[SIZE];
        private int head = 0;
        private int tail = 0;
        public void enqueue(T item) {
            lock (this) {
                head++;
                head %= SIZE;
                queue[head] = item;
                Monitor.Pulse(this);
            }
        }
        public T dequeue() {
            lock (this) {
                if (head == tail) {
                    Monitor.Wait(this);
                }
                tail++;
                tail %= SIZE;
                return queue[tail];
            }
        }
    }
}
