// Observer Pattern: Defines a one-to-many dependency between objects, so that when one object changes its state, all its registered dependent objects are automatically notified and updated. 
// One object maintains a list of other objects that are interested in its changes. Whenever something happens to the main object, it notifies all the registered objects.
//Common Use Cases: Notification systems, event handling, stock price updates, UI event listeners, and publish-subscribe systems.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.BehavioralPatterns
{
    // 1. Observer Interface
    public interface IObserver
    {
        void Update(string videoTitle);
    }

    // 2. Subject Interface
    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void NotifyObservers();
    }

    // 3. Concrete Subject
    public class YouTubeChannel : ISubject
    {
        private readonly List<IObserver> _subscribers = new List<IObserver>();

        private string _latestVideo;

        public void Subscribe(IObserver observer)
        {
            ArgumentNullException.ThrowIfNull(observer);

            if (!_subscribers.Contains(observer))
            {
                _subscribers.Add(observer);
                Console.WriteLine("A new subscriber has joined the channel.");
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            if (_subscribers.Remove(observer))
            {
                Console.WriteLine("A subscriber has left the channel.");
            }
        }

        public void UploadVideo(string videoTitle)
        {
            _latestVideo = videoTitle;

            Console.WriteLine($"\nNew video uploaded: {_latestVideo}");

            NotifyObservers();
        }

        public void NotifyObservers()
        {
            //Create a snapshot to safely iterate even if the subscriber list changes.
            foreach (IObserver observer in _subscribers.ToList())
            {
                observer.Update(_latestVideo);
            }
        }
    }

    // 4. Concrete Observer 1
    public class Subscriber : IObserver
    {
        private readonly string _name;
        public Subscriber(string name)
        {
            _name = name;
        }

        public void Update(string videoTitle)
        {
            Console.WriteLine($"{_name} received notification: New Video - {videoTitle}");
        }
    }

    // 5. Program Entry Point
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create YouTube Channel (Subject)
            YouTubeChannel channel = new YouTubeChannel();

            //Create Subscribers (Observers)
            IObserver subscriber1 = new Subscriber("Rohit");
            IObserver subscriber2 = new Subscriber("Virat");
            IObserver subscriber3 = new Subscriber("Rahul");

            //Subscribers users to the channel
            channel.Subscribe(subscriber1);
            channel.Subscribe(subscriber2);
            channel.Subscribe(subscriber3);

            // Upload first video
            channel.UploadVideo("Introduction to C#");

            // Uplload second video
            channel.UploadVideo("Understanding Desing Patterns.");
        }
    }
}