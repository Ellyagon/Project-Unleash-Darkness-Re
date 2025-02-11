using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DIalogueManager : MonoBehaviour
{
    [SerializeField] public bool _needsToDissapear;
    [SerializeField] public GameObject _gameObj;

    public TextMeshProUGUI nametext;
    public TextMeshProUGUI descriptiontext;

    private Queue<string> sentences;

    public Animator animator;


    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueForInteraction dialogue) //inicia el dialogo, tambien llamamos la clase de DFI para usar sus instancias
    {
  
        animator.SetBool("IsOpen", true); //llama al animator para que el cuadro de texto aparezca en pantalla
        nametext.text = dialogue.name; //lo que el personaje dice se guarda en el Scritp de DialogueForInteraction, con esto nos aseguramos de que dicho texto salga en la UI

        sentences.Clear(); //esto para limpiar el string del dialogo si ya tuvimos uno con anterioridad

        foreach (string sentence in dialogue.sentences)//llama las sigueintes frases
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //para que una frase no se anime sin antes haber acabado la anterior a ella
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) //sirve para que el dialogo salga eltra por letra, solamente es estetico
    {
        descriptiontext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            descriptiontext.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        if (_needsToDissapear)
        {

            Destroy(_gameObj);

        }
        //Debug.Log("End of convewrsation!");
    }

}
