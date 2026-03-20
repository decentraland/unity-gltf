using System;
using UnityEngine;

namespace GLTFast.Schema
{

    /// <summary>
    /// DCL spring bone joint extension data.
    /// Adds spring-bone simulation parameters to a node/bone.
    /// </summary>
    [Serializable]
    public class SpringBoneJoint
    {

        /// <summary>
        /// Extension version
        /// </summary>
        public int version = -1;

        /// <summary>
        /// Stiffness force for returning to the initial pose
        /// </summary>
        public float stiffness;

        /// <summary>
        /// Drag force for damping the spring motion
        /// </summary>
        public float drag;

        /// <summary>
        /// Gravity direction as [x, y, z]
        /// </summary>
        public float[] gravityDir;

        /// <summary>
        /// Gravity power applied to this joint
        /// </summary>
        public float gravityPower;

        /// <summary>
        /// Hit radius for collision detection
        /// </summary>
        public float hitRadius;

        /// <summary>
        /// Whether this joint is the root of a spring bone chain
        /// </summary>
        public bool isRoot;

        /// <summary>
        /// Gravity direction as a Unity Vector3
        /// </summary>
        public Vector3 GravityDir
        {
            get
            {
                if (gravityDir != null && gravityDir.Length >= 3)
                {
                    return new Vector3(gravityDir[0], gravityDir[1], gravityDir[2]);
                }
                return Vector3.down;
            }
            set => gravityDir = new[] { value.x, value.y, value.z };
        }

        internal void GltfSerialize(JsonWriter writer)
        {
            writer.AddObject();
            if (version >= 0)
            {
                writer.AddProperty("version", version);
            }
            writer.AddProperty("stiffness", stiffness);
            writer.AddProperty("drag", drag);
            if (gravityDir != null)
            {
                writer.AddArrayProperty("gravityDir", gravityDir);
            }
            writer.AddProperty("gravityPower", gravityPower);
            writer.AddProperty("hitRadius", hitRadius);
            if (isRoot)
            {
                writer.AddProperty("isRoot", true);
            }
            writer.Close();
        }
    }
}
