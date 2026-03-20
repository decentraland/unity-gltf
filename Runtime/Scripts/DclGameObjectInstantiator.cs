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

            SpringBoneUtils.ApplySpringBoneJoints(m_Gltf, m_Nodes);
        }
    }
}
