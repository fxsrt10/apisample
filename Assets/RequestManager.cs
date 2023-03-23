using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class RequestManager : MonoBehaviour
{
    [SerializeField]
    private string url;
    [SerializeField]
    private GameObject templatePrefab;
    [SerializeField]
    private GameObject contentParent;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetSongs());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GetSongs()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string result = webRequest.downloadHandler.text;
                List<Song> songList = JsonConvert.DeserializeObject<List<Song>>(result);
                Debug.Log("Request successful!");
                foreach (var item in songList)
                {
                    GameObject newButtonGO = Instantiate(templatePrefab,contentParent.transform);
                    newButtonGO.GetComponent<SongListItem>().SetUpSong(item);
                }
            }
            else
            {
                Debug.Log("Request failed");
            }
        }
    }
}

public class Song
{
    public string artist;
    public string title;
    public string album;
    public int year;
    public int rank;

    public override string ToString()
    {
        return artist +" " + title + " " + album + " " + year + " " + rank;
    }
}
