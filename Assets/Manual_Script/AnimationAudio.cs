using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationAudio : MonoBehaviour {
    [SerializeField] public Sounds[] GunSounds;

    [System.Serializable]
    public class Sounds
    {
        public AudioClip Audio;
        public GameObject TriggerObject;
        public bool isOneShot;
        [System.NonSerialized]
        public bool isObjectAlreadyActive;
    }

    AudioSource[] aud;
    GameObject[] SoundPlayObject;

    // Use this for initialization
    void Start () {
        SoundPlayObject = new GameObject[GunSounds.Length];//配列の数だけPlayObjectを生成｡
        aud = new AudioSource[GunSounds.Length]; //オーディオ数の初期化

        int ArrayNum = 0; //配列子を0
        foreach (Sounds _sound in GunSounds) {
            SoundPlayObject[ArrayNum] = new GameObject("SoundList" + ArrayNum);
             aud[ArrayNum] = SoundPlayObject[ArrayNum].AddComponent<AudioSource>();//SoundPlayObjにオーディオソースをくっつける
            aud[ArrayNum].clip = _sound.Audio;
            ArrayNum++;
        }
	}

    // Update is called once per frame
    void Update()
    {
        int ArrayNum = 0; //配列子を0
        foreach (Sounds _sound in GunSounds)
        {
            if (_sound.TriggerObject.activeSelf == true)
            {
                if (_sound.isObjectAlreadyActive != true)
                {
                    _sound.isObjectAlreadyActive = true;
                    if (_sound.isOneShot == false)
                    {
                        aud[ArrayNum].Play();
                    }
                    else
                    {
                        aud[ArrayNum].PlayOneShot(aud[ArrayNum].clip);
                    }
                }
            }
            else {
                _sound.isObjectAlreadyActive = false;
            }
            ArrayNum++;
        }
    }
}
