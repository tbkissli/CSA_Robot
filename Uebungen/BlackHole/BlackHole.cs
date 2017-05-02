using System;

namespace BlackHole {

    class BlackHole {

        private NotifyingQueue<String> queue = new NotifyingQueue<String>();

        public void put(String thing) {
            lock (queue) { // nun funktioniert es da das lock zweimal vom gleichen Objekt ist (vorhin mit this statt queue)
                queue.enqueue(thing);
            }
        }
        public String get() {
            lock (queue) { // vorhin mit this
                return queue.dequeue();
            }
        }
    }
}
