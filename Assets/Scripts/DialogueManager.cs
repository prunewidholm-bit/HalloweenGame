using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JPO
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private Image npcPortrait;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private PlayerController player;
        [SerializeField] private GameObject choicesPanel;
        [SerializeField] private int numberOfSupect = 6;



        private PnjDialogue currentDialogue;
        private bool isOpen;
        private int linesIndex;
        public int supectTalkedTo;


        private void Start()
        {
            dialoguePanel.SetActive(false);
            choicesPanel.SetActive(false);
        }

        public void Interact(PnjDialogue dialogue)
        {
            if (!isOpen)
            {
                OpenDialogue(dialogue);
            }
            else
            {
                NextLines();
            }
        }

        private void OpenDialogue(PnjDialogue dialogue)
        {
            currentDialogue = dialogue;
            isOpen = true;
            linesIndex = 0;

            npcPortrait.sprite = currentDialogue.npcPortrait;
            dialogueText.text = currentDialogue.dialogueLines[0];

            dialoguePanel.SetActive(true);
            player.DisableInput();

        }

        private void NextLines()
        {
            linesIndex++;

            if (linesIndex<currentDialogue.dialogueLines.Length)
            {
                dialogueText.text = currentDialogue.dialogueLines[linesIndex];
            }
            else
            {
               if (currentDialogue.hasChoice && supectTalkedTo >= numberOfSupect)
               {
                    choicesPanel.SetActive(true);
               }
               else
               {
                    CloseDialogue();
               }
            }
        }

        public void Choices(int number)
        {
            if (number == currentDialogue.guiltyNumber)
            {
                SceneManager.LoadScene(currentDialogue.winScene);
            }
            else
            {
                SceneManager.LoadScene(currentDialogue.loseScene);
            }
        }

        private void CloseDialogue()
        {
            isOpen = false;
            dialoguePanel.SetActive(false);
            player.EnableInput();

        }

    }
}
