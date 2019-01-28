namespace ConsoleApplication1
{
    public interface IEventEmitter
    {
        void EmitEvent(Event @event);
    }
}