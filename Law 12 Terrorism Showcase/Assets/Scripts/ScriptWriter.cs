using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptWriter : MonoBehaviour
{
    private Text subtitles;
    // public List<string> locations = new List<string> {
    //     "the airport", "a school", "a mall", "city hall", "the Vancouver Supreme Court", 
    //     // "a random street", 
    //     "the power plant"
    //     // , "UBC campus", "the Port Mann Bridge"
    //     // , "Surrey Central skytrain station", "Stanley Park", "a bank"
    // };
    // private Dictionary<string, List<int>> locationData = new Dictionary<string, List<int>>{
    //     {"the airport", new List<int> {0, 1, 2, 3, 4, 5, 7, 8, 9, 11, 12}},
    //     {"a school", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 10, 11, 12}},
    //     {"a mall", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 11, 12}},
    //     {"city hall", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 12}},
    //     {"the Vancouver Supreme Court", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 11, 12}},
    //     // {"a random street", new List<int> {0, 1, 2, 3, 4, 9, 12}},
    //     {"the power plant", new List<int> {0, 1, 2, 4, 5, 6, 7, 11, 12}},
    //     // {"UBC campus", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 12}},
       
    //     // {"the Port Mann Bridge", new List<int> {0, 1, 2, 3, 4, 7, 9, 12}},
    //     // {"Surrey Central skytrain station", new List<int> {}},
    //     // {"Stanley Park", new List<int> {}},
    //     // {"a bank", new List<int> {}}
    // };

    public List<GameObject> locationObjects;
    public Transform JP;
    public Transform WW;
    public Transform cam;
    int currentLocation = 0;
    walkTo JPwalk;
    walkTo WWwalk;

    // public List<string> actions = new List<string> {
    //     "started protesting", "began to silent protest", "loudly declared their love for the cause", 
    //     "began handing out pamphlets to recruit people for their cause", "glued themselves down on the spot", 
    //     "vandalized the area with graffiti", "shut off the power grid", "planted multiple high-power explosives", "hijacked a plane", "began opening fire on multiple civilians", 
    //     "kidnapped multiple children", "left a package, later found to contain anthrax", "started screaming at the top of their lungs"
    // };
    public List<string> causes = new List<string> {
        "an environmental movement", "a gender equality movement", "ISIS", "a misogynistic movement", "a gang", 
        "the legalize methamphetamine movement", "a racial equality movement", "the anti-mask mandate cause", "an anti-capitalism movement"
    };

    private List<string> script = new List<string> {      
        //   Homebase, no prop 
        "Jesse Pinkman and Walter White plan to attack a power plant to halt production of pollutive energy.",
        // walk off other set, cut, Walk on new set, equip prop
        "They bring C4 to the compound, and plan to detonate the explosives and demolish the plantation to send a message,", 
        // Walk off other set w/ prop
        "but before they could, they were caught by onsite security.",

        "Next Scenario",
        
        // Homebase, no prop
        "Walter and Jesse are both a part of ISIS.",
        // Walk on, no prop
        "In support of this organization, they visit the city hall,",
        // Equip prop, walk off
        "and begin handing out pamphlets informing people of ISIS, trying both to recruit and spread their ideals.",

        "Next Scenario",

        // Homebase, no prop
        "White and Pinkman charged into a school, armed.",
        // 
        "They planned to shoot half the students to threaten any outliers from resisting, and then hold the rest hostage.",
        "They are fortunately stopped before the situation escalates. Their motives for the attack is still unclear.",

        "Next Scenario",

        "In Rakkarville, freedom is practically non-existent. Two people who strongly oppose the oppression faced by the people of Rakkarville are Walter White and Jesse Pinkman.",
        "They head to their supreme court to protest in favour of liberating the people of Rakkarville, coincidentally at the same time as when the President of Rakkarville is visiting Canada for diplomatic relations",
        "Upon recognizing the President, White pulled out a firearm and opened fire on the crowd, assassinating the Rakkarvillian President and injuring civilians in the process.",
        "The End. How did you do?"
    };
    // bool subStarted = false;
    int i;
    bool hasSwitched = true;

    T PickRandomItem<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogError("List is null or empty.");
            return default(T);
        }

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }
    // string GenerateRandomMonth()
    // {
    //     // Array of month names
    //     string[] months = { "January", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    //     // Get a random month
    //     string randomMonth = months[Random.Range(0, months.Length)];

    //     return randomMonth;
    // }

    // Start is called before the first frame update
    void Start()
    {
        // string personAName = "Walter Hartwell White";
        // string personBName = "Saul Goodman";
        // string cause = PickRandomItem(causes);
        // string location = PickRandomItem(locations);
        // string action = actions[PickRandomItem(locationData[location])];
        
        // script.Add("On " + GenerateRandomMonth() + " " + Random.Range(0, 31) + ", " + "Walter Hartwell White" + " and " + "Saul Goodman" + " were caught acting in part with " + cause + ".");
        // script.Add("Walter and Mr. Pinkman were spotted near " + location);
        
        // script.Add("this was where they then " + action + ".");
        subtitles = gameObject.GetComponent<Text>();
        subtitles.text = script[i];
        JPwalk = JP.gameObject.GetComponent<walkTo>();
        WWwalk = WW.gameObject.GetComponent<walkTo>();
    }
    // Update is called once per frame
    void Update()
    {
        // if(!subStarted)
        // {
        //     StartCoroutine(runscript());
        //     subStarted = true;
        // }
        if(Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(i<script.Count-1)
            {
                i++;
                hasSwitched = true;
            }
            subtitles.text = script[i];
        }else if(Input.GetMouseButtonDown(1))
        {
            if(i>0)
            {
                i--;
                hasSwitched = true;
            }
            subtitles.text = script[i];
        }

        
        if(hasSwitched)
        {
            if(i==0)
            {
                // Set cam, prop, pos of char to entry point, other vars of char
                currentLocation = 0;
                JPwalk.currentProp = 0;
                WWwalk.currentProp = 0;
                StartCoroutine(SetNewPosAndWalkIn());
            }else if(i==1){
                int oldLocation = currentLocation;
                currentLocation = 1;
                StartCoroutine(WalkOutSetNewPosAndWalkInEquipProp(oldLocation, currentLocation, 1));

            }else if(i==2){
                currentLocation = 1;
                StartCoroutine(WalkOff());
            }

            else if(i==4)
            {
                // Set cam, prop, pos of char to entry point, other vars of char
                currentLocation = 0;
                JPwalk.currentProp = 0;
                WWwalk.currentProp = 0;
                StartCoroutine(SetNewPosAndWalkIn());
            }else if(i==5){
                int oldLocation = currentLocation;
                currentLocation = 2;
                StartCoroutine(WalkOutSetNewPosAndWalkInEquipProp(oldLocation, currentLocation, 2));

            }else if(i==6){
                currentLocation = 2;
                StartCoroutine(WalkOff());
            }

            else if(i==8)
            {
                // Set cam, prop, pos of char to entry point, other vars of char
                currentLocation = 0;
                JPwalk.currentProp = 0;
                WWwalk.currentProp = 0;
                StartCoroutine(SetNewPosAndWalkIn());
            }else if(i==9){
                int oldLocation = currentLocation;
                currentLocation = 3;
                StartCoroutine(WalkOutSetNewPosAndWalkInEquipProp(oldLocation, currentLocation, 3));

            }else if(i==10){
                currentLocation = 3;
                StartCoroutine(WalkOff());
            }

            else if(i==12)
            {
                // Set cam, prop, pos of char to entry point, other vars of char
                currentLocation = 0;
                JPwalk.currentProp = 0;
                WWwalk.currentProp = 0;
                StartCoroutine(SetNewPosAndWalkIn());
            }else if(i==13){
                int oldLocation = currentLocation;
                currentLocation = 4;
                StartCoroutine(WalkOutSetNewPosAndWalkInEquipProp(oldLocation, currentLocation, 3));

            }else if(i==14){
                currentLocation = 4;
                StartCoroutine(WalkOff());
            }

            else if(i==15)
            {
                // Set cam, prop, pos of char to entry point, other vars of char
                currentLocation = 0;
                JPwalk.currentProp = 0;
                WWwalk.currentProp = 0;
                StartCoroutine(SetNewPosAndWalkIn());
            }
        }
    }

    IEnumerator SetNewPosAndWalkIn()
    {
        hasSwitched = false;
        GameObject set = locationObjects[currentLocation];

        cam.position = set.transform.Find("CamPos").position;
        cam.rotation = set.transform.Find("CamPos").rotation;
        WWwalk.newPos = set.transform.Find("WW");
        WWwalk.walking = true;
        WW.position = set.transform.Find("entry").position;
        yield return new WaitForSeconds(1f);
        JPwalk.newPos = set.transform.Find("JP");
        JP.position = set.transform.Find("entry").position;
        JPwalk.walking = true;
        yield return null;
    }

    IEnumerator WalkOutSetNewPosAndWalkInEquipProp(int oldLocation, int location, int prop)
    {
        hasSwitched = false;
        // Walk off oldLocation, use while to loop until walking is false
        // Debug.Log("1");
        GameObject set = locationObjects[oldLocation];
        cam.position = set.transform.Find("CamPos").position;
        cam.rotation = set.transform.Find("CamPos").rotation;
        WW.position = set.transform.Find("WW").position;
        WWwalk.newPos = set.transform.Find("exit");
        WWwalk.walking = true;
        yield return new WaitForSeconds(0.5f);
        JP.position = set.transform.Find("JP").position;
        JPwalk.newPos = set.transform.Find("exit");
        JPwalk.walking = true;
        // Debug.Log("2");
        

        while(JPwalk.walking)
        {
            Debug.Log("3");
            yield return new WaitForSeconds(0.5f);
        }
        // Debug.Log("4");
        // tp to new location, do same as before w/ SetNewPosAndWalkIn()
        set = locationObjects[location];
        cam.position = set.transform.Find("CamPos").position;
        cam.rotation = set.transform.Find("CamPos").rotation;
        WWwalk.newPos = set.transform.Find("WW");
        WWwalk.walking = true;
        WW.position = set.transform.Find("entry").position;
        yield return new WaitForSeconds(1f);
        JPwalk.newPos = set.transform.Find("JP");
        JP.position = set.transform.Find("entry").position;
        JPwalk.walking = true;
        JPwalk.currentProp = prop;
        WWwalk.currentProp = prop;
        yield return null;
        // Debug.Log("5");
    }

    IEnumerator WalkOff ()
    {
        hasSwitched = false;
        GameObject set = locationObjects[currentLocation];
        cam.position = set.transform.Find("CamPos").position;
        cam.rotation = set.transform.Find("CamPos").rotation;
        WWwalk.newPos = set.transform.Find("exit");
        WWwalk.walking = true;
        yield return new WaitForSeconds(0.5f);
        JPwalk.newPos = set.transform.Find("exit");
        JPwalk.walking = true;
        yield return null;
    }
    

    // IEnumerator runscript()
    // {
    //     for(int i=0; i<script.Count; i++)
    //     {
    //         subtitles.text = script[i];
    //         Debug.Log(script[i].Length * 0.1f);
    //         yield return new WaitForSeconds(1f);
    //     }
    //     yield return null;
    // }
}
