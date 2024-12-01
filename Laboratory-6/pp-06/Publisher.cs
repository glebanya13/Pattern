using System.Collections.Generic;
using System;

namespace Lab6Lib
{
    public class Publisher // издатель
    {
        private readonly string _eventName;
        private readonly List<ISubscriber> _subscribers;

        public Publisher(string eventname)
        {
            _eventName = eventname;
            _subscribers = new List<ISubscriber>();
        }

        public void subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public bool unsubscribe(ISubscriber subscriber)
        {
            return _subscribers.Remove(subscriber);
        }

        public int notify() // уведомить всех подписчиков
        {
            int count = 0;
            foreach (ISubscriber subscriber in _subscribers)
            {
                subscriber.update(_eventName);
                count++;
            }
            Console.WriteLine($"Количество уведомленых подписчиков на сообытие {_eventName} равно: {count}");
            return count;
        }
    }
}
