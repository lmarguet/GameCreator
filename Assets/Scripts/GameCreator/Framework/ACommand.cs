namespace GameCreator.Framework
{
    public abstract class ACommand
    {
        public abstract void Execute ();
    }

    public abstract class ACommand<TIn>
    {
        public abstract void Execute (TIn data);
    }

    public abstract class ACommand<TIn,TOut>
    {
        public abstract TOut Execute (TIn data);
    }

    public abstract class ACommandWithReturnValue<TOut>
    {
        public abstract TOut Execute ();
    }
}