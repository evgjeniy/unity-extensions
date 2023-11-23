namespace UnityEngine.Extensions
{
    [System.Serializable]
    public class RayData : BaseData
    {
        [SerializeField] private Vector3 direction = Vector3.forward;
        [SerializeField, Min(0.0f)] private float maxDistance;

        public Vector3 Direction
        {
            get => (Root == null ? direction : Root.rotation * direction).normalized;
            set => direction = value.normalized;
        }

        public float MaxDistance
        {
            get => maxDistance;
            set
            {
                if (value < 0) return;
                maxDistance = value;
            }
        }
    }
}