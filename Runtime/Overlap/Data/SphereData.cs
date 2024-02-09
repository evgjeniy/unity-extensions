namespace UnityEngine.Extensions
{
    [System.Serializable]
    public class SphereData : BaseData
    {
        [SerializeField, Min(0.0f)] private float _radius = 1.0f;

        public float Radius
        {
            get => _radius;
            set
            {
                if (value < 0) return;
                _radius = value;
            }
        }
    }
}