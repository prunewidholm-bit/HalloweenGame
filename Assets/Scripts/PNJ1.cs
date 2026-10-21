using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

namespace JPO
{
    public class PNJ1 : MonoBehaviour IInteractable
    {
      public PnjDialogue dialogueData;
      public GameObject dialoguePanel;
      public TMP_Text dialogueText, nameText;
      public Image portraitImage;

      private int dialogueIndex;
      private bool isTyping, isDialogueActive;

      public bool CanInteract()
      {
        return !isDialogueActive;
      }

      public void Interact()
      {
        if(dialogueData == null || (PauseController.IsGame && !isDialogueActive))
        return;

        if (isDialogueActive)
        {
          NextLine();
        }
        else
        {
          StarDialogue();
        }
      }
      void StarDialogue()
      {
        isDialogueActive = true;
        dialogueIndex = 0

        nameText.SetText(dialogueData.name);
        portraitImage.sprite = dialogueData.pnjPortrait;

        dialoguePanel.SetActive(true);
        pauseController.SetPause(true);

        StarCoroutine(TypeLine());

        void NextLine()
        {
          if (isTyping)
          {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
          }
          else if(++dialogueIndex < dialogueData. dialogueLines.Length)
          {
            StarCoroutine(TypeLine());
          }
          else
          {
            EndDialogue();
          }
        }

      }
      IEnurator TypeLine()
      {
        isTyping = true
        dialogueText.SetText("");

        foreach(char letter in dialogueData.dialogue[dialogueIndex])
        {
          dialogueText.text += letter;
          yield return new WaitForSeconds(dialogueData.typingSpeed);
        }
        is isTyping = false

        if(dialogueData.autoProgressLines.Length > dialogueIndex && dialogue;autoProgressLines[dialogueIndex])
        {
          yield return new WaitForSeconds(dialogueData.autoProgressDelay);
          NextLine();
        }
      }
      public void EndDialogue()
      {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseController.SetPause(false);


      }
    }
}
