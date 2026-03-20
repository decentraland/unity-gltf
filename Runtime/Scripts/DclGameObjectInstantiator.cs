using GLTFast.Logging;
using UnityEngine;

namespace GLTFast
{
    /// <summary>
    /// Extends <see cref="GameObjectInstantiator"/> with DCL-specific extension handling,
    /// such as spring bone joints.
    /// </summary>
    public class DclGameObjectInstantiator : GameObjectInstantiator
    {
        public DclGameObjectInstantiator(
            IGltfReadable gltf,
            Transform parent,
            ICodeLogger logger = null,
            InstantiationSettings settings = null) : base(gltf, parent, logger, settings)
        {
        }

        public override void EndScene(uint[] rootNodeIndices)
        {
            base.EndScene(rootNodeIndices);
            
            AddSpringBoneJoints();
        }

        void AddSpringBoneJoints()
        {
            var nodes = m_Gltf.GetSourceRoot()?.nodes;
            if (nodes == null) return;

            for (uint i = 0; i < nodes.Length; i++)
            {
                var springBone = nodes[i].extensions?.DCL_spring_bone_joint;
                if (springBone == null) continue;

                if (!m_Nodes.TryGetValue(i, out var go)) continue;

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
}
