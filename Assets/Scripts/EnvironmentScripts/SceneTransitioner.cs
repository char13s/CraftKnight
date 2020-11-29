using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SceneTransitioner : MonoBehaviour
{
    public static event UnityAction<int,GameObject> sendNextScene;
    [SerializeField] private int nextScene;
    [SerializeField] private GameObject spawn;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) {
        if (sendNextScene != null) {
            sendNextScene(nextScene,spawn);
        }
    }
}
