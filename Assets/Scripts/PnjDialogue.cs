using UnityEngine;
namespace JPO
{[CreateAssetMenu(fileName = "NewPNJialogue", menuName = "PNJ Dialogue")]
    public class PnjDialogue : ScriptableObject
    {
        public string pngName;
        public Sprite npcPortrait;
        public string[] dialogueLines;
        public bool[] autoProgressLines;
        public float autoProgressDelay = 1.5f;
        public float typingSpeed = 0.05f;
        public AudioClip voiceSound;
        public float voicePitch = 1f;

    }
}
