namespace MyMovieApp.Helpers
{
    internal class AsyncHelper<T>
    {
        internal delegate void OnStartedEventHandler();
        internal delegate void OnCompletedEventHandler(T result);
        internal event OnStartedEventHandler OnStarted;
        internal event OnCompletedEventHandler OnCompleted;
        protected void Started() => OnStarted?.Invoke();
        protected void Completed(T result) => OnCompleted?.Invoke(result);
    }
}
