using UnityEngine;

public class Door : MonoBehaviour
{
    //This script is a temp script. Maybe we will use this in later development, but for now it is meant to test the game

    [SerializeField] private Material doorOpenMaterial;
    [SerializeField] private GameObject doorMesh;

    private MeshRenderer _renderer;

    void Awake()
    {
        _renderer = doorMesh.GetComponent<MeshRenderer>();
    }

    public void OpenDoor()
    {
        _renderer.material = doorOpenMaterial;
    }
}
