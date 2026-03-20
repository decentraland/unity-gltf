using UnityEngine;

namespace GLTFast
{
    /// <summary>
    /// Holds DCL spring bone joint data parsed from a glTF node extension.
    /// </summary>
    public class SpringBoneJointComponent : MonoBehaviour
    {
        public float Stiffness { get; set; }
        public float Drag { get; set; }
        public Vector3 GravityDir { get; set; }
        public float GravityPower { get; set; }
        public float HitRadius { get; set; }
        public bool IsRoot { get; set; }
    }
}
