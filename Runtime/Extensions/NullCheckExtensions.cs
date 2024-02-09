namespace UnityEngine.Extensions
{
    public static class NullCheckExtensions
    {
        public static void IfNull<T>(this T component, System.Action<T> ifNull) where T : class
        {
            if (component is Object unityObject)
            {
                if (unityObject == null)
                {
                    ifNull.Invoke(component);
                }
            }
            else if (component == null)
            {
                ifNull.Invoke(component);
            }
        }

        public static void IfNotNull<T>(this T component, System.Action<T> ifNotNull) where T : class
        {
            if (component is Object unityObject)
            {
                if (unityObject != null)
                {
                    ifNotNull.Invoke(component);
                }
            }
            else if (component != null)
            {
                ifNotNull.Invoke(component);
            }
        }

        public static T IfNull<T>(this T component, System.Func<T> ifNull) where T : class
        {
            if (component is Object unityObject)
                return unityObject == null ? ifNull.Invoke() : component;

            return component == null ? ifNull.Invoke() : component;
        }

        public static T IfNotNull<T>(this T component, System.Func<T> ifNotNull) where T : class
        {
            if (component is Object unityObject)
                return unityObject == null ? component : ifNotNull.Invoke();

            return component != null ? ifNotNull.Invoke() : component;
        }
    }
}