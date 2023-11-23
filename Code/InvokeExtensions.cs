namespace UnityEngine.Extensions
{
    public static class InvokeExtensions
    {
        public static void InvokeNextFrame<T>(this T context, System.Action<T> action) where T : MonoBehaviour
        {
            context.StartCoroutine(NextFrameCoroutine());
            return;

            System.Collections.IEnumerator NextFrameCoroutine()
            {
                yield return null;
                action?.Invoke(context);
            }
        }

        public static void InvokeDelayed<T>(this T context, System.Action<T> action, float delay) where T : MonoBehaviour
        {
            context.StartCoroutine(DelayedCoroutine());
            return;
            
            System.Collections.IEnumerator DelayedCoroutine()
            {
                yield return new WaitForSeconds(delay);
                action?.Invoke(context);
            }
        }
        
        public static T GetOrAddComponent<T>(this GameObject gameObject, System.Action<T> setupAction = null) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component == null) component = gameObject.AddComponent<T>();
            
            setupAction?.Invoke(component);
            return component;
        }

        public static void ForEach<T>(this System.Collections.Generic.IEnumerable<T> collection, System.Action<T> action)
        {
            if (action == null) return;
            
            foreach (var item in collection) 
                action.Invoke(item);
        }
    }
}