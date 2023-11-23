namespace UnityEngine.Extensions
{
    public static class EnableExtensions
    {
        public static void Activate(this GameObject gameObject) => gameObject.SetActive(true);
        public static void Activate(this Component component) => component.gameObject.SetActive(true);

        public static void Deactivate(this GameObject gameObject) => gameObject.SetActive(false);
        public static void Deactivate(this Component component) => component.gameObject.SetActive(false);

        public static void Enable(this Behaviour behaviour) => behaviour.enabled = true;
        public static void Enable(this Collider collider) => collider.enabled = true;
        public static void Enable(this Renderer renderer) => renderer.enabled = true;
        public static void Enable(this Cloth cloth) => cloth.enabled = true;
        public static void Enable(this AnimationState animationState) => animationState.enabled = true;
        public static void Enable(this LODGroup lodGroup) => lodGroup.enabled = true;

        public static void Disable(this Behaviour behaviour) => behaviour.enabled = false;
        public static void Disable(this Collider collider) => collider.enabled = false;
        public static void Disable(this Renderer renderer) => renderer.enabled = false;
        public static void Disable(this Cloth cloth) => cloth.enabled = false;
        public static void Disable(this AnimationState animationState) => animationState.enabled = false;
        public static void Disable(this LODGroup lodGroup) => lodGroup.enabled = false;
    }
}