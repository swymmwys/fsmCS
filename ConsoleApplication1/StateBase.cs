using System;
using System.Runtime.Remoting;

namespace ConsoleApplication1
{
    public abstract class StateBase<T>
    {
        protected readonly T Automaton;
        private readonly IEventEmitter _eventEmitter;

        protected StateBase(T automaton, IEventEmitter eventEmitter)
        {
            _eventEmitter = eventEmitter;
            Automaton = automaton;
        }

        protected void EmitEvent(Event e)
        {
            _eventEmitter.EmitEvent(e);
        }
    }
}