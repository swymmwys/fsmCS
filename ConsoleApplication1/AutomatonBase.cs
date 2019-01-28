using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class AutomatonBase<T> : IEventEmitter
    {
        protected T CurrentState;
        private readonly Dictionary<T, Dictionary<Event, T>> _transitions = new Dictionary<T, Dictionary<Event, T>>();

        protected void AddTransition(T @from, Event @event, T to)
        {
            _transitions.TryGetValue(@from, out var transition);

            if (transition == null)
            {
                transition = new Dictionary<Event, T>();
                _transitions.Add(@from, transition);
            }

            transition.Add(@event, to);
        }

        public virtual void EmitEvent(Event @event)
        {
            _transitions.TryGetValue(CurrentState, out var transition);
            
            if (transition != null)
            {
                transition.TryGetValue(@event, out CurrentState);
            }
            else
            {
                throw new Exception("Transition is not defined");
            }
        }
    }
}