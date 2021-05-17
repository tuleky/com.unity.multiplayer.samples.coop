using System;
using MLAPI;
using MLAPI.NetworkVariable;
using UnityEngine;

namespace BossRoom
{
    /// <summary>
    /// NetworkBehaviour containing only one NetworkVariable which represents this character's CharacterType.
    /// </summary>
    public class NetworkCharacterTypeState : NetworkBehaviour
    {
        [Tooltip("NPCs should set this value in their prefab. For players, this value is set at runtime.")]
        public CharacterClass NpcClass;

        NetworkVariable<int> m_CharacterTypeRuntimeID = new NetworkVariable<int>();

        public NetworkVariable<int> CharacterTypeRuntimeID
        {
            get
            {
                if (m_CharacterTypeRuntimeID.Value == 0)
                {
                    // this is npc
                    m_CharacterTypeRuntimeID.Value = NpcClass.GetInstanceID();
                    return m_CharacterTypeRuntimeID;
                }
                return m_CharacterTypeRuntimeID;
            }
            set => m_CharacterTypeRuntimeID = value;
        }
    }
}
