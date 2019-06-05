using System.Collections;
using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

public class AIConfig : MonoBehaviour
{
    [SerializeField]
    public VoicePack voicePack;

    [SerializeField]
    private CharacterConfig characterConfig;

    private float walkSpeed;
    private float runSpeed;

    static readonly public float minTalkInterval = 10.0f;
    static readonly public float maxTalkInterval = 25.0f;
    enum CharacterConfig{ MaleBodyguard, FemaleJanitor }
    void Awake()
    {
        DynamicCharacterAvatar avatar = GetComponent<DynamicCharacterAvatar>();

        switch (characterConfig)
        {
            case CharacterConfig.FemaleJanitor:
                avatar.activeRace.name = "HumanFemale";
                voicePack = GameObject.Find("VoicePacks/FemaleJanitor").GetComponent<VoicePack>();
                break;
            case CharacterConfig.MaleBodyguard:
                avatar.activeRace.name = "HumanMale";
                voicePack = GameObject.Find("VoicePacks/MaleBodyguard").GetComponent<VoicePack>();
                break;
            default:
                Debug.Log("Please select character version first for your AI");
                break;
        }
    }


}
