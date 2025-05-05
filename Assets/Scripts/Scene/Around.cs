using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Around : MonoBehaviour
{
    private Vector3 rotationSpeed = new Vector3(0, 90, 0);
    // Update is called once per frame
    void Update()
    {

    }
    void Rotate()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
    public void Forward()
    {
        StartCoroutine(MoveForwardForSeconds(1f));        
    }
    IEnumerator MoveForwardForSeconds(float seconds)
    {
        float timer = 0f;

        while (timer < seconds)
        {
            transform.Translate(Vector3.forward * 100 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("StageScene");
    }
}
