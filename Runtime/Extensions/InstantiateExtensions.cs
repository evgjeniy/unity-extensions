namespace UnityEngine.Extensions
{
    public static class InstantiateExtensions
    {
        public static T Spawn<T>(this T prefab, Transform parent = null) where T : Object => Object.Instantiate(prefab, parent);
        public static T Spawn<T>(this T prefab, Vector3 position, Transform parent = null) where T : Object => Object.Instantiate(prefab, position, Quaternion.identity, parent);
        public static T Spawn<T>(this T prefab, Vector3 position, Quaternion quaternion, Transform parent = null) where T : Object => Object.Instantiate(prefab, position, quaternion, parent);

        public static void DestroyObject(this Component component, float delay = 0.0f) => Object.Destroy(component.gameObject, delay);
        public static void DestroyObject(this GameObject gameObject, float delay = 0.0f) => Object.Destroy(gameObject, delay);

        public static void DestroyComponent(this Component component, float delay = 0.0f) => Object.Destroy(component, delay);

        public static void TryDestroyComponent<T>(this GameObject gameObject, float delay = 0.0f)
        {
            if (gameObject.TryGetComponent<T>(out var result) && result is Component component) 
                Object.Destroy(component, delay);
        }
    }
}