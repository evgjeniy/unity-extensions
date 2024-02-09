namespace UnityEngine.Extensions
{
    [System.Serializable]
    public class RayData : BaseData
    {
        [SerializeField] private Vector3 _direction = Vector3.forward;
        [SerializeField, Min(0.0f)] private float _maxDistance;

        public Vector3 Direction
        {
            get => (Root == null ? _direction : Root.rotation * _direction).normalized;
            set => _direction = value.normalized;
        }

        public float MaxDistance
        {
            get => _maxDistance;
            set
            {
                if (value < 0) return;
                _maxDistance = value;
            }
        }
    }
}