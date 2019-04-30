using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BehavioralPatterns
{
    internal class StartObserver
    {
        public void PullStart ()
        {
            ConcretePublisherPull subject = new ConcretePublisherPull ();
            subject.Subscribe (new ConcreteSubscriberPull (subject));
            subject.Subscribe (new ConcreteSubscriberPull (subject));
            subject.State = "State...";
            subject.Notify ();
        }

        public void PushStart ()
        {

            ConcretePublisherPush subject = new ConcretePublisherPush ();
            subject.Subscribe (new ConcreteSubscriberPush (subject));
            subject.Subscribe (new ConcreteSubscriberPush (subject));
            subject.State = "State...";
            subject.Notify ();
        }
    }

    #region Pull Example

    public abstract class SubscriberPull
    {
        public abstract void Update ();
    }

    public abstract class PublisherPull
    {
        private ArrayList subscribers = new ArrayList ();

        public void Subscribe (SubscriberPull observer)
        {
            subscribers.Add (observer);
        }

        public void Unsubscribe (SubscriberPull observer)
        {
            subscribers.Remove (observer);
        }

        public void Notify ()
        {
            foreach (SubscriberPull observer in subscribers)
            {
                observer.Update ();
            }
        }
    }

    public class ConcretePublisherPull : PublisherPull
    {
        public string State { get; set; }
    }

    public class ConcreteSubscriberPull : SubscriberPull
    {
        private string subscriberState;
        private readonly ConcretePublisherPull publisher;

        public ConcreteSubscriberPull (ConcretePublisherPull subject)
        {
            this.publisher = subject;
        }

        public override void Update ()
        {
            subscriberState = publisher.State;
        }
    }

    #endregion

    #region Push Example

    abstract class SubscriberPush
    {
        public abstract void Update (string state);
    }

    abstract class PublisherPush
    {
        private ArrayList subscribers = new ArrayList ();

        public virtual string State { get; set; }

        public void Subscribe (SubscriberPush observer)
        {
            subscribers.Add (observer);
        }

        public void Unsubscribe (SubscriberPush observer)
        {
            subscribers.Remove (observer);
        }

        public void Notify ()
        {
            foreach (SubscriberPush subscriber in subscribers)
            {
                subscriber.Update (State);
            }
        }
    }

    class ConcretePublisherPush : PublisherPush
    {
        public override string State { get; set; }
    }

    class ConcreteSubscriberPush : SubscriberPush
    {
        private string subscriberState;
        private ConcretePublisherPush concretePublisher;

        public ConcreteSubscriberPush (ConcretePublisherPush subject)
        {
            concretePublisher = subject;
        }

        public override void Update (string state)
        {
            subscriberState = state;
        }
    }

    #endregion
}