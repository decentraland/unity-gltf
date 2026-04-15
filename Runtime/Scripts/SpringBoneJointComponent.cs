using UnityEngine;

namespace GLTFast
{
    /// <summary>
    /// Holds DCL spring bone joint data parsed from a glTF node extension.
    /// </summary>
    public class SpringBoneJointComponent : MonoBehaviour
    {
        [field: SerializeField] public float Stiffness { get; set; }
        [field: SerializeField] public float Drag { get; set; }
        [field: SerializeField] public Vector3 GravityDir { get; set; }
        [field: SerializeField] public float GravityPower { get; set; }
        [field: SerializeField] public float HitRadius { get; set; }
        [field: SerializeField] public bool IsRoot { get; set; }
    }
}
