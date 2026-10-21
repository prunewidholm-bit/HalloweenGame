using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

namespace JPO
{
    public class PNJ1 : MonoBehaviour
    {
      public PnjDialogue dialogueData;
      public GameObject dialoguePanel;
      public TMP_Text dialogueText, nameText;
      public Image portraitImage;

      private int dialogueIndex;
      private bool isTyping, isDialogueActive;

    }
}
