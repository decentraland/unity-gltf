using System.Collections.Generic;
using GLTFast.Schema;
using UnityEngine;

namespace GLTFast
{
    /// <summary>
    /// Utility for applying DCL spring bone joint data to GameObjects.
    /// </summary>
    public static class SpringBoneUtils
    {
        /// <summary>
        /// Applies spring bone joint components using the instantiator's node mapping.
        /// </summary>
        public static void ApplySpringBoneJoints(IGltfReadable gltf, Dictionary<uint, GameObject> nodes)
        {
            foreach (var kvp in nodes)
            {
                var node = gltf.GetSourceNode((int)kvp.Key);
                var springBone = node?.Extensions?.DCL_spring_bone_joint;
                if (springBone == null) continue;

                ApplySpringBone(kvp.Value, springBone);
            }
        }
        
        /// <summary>
        /// Applies spring bone joint components by matching node names in the scene hierarchy.
        /// </summary>
        public static void ApplySpringBoneJoints(IGltfReadable gltf, GameObject sceneRoot)
        {
            var transforms = sceneRoot.GetComponentsInChildren<Transform>(true);
            var nameToTransform = new Dictionary<string, Transform>();
            foreach (var t in transforms)
                nameToTransform.TryAdd(t.name, t);

            for (int i = 0; ; i++)
            {
                var node = gltf.GetSourceNode(i);
                if (node == null) break;

                var springBone = node.Extensions?.DCL_spring_bone_joint;
                if (springBone == null) continue;

                var nodeName = node.name ?? $"Node-{i}";
                if (!nameToTransform.TryGetValue(nodeName, out var transform)) continue;

                ApplySpringBone(transform.gameObject, springBone);
            }
        }
        
        static void ApplySpringBone(GameObject go, SpringBoneJoint springBone)
        {
            var component = go.AddComponent<SpringBoneJointComponent>();
            component.Stiffness = springBone.stiffness;
            component.Drag = springBone.drag;
            component.GravityDir = springBone.GravityDir;
            component.GravityPower = springBone.gravityPower;
            component.HitRadius = springBone.hitRadius;
            component.IsRoot = springBone.isRoot;
        }
    }
}
