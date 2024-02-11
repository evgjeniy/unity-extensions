namespace UnityEngine.Extensions
{
    public abstract class MonoCashed<T> : MonoCashed
    {
        public T Cashed1 { get; private set; }
        protected override void Awake() { Cashed1 = GetComponent<T>(); base.Awake(); }
    }

    public abstract class MonoCashed<T1, T2> : MonoCashed<T1>
    {
        public T2 Cashed2 { get; private set; }
        protected override void Awake() { Cashed2 = GetComponent<T2>(); base.Awake(); }
    }

    public abstract class MonoCashed<T1, T2, T3> : MonoCashed<T1, T2>
    {
        public T3 Cashed3 { get; private set; }
        protected override void Awake() { Cashed3 = GetComponent<T3>(); base.Awake(); }
    }

    public abstract class MonoCashed<T1, T2, T3, T4> : MonoCashed<T1, T2, T3>
    {
        public T4 Cashed4 { get; private set; }
        protected override void Awake() { Cashed4 = GetComponent<T4>(); base.Awake(); }
    }

    public abstract class MonoCashed<T1, T2, T3, T4, T5> : MonoCashed<T1, T2, T3, T4>
    {
        public T5 Cashed5 { get; private set; }
        protected override void Awake() { Cashed5 = GetComponent<T5>(); base.Awake(); }
    }

    public abstract class MonoCashed<T1, T2, T3, T4, T5, T6> : MonoCashed<T1, T2, T3, T4, T5>
    {
        public T6 Cashed6 { get; private set; }
        protected override void Awake() { Cashed6 = GetComponent<T6>(); base.Awake(); }
    }

    public abstract class MonoCashed<T1, T2, T3, T4, T5, T6, T7> : MonoCashed<T1, T2, T3, T4, T5, T6>
    {
        public T7 Cashed7 { get; private set; }
        protected override void Awake() { Cashed7 = GetComponent<T7>(); base.Awake(); }
    }

    public abstract class MonoCashed<T1, T2, T3, T4, T5, T6, T7, T8> : MonoCashed<T1, T2, T3, T4, T5, T6, T7>
    {
        public T8 Cashed8 { get; private set; }
        protected override void Awake() { Cashed8 = GetComponent<T8>(); base.Awake(); }
    }
}