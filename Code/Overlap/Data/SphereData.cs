namespace UnityEngine.Extensions
{
    [System.Serializable]
    public class SphereData : BaseData
    {
        [SerializeField, Min(0.0f)] private float radius = 1.0f;
        
        public float Radius
        {
            get => radius;
            set
            {
                if (value < 0) return;
                radius = value;
            }
        }
    }
}