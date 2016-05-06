using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpScript : MonoBehaviour {

    public GameObject[] Buttons;
    public GameObject[] Pages;

    Text BackButton;
    Text ProxButton;

    void Start()
    {

      /*  for (int i = 0; i < Pages.Length; i++)
            Pages[i].SetActive(false);

        Buttons[0].SetActive(true);
        Buttons[1].SetActive(true);
        Buttons[2].SetActive(true);
        Buttons[3].SetActive(true);
        Buttons[4].SetActive(false);
        Buttons[5].SetActive(false);*/
    }
    public void GoNext()
    {
        if (Pages[0].activeInHierarchy)
        {
            Pages[0].SetActive(false);
            Pages[1].SetActive(true);
            BackButton.text = "Voltar";
            return;
        }


        if (Pages[1].activeInHierarchy)
        {
            Pages[1].SetActive(false);
            Pages[2].SetActive(true);
            return;
        }

        if (Pages[2].activeInHierarchy)
        {
            Pages[2].SetActive(false);
            Pages[3].SetActive(true);
            return;
        }

        if (Pages[3].activeInHierarchy)
        {
            Pages[3].SetActive(false);
            Pages[4].SetActive(true);
            return;
        }

        if (Pages[4].activeInHierarchy)
        {
            Pages[4].SetActive(false);
            if (Application.platform == RuntimePlatform.Android)            
                Pages[5].SetActive(true);            
            else Pages[6].SetActive(true);

            
            return;
        }
        if (Pages[5].activeInHierarchy || Pages[6].activeInHierarchy)
        {
            Pages[5].SetActive(false);
            Pages[6].SetActive(false);

            if (Application.platform == RuntimePlatform.Android)

                Pages[7].SetActive(true);
            else Pages[8].SetActive(true);            

            ProxButton.text = "Sair";
            return;          
        }

        if (Pages[7].activeInHierarchy || Pages[8].activeInHierarchy)
        {
            Pages[7].SetActive(false);
            Pages[8].SetActive(false);

            Buttons[0].SetActive(true);
            Buttons[1].SetActive(true);
            Buttons[2].SetActive(true);
            Buttons[3].SetActive(true);
            Buttons[4].SetActive(false);
            Buttons[5].SetActive(false);
        }
    }

    public void GoBack()
    {
        if (Pages[0].activeInHierarchy)
        {
            Pages[0].SetActive(false);
            Buttons[0].SetActive(true);
            Buttons[1].SetActive(true);
            Buttons[2].SetActive(true);
            Buttons[3].SetActive(true);
            Buttons[4].SetActive(false);
            Buttons[5].SetActive(false);
        }


        if (Pages[1].activeInHierarchy)
        {
            Pages[1].SetActive(false);
            Pages[0].SetActive(true);
            BackButton.text = "Sair";
        }

        if (Pages[2].activeInHierarchy)
        {
            Pages[2].SetActive(false);
            Pages[1].SetActive(true);
            BackButton.text = "Voltar";
        }

        if (Pages[3].activeInHierarchy)
        {
            Pages[3].SetActive(false);
            Pages[2].SetActive(true);
        }

        if (Pages[4].activeInHierarchy)
        {
            Pages[4].SetActive(false);
            Pages[3].SetActive(true);
        }

        if (Pages[5].activeInHierarchy || Pages[6].activeInHierarchy)
        {
            Pages[5].SetActive(false);
            Pages[6].SetActive(false);

            Pages[4].SetActive(true);
            
        }

        if (Pages[7].activeInHierarchy || Pages[8].activeInHierarchy)
        {
            Pages[7].SetActive(false);
            Pages[8].SetActive(false);

            if(Application.platform == RuntimePlatform.Android)
                Pages[5].SetActive(true);
            else Pages[6].SetActive(true);

            ProxButton.text = "Próximo";
        }
    }

    public void GetHelp()
    {
        Pages[0].SetActive(true);

        Buttons[0].SetActive(false);
        Buttons[1].SetActive(false);
        Buttons[2].SetActive(false);
        Buttons[3].SetActive(false);
        Buttons[4].SetActive(true);
        Buttons[5].SetActive(true); 

        ProxButton = Buttons[5].GetComponentInChildren<Text>();
        BackButton = Buttons[4].GetComponentInChildren<Text>();

        ProxButton.text = "Próximo";
        BackButton.text = "Sair";
    }
}
