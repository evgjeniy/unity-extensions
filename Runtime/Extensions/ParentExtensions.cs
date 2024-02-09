namespace UnityEngine.Extensions
{
    public static class ParentExtensions
    {
        public static void SetParent(this GameObject target, GameObject parent) => target.transform.SetParent(parent.transform);
        public static void SetParent(this GameObject target, Component parent) => target.transform.SetParent(parent.transform);
        public static void SetParent(this Component target, GameObject parent) => target.transform.SetParent(parent.transform);
        public static void SetParent(this Component target, Component parent) => target.transform.SetParent(parent.transform);
        public static void SetParent(this Transform target, GameObject parent) => target.SetParent(parent.transform);
        public static void SetParent(this Transform target, Component parent) => target.SetParent(parent.transform);

        public static void ClearParent(this GameObject target) => target.transform.SetParent(null);
        public static void ClearParent(this Component target) => target.transform.SetParent(null);
        public static void ClearParent(this Transform target) => target.SetParent(null);

        public static void DetachChildren(this GameObject target) => target.transform.DetachChildren();
        public static void DetachChildren(this Component target) => target.transform.DetachChildren();
    }
}