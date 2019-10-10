using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public GameObject player; 
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup; 

    bool m_IsPlayerAtExit;
    float m_Timer; 
    bool m_IsPlayerCaught;
    public AudioSource exitAudio; 
    public AudioSource caughtAudio; 
    bool m_HasAudioPlayed;


    void onTriggerEnter(Collider other)
    {
        if(other.gameObject == player){
            m_IsPlayerAtExit = true; 
        }
    }

    public void CaughtPlayer() 
    {
        m_IsPlayerCaught = true; 
    }

    void Update(){
        if(m_IsPlayerAtExit){
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        } else if (m_IsPlayerCaught) {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup image, bool doRestart, AudioSource audio) 
    {

        if(!m_HasAudioPlayed)
        {
            audio.Play();
            m_HasAudioPlayed = true; 
        }



        m_Timer += Time.deltaTime;
        image.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
            {
                if (doRestart)
                    {
                        SceneManager.LoadScene(0); //restart scene from beginning. 
                    }
                    else
                    {

                        Application.Quit();

                    } 

            }
    }

}
