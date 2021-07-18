using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim; 
    
    void Awake()
    {
        CreateSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(1f);

    }

    void CreateSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
