using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
This is the logic for the sorting quiz. It will read in a JSON file that contains the questions that the the user
will be asked to determine where they should be placed. This is meant for four possible categories. All the program needs
is a json file in the correct question format and JSON defining the types that the user can be sorted into.
*/
public class SortingQuiz : MonoBehaviour
{
    /*
    QuestionSet class. This holds the set of questions the user will answer. It holds an Array of Question objects.
    Contains count() method that returns the number of questions in the set
    */
    [System.Serializable]
    public class QuestionSet
    {
        public Question[] questions;

        public int count()
        {
            return questions.Length;
        }
    }

    /*
    The Question class holds the information of any given question. It includes the question itself in String form.
    It also holds an Array of Option objects. Options array represents the options for each question.
    */
    [System.Serializable]
    public class Question
    {
        public string question;
        public Option[] options;
    }

    /*
    Option class is where options information is stored for each question. It has string body or what the option it is.
    Also has string type field. This is very important as it helps talley up which type the user should be. Each option
    within a Question should have unique type based on the design.
    */
    [System.Serializable]
    public class Option
    {
        public string body;
        public string type;

        //Returns the type of a given option
        public string getType()
        {
            return this.type;
        }
    }

    /*
    TypeSet class stores all the possible types the user can be sorted into. Contains Type object Array
    */
    [System.Serializable]
    public class TypeSet
    {
        public Type[] types;
    }

    /*
    Type class is where information for a type is. It includes the type's name and it's description. This can be expanded to inlude
    other information
    */
    [System.Serializable]
    public class Type
    {
        public string name;
        public string description;
    }

    /*
    Variables fro the quiz screen. These are used in the "Question Template" section in Unity
    */
    public GameObject quizScreen;

    public TMP_Text questionBody;
    public TextAsset questionsJson;
    public TextAsset typesJson;

    public int questionCount;
    public int curQuestion;

    public QuestionSet questionSet = new QuestionSet();
    public TypeSet typeSet = new TypeSet();

    public Button option1;
    public Button option2;
    public Button option3;
    public Button option4;

    public TMP_Text op1body;
    public TMP_Text op2body;
    public TMP_Text op3body;
    public TMP_Text op4body;

    //counts the number of each type the user has selected options in 
    public Dictionary<string, int> typeCounter = new Dictionary<string, int>();

    /*
    Variables for the quiz results screen. What the user will see after the quiz is over
    */
    public GameObject resultsScreen;
    public TMP_Text typeName;
    public TMP_Text typeDesc;

    /*
    getTopType() returns the user's top type. This is the type of person the user based on answer the quiz. It takes in a Dictionary
    and returns the Key associated with the highest Value.
    */
    public string getTopType(Dictionary<string, int> typeCounter)
    {
        int topValue = 0;
        string topType = "";

        foreach (KeyValuePair<string, int> type in typeCounter)
        {
            if (type.Value > topValue)
            {
                topValue = type.Value;
                topType = type.Key;
            }
        }

        return topType;
    }

    /*
    readJsons() reads from the questions.json and type.json and converts them into Objects for use.
    questions.json is converted into a QuestionSet and types.json into TypeSet Object.
    After Object creation, count() is used to find the number of questions in the JSON file.
    Also calls ReadTypes to read in the types, the user can be sorted into.
    */
    public void readJsons()
    {
        questionSet = JsonUtility.FromJson<QuestionSet>(questionsJson.text);
        typeSet = JsonUtility.FromJson<TypeSet>(typesJson.text);

        questionCount = questionSet.count();
        readTypes(questionSet.questions[0].options);
    }

    /*
    ReadTypes() reads in the possible types based on the first question's options (This assumes that the question JSON
    had unique types for every question and no duplicates). Passed in Option array.
    */
    public void readTypes(Option[] options)
    {
        foreach (Option option in options)
        {
            typeCounter.Add(option.getType(), 0);
        }
    }

    /*
    setUserType() sets the type for the user. After the quiz is finished, this method grabs the top type
    and creates PlayerPref fields for the type and type description. This means it will persist over multiple sessions
    It also displays the results to the user via the results screen
    */
    public void setUserType()
    {
        string type = getTopType(typeCounter);
        Type typeInfo = getTypeInfo(type);

        PlayerPrefs.SetString("type", typeInfo.name);
        PlayerPrefs.SetString("typeDesc", typeInfo.description);

        typeName.text = PlayerPrefs.GetString("type", "none");
        typeDesc.text = PlayerPrefs.GetString("typeDesc", "nanna");
    }

    /*
    getTypeInfo returns the Type object associated with typeName. It will search through typeSet to find it
    Although it can theoretically return null, it's not possible due to how it's being called
    */
    public Type getTypeInfo(string typeName)
    {
        Type typeInfo = null;
        foreach (Type type in typeSet.types)
        {
            if (type.name == typeName)
            {
                typeInfo = type;
            }
        }

        return typeInfo;
    }

    /*
    readCurQuestion() reads and displays the question based on the integer value it is passed into.
    It does this by retriving the Question and Options at the index in questionSet specifed by cur.
    */
    public void readCurQuestion(int cur)
    {
        questionBody.text = questionSet.questions[cur].question;
        op1body.text = questionSet.questions[cur].options[0].body;
        op2body.text = questionSet.questions[cur].options[1].body;
        op3body.text = questionSet.questions[cur].options[2].body;
        op4body.text = questionSet.questions[cur].options[3].body;
    }

    /*
    getCurQuestion() returns the Question object that defines the question that the user is currently on
    using curQuestion as the index.
    */
    public Question getCurQuestion()
    {
        return questionSet.questions[curQuestion];
    }

    /*
    readNextQuestion reads the next question in the question set. It will display its content using readCurQuestion
    after incrementing curQuestion. If the user has reached the final question, it will then swap it to the results screen
    and also call setUserType to save the user's quiz results.
    */
    public void readNextQuestion()
    {
        if (curQuestion == questionCount - 1)
        {
            quizScreen.SetActive(false);
            resultsScreen.SetActive(true);
            setUserType();
        }
        else
        {
            curQuestion++;
            readCurQuestion(curQuestion);
        }
    }

    /*
    TallyType will increment the counter for the type that the user's selected option corresponse to.
    Method grabs the seleted question's body and then searchs it's type using findType. Using the found type,
    the correponding counter is incremented. The next question is then loaded after the counters are ensured to have
    been updated.
    */
    public void TallyType(Button button)
    {
        TMP_Text questionType = button.GetComponentInChildren<TMP_Text>();
        string type = findType(questionType.text);
        typeCounter[type] = typeCounter[type] + 1;
        readNextQuestion();
    }

    /*
    findType() finds the type given a option in string form
    */
    public string findType(string optionBody)
    {
        Question curQuest = getCurQuestion();
        Option[] curOptions = curQuest.options;
        string type = "none";

        for (int i = 0; i < curOptions.Length; i++)
        {
            if (optionBody.Equals(curOptions[i].body))
            {
                type = curOptions[i].type;
            }
        }
        return type;
    }

    /*
    At the start, the JSON data is read in, the first question is read and displayed, and the question counter is set to 0.
    Each of the four option buttons have onClick events added to them. This is to make sure for any of the buttons, the results
    will be accurate and the next question will be read.
    */
    void Start()
    {
        readJsons();
        curQuestion = 0;
        readCurQuestion(curQuestion);

        option1.onClick.AddListener(() => TallyType(option1));
        option2.onClick.AddListener(() => TallyType(option2));
        option3.onClick.AddListener(() => TallyType(option3));
        option4.onClick.AddListener(() => TallyType(option4));
    }
}
