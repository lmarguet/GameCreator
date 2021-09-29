using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Framework
{
    public abstract class AAsyncCommand
    {
        bool isRunning;

        public async Task Run()
        {
            if (!isRunning)
            {
                isRunning = true;
                await DoRun();
                isRunning = false;
            }
            else
            {
                Debug.LogWarning($"Trying to start command {GetType()} more than once!");
            }
        }

        protected abstract Task DoRun();
    }

    public abstract class AAsyncCommand<TIn>
    {
        bool isRunning;

        public async Task Run(TIn data)
        {
            if (!isRunning)
            {
                isRunning = true;
                await DoRun(data);
                isRunning = false;
            }
            else
            {
                Debug.LogWarning($"Trying to start command {GetType()} more than once!");
            }
        }

        protected abstract Task DoRun(TIn data);
    }

    public abstract class AAsyncCommand<TIn, TOut>
    {
        bool isRunning;

        public async Task<TOut> Run(TIn data)
        {
            if (!isRunning)
            {
                isRunning = true;
                var result = await DoRun(data);
                isRunning = false;
                return result;
            }

            Debug.LogWarning($"Trying to start command {GetType()} more than once!");
            return default(TOut);
        }

        protected abstract Task<TOut> DoRun(TIn data);
    }

    public abstract class AAsyncCommandWithReturnValue<TOut>
    {
        bool isRunning;

        public async Task<TOut> Run()
        {
            if (!isRunning)
            {
                isRunning = true;
                var result = await DoRun();
                isRunning = false;
                return result;
            }

            Debug.LogWarning($"Trying to start command {GetType()} more than once!");
            return default;
        }

        protected abstract Task<TOut> DoRun();
    }
}