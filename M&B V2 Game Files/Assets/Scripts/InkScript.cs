using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class InkScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    public TextMeshProUGUI textPrefab;
    public Button buttonPrefab;
    public Canvas mainStory;
    public Canvas names;
    public GameObject rightCharacter;
    public GameObject leftCharacter;
    public Sprite marmotDark;
    public Sprite marmotLight;
    public Sprite lincoln;
    public Sprite petrina;
    public Sprite joshua;
    public Sprite marjorie;
    public Sprite christina;
    public Sprite phionna;
    public Sprite isaacone;
    public Sprite isaactwo;
    public Sprite deepak;
    public Sprite yash;
    public Sprite keefers;
    public Sprite bunnyDark;
    public Sprite bunnyLight;
    public GameObject background;
    public Sprite bedroom;
    public Sprite wsp;
    public Sprite dark;
    //public Sprite marjorie;
    public Sprite twentyexchange;
    public Sprite bklynair;
    public Sprite henry;
    public Sprite henryInside;
    public Sprite bobaGuys;
    public Sprite ryde;
    public Sprite saigonShack;
    public GameObject centralImages;
    public Sprite Toffee;
    public Sprite Shopee;
    public Sprite PidgeonMan;
    public Sprite Students;
    public Sprite Buskers;
    public Sprite Lincpicone;
    public Sprite Lincpictwo;
    public Sprite Marjpicone;
    public Sprite Marjpictwo;
    public Sprite Christinapic;
    public Sprite Phipicone;
    public Sprite Phipictwo;
    public Sprite Deeppicone;
    public Sprite Deeppictwo;
    public Sprite Deeppicthree;
    public Sprite Yashpicone;
    public Sprite Yashpictwo;
    public Sprite Keeferspicone;
    public Sprite Keeferspictwo;
    public Sprite Keeferspicthree;
    public Sprite Keeferspicfour;
    public float leftCharacterPosition;
    public float rightCharacterPosition;
    public float spriteActivateHeight;
    public float spriteDeactivateHeight;
    public float spriteZPosition;
    public float NameFontSize;
    public float StoryFontSize;
    public bool leftIsActivated;
    public bool rightIsActivated;
    public bool leftLightup;
    public bool rightLightup;
    public bool videoPlayerIsActivated;
    public bool centralImagesIsActivated;
    public bool Isaaconeortwo;
    public GameObject videoPlayerHolder;
    public AudioSource squee;
    public AudioSource meow;
    public AudioSource boof;
    public AudioSource teleport;
    public AudioSource hahaha;
    public AudioSource cry;
    public AudioSource zoom;
    public AudioSource panting;
    public AudioSource bgm;
    public Animator whiteFade;
    public Animator blackFade;
    public Animator rcharacter;
    public VideoPlayer videoPlayer;
    public AudioSource vidAudio;


    // Start is called before the first frame update
    void Start()
    {
        leftIsActivated = false;
        rightIsActivated = false;
        leftLightup = false;
        rightLightup = false;
        videoPlayerIsActivated = false;
        centralImagesIsActivated = false;
        story = new Story(inkJSON.text);
        eraseUI();
        refreshUI();
        whiteFade.Play("White to Clear");
    }

    // Update is called once per frame
    void Update()
    {
        //refreshUI();
        if (Input.GetKeyDown(KeyCode.Space) && story.canContinue)
        {
            refreshUI();
            //Debug.Log("anykey");
            //whiteFade.Play("Fade to White");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Restart();
            Debug.Log("esq was pressed");
        }

        //Sets the video player as active or inactive
        if (videoPlayerIsActivated == true)
        {
            videoPlayerHolder.SetActive(true);
        }

        else if (videoPlayerIsActivated == false)
        {
            videoPlayerHolder.SetActive(false);
        }

        //Sets the central image as active or inactive
        if (centralImagesIsActivated == true)
        {
            centralImages.SetActive(true);
        }

        else if (centralImagesIsActivated == false)
        {
            centralImages.SetActive(false);
        }
    }

    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }

    void refreshUI()
    {
        eraseUI();

        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;
        storyText.fontSize = StoryFontSize;

        string text = loadStoryChunk();

        List<string> tags = story.currentTags;

        //if (tags.Count > 0)
        //{
        //    loadNames();
        //}

        foreach (string nametags in story.currentTags)
        {
            //Insert nametags here to be shown
            if (nametags == "Marnie" || nametags == "marnie" || nametags == "Boofies" || nametags == "Lincoln" || nametags == "Petrina" || nametags == "Joshua" || nametags == "Marjorie" || nametags == "Christina" || nametags == "Phionna" || nametags == "Isaac" || nametags == "Isaac (Instructor)" || nametags == "Deepak" || nametags == "Yash" || nametags == "Keefers")
            {
                loadNames();
                //activateCharacter();
            }

            activateCharacter();
            characterlightup();
            noLightUp();
            playSounds();
            transitions();

            void activateCharacter()
            {
                activateLeft();
                activateRight();     
           
                void activateLeft()
                {
                    if (nametags == "activateLeft")
                    {
                        leftIsActivated = true;
                        leftCharacter.transform.position = new Vector3(leftCharacterPosition, spriteActivateHeight, spriteZPosition);
                        leftCharacter.GetComponent<SpriteRenderer>().sprite = bunnyLight;
                    }

                    if (nametags == "Marnie" || nametags == "squee")
                    {
                        leftLightup = true;
                    }

                    else if (nametags == "nospriteboth")
                    {
                        leftCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        leftCharacter.GetComponent<SpriteRenderer>().sprite = null;
                    }
                    else if (nametags == "nospritel")
                    {
                        leftCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        leftCharacter.GetComponent<SpriteRenderer>().sprite = null;
                    }

                    else
                    {
                        leftLightup = false;
                        leftCharacter.transform.position = new Vector3(leftCharacterPosition, spriteDeactivateHeight, spriteZPosition);
                        leftCharacter.GetComponent<SpriteRenderer>().sprite = bunnyDark;
                    }
                }

                void activateRight()
                {
                    if (nametags == "activateRight")
                    {
                        rightIsActivated = true;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = marmotLight;
                    }

                    else if (nametags == "Boofies" || nametags == "boof")
                    {
                        rightLightup = true;
                    }

                    else if (nametags == "Lincoln")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight + 1.0f, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = lincoln;
                        Debug.Log("Linc");
                    }

                    else if (nametags == "Petrina")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = petrina;
                        Debug.Log("Pet");
                    }

                    else if (nametags == "Joshua")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight - 0.5f, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = joshua;
                        Debug.Log("Josh");
                    }

                    else if (nametags == "Marjorie")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = marjorie;
                        Debug.Log("Margy");
                    }

                    else if (nametags == "Christina")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = christina;
                        Debug.Log("Christina");
                    }

                    else if (nametags == "Phionna")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = phionna;
                        Debug.Log("Phionna");
                    }

                    else if (nametags == "Isaac")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight + 0.5f, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = isaacone;
                        Debug.Log("Isaac");
                    }

                    else if (nametags == "Isaac (Instructor)")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight + 1.75f, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = isaactwo;
                        Debug.Log("Isaac (Instructor)");
                    }

                    else if (nametags == "Deepak")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight - 1.0f, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = deepak;
                        Debug.Log("Deepak");
                    }

                    else if (nametags == "Yash")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight - 0.5f, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = yash;
                        Debug.Log("Yash");
                    }

                    else if (nametags == "Keefers")
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight - 1.5f, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = keefers;
                        Debug.Log("Keefers");
                    }

                    else if (nametags == "nospriteboth")
                    {   
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = null;
                    }

                    else if (nametags == "nospriter")
                    {
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
                        leftCharacter.GetComponent<SpriteRenderer>().sprite = null;
                    }

                    else
                    {
                        rightLightup = false;
                        rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteDeactivateHeight, spriteZPosition);
                        rightCharacter.GetComponent<SpriteRenderer>().sprite = marmotDark;
                    }
                }
            }
        }

        loadLocation();

        storyText.text = text;
        storyText.transform.SetParent(mainStory.transform, false);

        //Debug.Log(loadStoryChunk());

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(mainStory.transform, false);
            choiceButton.onClick.AddListener(delegate {
                chooseStoryChoice(choice);
            });
        }

        void loadNames()
        {
            TextMeshProUGUI nameText = Instantiate(textPrefab) as TextMeshProUGUI;
            nameText.fontSize = NameFontSize;
            nameText.text = "<b>" + tags[0] + "</b>";
            nameText.transform.SetParent(names.transform, false);
        }

        if (leftIsActivated == false)
        {
            leftCharacter.GetComponent<SpriteRenderer>().sprite = null;
        }

        if (rightIsActivated == false)
        {
            rightCharacter.GetComponent<SpriteRenderer>().sprite = null;
        }

        playVideo();
        displayImages();
    }

    void eraseUI()
    {
        for(int i = 0; i < mainStory.transform.childCount; i++)
        {
            Destroy(mainStory.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < names.transform.childCount; i++)
        {
            Destroy(names.transform.GetChild(i).gameObject);
        }
    }

    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
        }

        return text;
    }

    void loadLocation()
    {
        foreach (string locationtags in story.currentTags)
        {
            //Insert nametags here to be shown
            if (locationtags == "20exchange")
            {
                background.GetComponent<SpriteRenderer>().sprite = twentyexchange;
            }

            if (locationtags == "Bedroom")
            {
                background.GetComponent<SpriteRenderer>().sprite = bedroom;
            }

            if (locationtags == "WSP")
            {
                background.GetComponent<SpriteRenderer>().sprite = wsp;
            }

            if (locationtags == "dark")
            {
                background.GetComponent<SpriteRenderer>().sprite = dark;
            }

            //if (locationtags == "marjorie")
            //{
            //    background.GetComponent<SpriteRenderer>().sprite = marjorie;
            //    background.transform.position = new Vector3(2, 0, 1);
            //}

            if (locationtags == "bklynair")
            {
                background.GetComponent<SpriteRenderer>().sprite = bklynair;
            }

            if (locationtags == "henry")
            {
                background.GetComponent<SpriteRenderer>().sprite = henry;
            }

            if (locationtags == "henryinside")
            {
                background.GetComponent<SpriteRenderer>().sprite = henryInside;
            }

            if (locationtags == "bobaguys")
            {
                background.GetComponent<SpriteRenderer>().sprite = bobaGuys;
            }

            if (locationtags == "ryde")
            {
                background.GetComponent<SpriteRenderer>().sprite = ryde;
            }

            if (locationtags == "saigonShack")
            {
                background.GetComponent<SpriteRenderer>().sprite = saigonShack;
            }
        }
    }

    void playSounds()
    {
        foreach (string sounds in story.currentTags)
        {
            if (sounds == "squee")
            {
                squee.Play();
            }

            if (sounds == "meow")
            {
                meow.Play();
            }

            if (sounds == "boof")
            {
                boof.Play();
            }

            if (sounds == "teleport")
            {
                teleport.Play();
            }

            if (sounds == "cry")
            {
                cry.Play();
            }

            if (sounds == "zoom")
            {
                zoom.Play();
            }

            if (sounds == "panting")
            {
                panting.Play();
            }

            if (sounds == "hahaha")
            {
                hahaha.Play();
                rightLightup = false;
                rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight - 0.5f, spriteZPosition);
                rightCharacter.GetComponent<SpriteRenderer>().sprite = joshua;
            }
        }
    }

    void characterlightup()
    {
        if (leftLightup == true)
        {
            leftCharacter.transform.position = new Vector3(leftCharacterPosition, spriteActivateHeight, spriteZPosition);
            leftCharacter.GetComponent<SpriteRenderer>().sprite = bunnyLight;
        }

        if (rightLightup == true)
        {
            rightCharacter.transform.position = new Vector3(rightCharacterPosition, spriteActivateHeight, spriteZPosition);
            rightCharacter.GetComponent<SpriteRenderer>().sprite = marmotLight;
        }
    }

    void transitions()
    {
        foreach (string transition in story.currentTags)
        {
            if (transition == "fadewhite")
            {
                blackFade.Play("FadeWhiteBackground");
                Debug.Log("Play fade out");
            }

            if (transition == "fadeblack")
            {
                blackFade.Play("FadeOutBlack");
            }

            if (transition == "fadeclear")
            {
                blackFade.Play("FadeClearBackground");
                Debug.Log("Play fade in");
            }

            if (transition == "keeferstransform")
            {
                rcharacter.enabled = true;
            }

            if (transition == "ending")
            {
                whiteFade.Play("ThankYou");
            }
        }
    }

    void playVideo()
    {
        foreach (string videos in story.currentTags)
        {
            if (videos == "Intro")
            {
                videoPlayerIsActivated = true;
                videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Darn U Intro Exported 2020-04-17 02.26.34.mp4");
                videoPlayer.Play();
                Debug.Log("vid is playing");
            }

            if (videos == "lincvideo")
            {
                bgm.Stop();
                videoPlayerIsActivated = true;
                videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "linconlnVideo.mp4");
                videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
                videoPlayer.controlledAudioTrackCount = 1;
                videoPlayer.EnableAudioTrack(0, true);
                videoPlayer.SetTargetAudioSource(0, vidAudio);
                videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
                videoPlayer.Play();
                Debug.Log("lincvid is playing");
            }

            if (videos == "petvideo")
            {
                bgm.Stop();
                videoPlayerIsActivated = true;
                videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "PetrinaVideo.mp4");
                videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
                videoPlayer.controlledAudioTrackCount = 1;
                videoPlayer.EnableAudioTrack(0, true);
                videoPlayer.SetTargetAudioSource(0, vidAudio);
                videoPlayer.Play();
                Debug.Log("petvid is playing");
            }

            if (videos == "joshvideo")
            {
                bgm.Stop();
                videoPlayerIsActivated = true;
                videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "JoshVideo.mp4");
                videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
                videoPlayer.controlledAudioTrackCount = 1;
                videoPlayer.EnableAudioTrack(0, true);
                videoPlayer.SetTargetAudioSource(0, vidAudio);
                //videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
                videoPlayer.Play();
                Debug.Log("joshvid is playing");
            }

            if (videos == "joshpetvideo")
            {
                bgm.Stop();
                videoPlayerIsActivated = true;
                videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "JoshPetVideo.mp4");
                videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
                videoPlayer.controlledAudioTrackCount = 1;
                videoPlayer.EnableAudioTrack(0, true);
                videoPlayer.SetTargetAudioSource(0, vidAudio);
                videoPlayer.Play();
                Debug.Log("joshpetvid is playing");
            }

            if (videos == "phivideo")
            {
                bgm.Stop();
                videoPlayerIsActivated = true;
                videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "PhionnaVideo.mp4");
                videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
                videoPlayer.controlledAudioTrackCount = 1;
                videoPlayer.EnableAudioTrack(0, true);
                videoPlayer.SetTargetAudioSource(0, vidAudio);
                videoPlayer.Play();
                Debug.Log("phivid is playing");
            }

            if (videos == "keefersvideo")
            {
                bgm.Stop();
                videoPlayerIsActivated = true;
                videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "KeefersVideo.mp4");
                videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
                videoPlayer.controlledAudioTrackCount = 1;
                videoPlayer.EnableAudioTrack(0, true);
                videoPlayer.SetTargetAudioSource(0, vidAudio);
                videoPlayer.Play();
                Debug.Log("keefersvid is playing");
            }

            if (videos == "StopVideo")
            {
                videoPlayer.aspectRatio = VideoAspectRatio.NoScaling;
                videoPlayerIsActivated = false;
                bgm.Play();
            }
        }
    }

    void noLightUp()
    {
        foreach (string lightups in story.currentTags)
        {
            if (lightups == "noLightUp")
            {
                leftLightup = false;
                rightLightup = false;
            }
        }
    }

    void displayImages()
    {
        foreach (string Images in story.currentTags)
        {
            if (Images == "Toffee")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Toffee;
            }

            if (Images == "Shopee")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Shopee;
            }

            if (Images == "PidgeonMan")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = PidgeonMan;
            }

            if (Images == "Students")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Students;
            }

            if (Images == "Buskers")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Buskers;
            }

            if (Images == "Lincpicone")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Lincpicone;
            }

            if (Images == "Lincpictwo")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Lincpictwo;
            }

            if(Images == "Marjpicone")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Marjpicone;
            }

            if (Images == "Marjpictwo")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Marjpictwo;
            }

            if (Images == "Christinapic")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Christinapic;
            }

            if (Images == "Phipicone")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Phipicone;
            }

            if (Images == "Phipictwo")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Phipictwo;
            }

            if (Images == "Deeppicone")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Deeppicone;
            }

            if (Images == "Deeppictwo")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Deeppictwo;
            }

            if (Images == "Deeppicthree")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Deeppicthree;
            }

            if (Images == "Yashpicone")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Yashpicone;
            }

            if (Images == "Yashpictwo")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Yashpictwo;
            }

            if (Images == "Keeferspicone")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Keeferspicone;
            }

            if (Images == "Keeferspictwo")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Keeferspictwo;
            }

            if (Images == "Keeferspicthree")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Keeferspicthree;
            }

            if (Images == "Keeferspicfour")
            {
                centralImagesIsActivated = true;
                centralImages.GetComponent<Image>().sprite = Keeferspicfour;
            }

            if (Images == "Blank")
            {
                centralImagesIsActivated = false;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName: "GameplayScene");
    }
}
