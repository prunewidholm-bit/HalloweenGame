using UnityEngine;
using UnityEngine.InputSystem;

namespace JPO
{
    public class PnjInteraction : MonoBehaviour
    {
        [SerializeField] private PnjDialogue dialogue;
        [SerializeField] private DialogueManager dialogueManager;

        private bool playerNear;
        private bool alreadyTalked;

        private void Update()
        {
            if (playerNear && Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (!alreadyTalked && !dialogue.hasChoice)
                {
                    alreadyTalked = true;
                    dialogueManager.supectTalkedTo++;
                }
                dialogueManager.Interact(dialogue);
                Debug.Log("e");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerNear = true;
                Debug.Log("player dans le collider");
            }
        } 

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerNear = false;
                Debug.Log("player quitte le collider");
            }
        }   
    }
    
}
