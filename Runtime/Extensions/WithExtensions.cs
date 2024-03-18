namespace UnityEngine.Extensions
{
    public static class WithExtensions
    {
        public static T With<T>(this T self, System.Action<T> action)
        {
            action?.Invoke(self);
            return self;
        }

        public static T With<T>(this T self, System.Action<T> action, bool when)
        {
            if (when) action?.Invoke(self);
            return self;
        }

        public static T With<T>(this T self, System.Action<T> action, System.Func<bool> when)
        {
            if (when()) action?.Invoke(self);
            return self;
        }

        public static T With<T>(this T self, System.Action<T> action, System.Func<T, bool> when)
        {
            if (when(self)) action?.Invoke(self);
            return self;
        }
    }
}