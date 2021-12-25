using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] GameObject[] _cubes;
    [SerializeField] private TMP_Text _finishText;

    private async void Start()
    {
        _finishText.gameObject.SetActive(false);
        Task[] tasks = new Task[_cubes.Length];

        for (int i = 0; i < _cubes.Length; i++)
        {
            tasks[i]= MoveCube(i+1,_cubes[i]);
        }
        await Task.WhenAll(tasks);

        _finishText.gameObject.SetActive(true);
    }
    public async Task MoveCube(float movementTime,GameObject cube)
    {
        float time = Time.time + movementTime;
        while (Time.time < time)
        {
            float x = cube.transform.position.x;
            x += 1;
            cube.transform.position = new Vector3(x, cube.transform.position.y, cube.transform.position.z);
            await Task.Delay(1000);
        }
    }
}
