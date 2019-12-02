using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrCutscene2Manager : MonoBehaviour
{
    public AudioSource Musica;
	public CanvasGroup Fade;
    public GameObject Chat, Credits;
    public bool Call1, Call2;

    void Update()
    {
        if (!Call1 && Fade.alpha == 0)
        {
            Call1 = true;
            Destroy(Fade.GetComponent<scrInitialFade>());
            Chat.SetActive(true);
        }

        if (Chat == null && !Call2)
        {
            Fade.alpha += 0.008f;
            if (Fade.alpha == 1) {
                Call2 = true;
                Musica.Play();
                Credits.SetActive(true);
            }
        }
    }
}
