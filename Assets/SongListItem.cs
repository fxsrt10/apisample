using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongListItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI album;
    [SerializeField]
    private TextMeshProUGUI year;
    [SerializeField]
    private TextMeshProUGUI artist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetUpSong(Song item)
    {
        title.text = item.title;
        album.text = item.album;
        year.text = item.year.ToString();
        artist.text = item.artist;
    }
}
