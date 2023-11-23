namespace UnityEngine.Extensions
{
    public static class NullCheckExtensions
    {
        public static void IfNotNull<T>(this T component, System.Action<T> ifNotNull) where T : UnityEngine.Object
        {
            if (component != null) ifNotNull?.Invoke(component);
        }

        public static T IfNotNull<T>(this T component, System.Func<T> ifNotNull) where T : UnityEngine.Object
        {
            return component != null ? ifNotNull?.Invoke() : component;
        }
        
        public static void IfNull<T>(this T component, System.Action<T> ifNull) where T : UnityEngine.Object
        {
            if (component == null) ifNull?.Invoke(component);
        }

        public static T IfNull<T>(this T component, System.Func<T> ifNull) where T : UnityEngine.Object
        {
            return component == null ? ifNull.Invoke() : component;
        }
    }
}