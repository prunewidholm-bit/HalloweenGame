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
        [SerializeField] private TMP_Text nameText;

        [Header ("Fiche Perso")]
        [SerializeField] private GameObject sheetPanel;
        [SerializeField] private Image sheetPortrait;
        [SerializeField] private TMP_Text sheetName;
        [SerializeField] private TMP_Text sheetDescription;



        private PnjDialogue currentDialogue;
        private bool isOpen;
        private int linesIndex;
        public int supectTalkedTo;


        private void Start()
        {
            dialoguePanel.SetActive(false);
            choicesPanel.SetActive(false);
            sheetPanel.SetActive(false);
        }

        public void Interact(PnjDialogue dialogue)
        {
            if (!isOpen)
            {
                OpenDialogue(dialogue);
            }
            else if (!choicesPanel.activeSelf)
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
            if (currentDialogue.hasChoice && supectTalkedTo >= numberOfSupect)
            {
                dialogueText.text = currentDialogue.questionLine;
                choicesPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                dialogueText.text = currentDialogue.dialogueLines[0];
            }
            nameText.text = currentDialogue.pngName;

            dialoguePanel.SetActive(true);
            sheetPanel.SetActive(false);
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
               CloseDialogue();
               
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

        public void ShowSheet(PnjDialogue dialogue)
        { 
            if (!isOpen)
            {
                sheetPortrait.sprite = dialogue.npcPortrait;
                sheetName.text = dialogue.pngName;
                sheetDescription.text = dialogue.description;
                sheetPanel.SetActive(true);
            }
           

        }

        public void HideSheet()
        {
            sheetPanel.SetActive(false);
        }

    }
}
