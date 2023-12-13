using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptWriter : MonoBehaviour
{
    public Text subtitles;
    public List<string> locations = new List<string> {
        "the airport", "a school", "a mall", "city hall", "the Vancouver Supreme Court", "a random street", 
        "the power plant", "UBC campus", "the Port Mann Bridge", "Surrey Central skytrain station", 
        "Stanley Park", "a bank"
    };
    private Dictionary<string, List<int>> locationData = new Dictionary<string, List<int>>{
        {"the airport", new List<int> {0, 1, 2, 3, 4, 5, 7, 8, 9, 11, 12}},
        {"a school", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 10, 11, 12}},
        {"a mall", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 11, 12}},
        {"city hall", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 12}},
        {"the Vancouver Supreme Court", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 11, 12}},
        {"a random street", new List<int> {0, 1, 2, 3, 4, 9, 12}},
        {"the power plant", new List<int> {0, 1, 2, 4, 5, 6, 7, 11, 12}},
        {"UBC campus", new List<int> {0, 1, 2, 3, 4, 5, 7, 9, 12}},
        {"the Port Mann Bridge", new List<int> {}},
        {"Surrey Central skytrain station", new List<int> {}},
        {"Stanley Park", new List<int> {}},
        {"a bank", new List<int> {}}
    };

    public List<string> actions = new List<string> {
        "started protesting", "began to silent protest", "loudly declared their love for", 
        "began handing out pamphlets to recruit people for their cause", "glued themselves down on the spot", 
        "vandalized the area with graffiti", "shut off the power grid", "planted a high-power explosive", "hijacked a plane", "began opening fire on multiple civilians", 
        "kidnapped multiple children", "left a package, later found to contain anthrax", "started screaming at the top of their lungs"
    };
    public List<string> causes = new List<string> {
        "an environmental movement", "a gender equality movement", "ISIS", "a misogynistic movement", "a gang", 
        "the legalize methamphetamine movement", "a racial equality movement", "the anti-mask mandate cause", "an anti-capitalism movement"
    };

    public List<string> script;
    bool subStarted = false;

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
    string GenerateRandomMonth()
    {
        // Array of month names
        string[] months = { "January", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        // Get a random month
        string randomMonth = months[Random.Range(0, months.Length)];

        return randomMonth;
    }

    // Start is called before the first frame update
    void Start()
    {
        string personAName = "Walter Hartwell White";
        string personBName = "Jesse Pinkman";
        string cause = PickRandomItem(causes);
        string action = PickRandomItem(actions);
        string location = PickRandomItem(locations);
        
        script.Add("On " + GenerateRandomMonth() + " " + Random.Range(0, 31) + "," + "Walter Hartwell White" + " and " + "Jesse Pinkman" + " were caught acting in part with " + cause + ".");
        script.Add("Walter and Mr. Pinkman were spotted near " + location + ", where they then" + action);
        
    }
    // Update is called once per frame
    void Update()
    {
        if(!subStarted)
        {
            StartCoroutine(runscript());
            subStarted = true;
        }
    }

    IEnumerator runscript()
    {
        for(int i=0; i<script.Count; i++)
        {
            subtitles.text = script[i];
            Debug.Log(script[i].Length * 0.1f);
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
}
