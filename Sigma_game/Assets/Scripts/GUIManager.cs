using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour {


    public void PlayButton() {

      /*  GameObject loadScreen = GameObject.FindGameObjectWithTag("LoadSc");
        GameObject gui = GameObject.FindGameObjectWithTag("GUI");


        MeshRenderer mr = loadScreen.GetComponent<MeshRenderer>();
        Canvas c = gui.GetComponent<Canvas>();



        mr.enabled = true;
        c.enabled = false;

        */

        SceneManager.LoadScene("Enemies");
    }
}
