using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
    
[RequireComponent(typeof(Noise))] 
public class ETIFirstPersonController : FirstPersonController
{
    protected Noise m_Noise;
    private const float WALK_NOISE_RADIUS = 4f;
    private const float RUN_NOISE_RADIUS = 12f;
    private const float JUMP_NOISE_RADIUS = 10f;
    private const float LAND_NOISE_RADIUS = 14f;


    private void Awake()
    {
        m_Noise = GetComponent<Noise>();
    }

    override protected void PlayFootStepAudio()
    {
        if (!m_CharacterController.isGrounded)
        {
            return;
        }
        if (m_IsWalking)
        {
            m_AudioSource.volume = 0.05f;
            m_Noise.MakeNoise(WALK_NOISE_RADIUS);
        }
        else
        {
            m_AudioSource.volume = 0.1f;
            m_Noise.MakeNoise(RUN_NOISE_RADIUS);
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }

    override protected void PlayJumpSound()
    {
        m_Noise.MakeNoise(JUMP_NOISE_RADIUS);
        m_AudioSource.volume = 0.15f;
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }

    override protected void PlayLandingSound()
    {
        m_Noise.MakeNoise(LAND_NOISE_RADIUS);
        m_AudioSource.volume = 0.15f;
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
        m_NextStep = m_StepCycle + .5f;
    }
}
