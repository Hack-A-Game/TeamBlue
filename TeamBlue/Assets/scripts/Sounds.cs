using UnityEngine;
using System.Collections;
using System;

namespace Completed
{
    public class Sounds : MonoBehaviour
    {

        public GameController controller;

        public AudioSource fight;
        public AudioSource finalmonster;
        public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
        public static Sounds instance = null;     //Allows other scripts to call functions from SoundManager.             
        public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
        public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
        public AudioClip sf;
        public AudioClip sfm;
        public AudioClip sms;


        void Awake()
        {
            this.ChargeClips();
            //Check if there is already an instance of SoundManager
            if (instance == null)
                //if not, set it to this.
                instance = this;
            //If instance already exists:
            else if (instance != this)
                //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
                Destroy(gameObject);

            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad(gameObject);
        }

        private void ChargeClips()
        {
            
        }


        //Used to play single sound clips.
        public void PlayFinalMonster(AudioClip clip)
        {
            //Set the clip of our efxSource audio source to the clip passed in as a parameter.
            finalmonster.clip = clip;

            //Play the clip.
            finalmonster.Play();
        }
        //Used to play single sound clips.
        public void PlayFight(AudioClip clip)
        {
            //Set the clip of our efxSource audio source to the clip passed in as a parameter.
            fight.clip = clip;

            //Play the clip.
            fight.Play();
        }



    }
}