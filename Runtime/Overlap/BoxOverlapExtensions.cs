namespace UnityEngine.Extensions
{
    public static class BoxOverlapExtensions
    {
        public static bool Check(this BoxData box, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.CheckBox
        (
            box.Center, box.Size / 2.0f, box.Orientation, box.LayerMask.value, qti
        );

        public static bool Check(this BoxData box, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.CheckBox
        (
            box.Center, box.Size / 2.0f, box.Orientation, mask.value, qti
        );

        public static Collider[] Overlap(this BoxData box, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.OverlapBox
        (
            box.Center, box.Size / 2.0f, box.Orientation, box.LayerMask.value, qti
        );

        public static Collider[] Overlap(this BoxData box, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.OverlapBox
        (
            box.Center, box.Size / 2.0f, box.Orientation, mask.value, qti
        );

        public static int OverlapNonAlloc(this BoxData box, Collider[] colliders, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.OverlapBoxNonAlloc
        (
            box.Center, box.Size / 2.0f, colliders, box.Orientation, box.LayerMask.value, qti
        );

        public static int OverlapNonAlloc(this BoxData box, Collider[] colliders, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.OverlapBoxNonAlloc
        (
            box.Center, box.Size / 2.0f, colliders, box.Orientation, mask.value, qti
        );

        public static bool Cast(this BoxData box, Vector3 direction, out RaycastHit hit, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.BoxCast
        (
            box.Center, box.Size / 2.0f, direction, out hit, box.Orientation, direction.magnitude, box.LayerMask.value, qti
        );

        public static bool Cast(this BoxData box, Vector3 direction, out RaycastHit hit, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.BoxCast
        (
            box.Center, box.Size / 2.0f, direction, out hit, box.Orientation, direction.magnitude, mask.value, qti
        );

        public static RaycastHit[] CastAll(this BoxData box, Vector3 direction, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.BoxCastAll
        (
            box.Center, box.Size / 2.0f, direction, box.Orientation, direction.magnitude, box.LayerMask.value, qti
        );

        public static RaycastHit[] CastAll(this BoxData box, Vector3 direction, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.BoxCastAll
        (
            box.Center, box.Size / 2.0f, direction, box.Orientation, direction.magnitude, mask.value, qti
        );

        public static int CastAllNonAlloc(this BoxData box, Vector3 direction, RaycastHit[] hits, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.BoxCastNonAlloc
        (
            box.Center, box.Size / 2.0f, direction, hits, box.Orientation, direction.magnitude, box.LayerMask.value, qti
        );

        public static int CastAllNonAlloc(this BoxData box, Vector3 direction, RaycastHit[] hits, LayerMask mask, QueryTriggerInteraction qti = QueryTriggerInteraction.UseGlobal) => Physics.BoxCastNonAlloc
        (
            box.Center, box.Size / 2.0f, direction, hits, box.Orientation, direction.magnitude, mask.value, qti
        );
    }
}