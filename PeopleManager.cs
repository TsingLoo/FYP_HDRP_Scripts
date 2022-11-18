using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : SingletonForMonobehaviour<PeopleManager>
{
    public int modelCount = 0;

    const string PATH = @"Prefabs/Models/";

    /// <summary>
    /// The target num of models in scene 
    /// </summary>
    public int humanNum_inScene;
    //Change the area size 
    public float largestX;
    public float smallestX;
    public float largestZ;
    public float smallestZ;

    public float walkingSpeed;

    //keep track of the each person
    public List<PersonBound> bounds_list = new List<PersonBound>();

    private ArrayList humanList = new ArrayList();  //list of Index of human, starts from zero
    private ArrayList objectList = new ArrayList();
    private ArrayList r_humanList; //list of the random IDs of human
    //private ArrayList r_SpawnList ;  list of the random spawn point
    //private ArrayList r_x;
    //private ArrayList r_z;

    /// <summary>
    /// record the number of models have been spawned
    /// </summary>
    private int SpawnCounter = 0;
    void Start()
    { 

        for (int i = 0; i < modelCount; i++)
        {
            humanList.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SpawnCounter == 0)
            {
                SpawnCounter++;
            }
            else
            {
                foreach (GameObject Object in objectList)
                {
                    Destroy(Object);
                }
            }

            //生成角色的随机ID
            //r_humanList = Randoms(0, modelCount, humanNum_inScene);
            //r_x = Randoms(smallestX, largestX, humanNum_inScene);
            //r_z = Randoms(smallestZ, largestZ, humanNum_inScene);
            for (int i = 0; i < humanNum_inScene; i++)
            {
                //Debug.Log(PATH + r_humanList[i].ToString() + ".prefab");
                GameObject humanPrefab = Resources.Load<GameObject>(PATH + Randoms(0,modelCount,humanNum_inScene).ToString());
                Debug.Log(PATH + Randoms(0, modelCount, humanNum_inScene).ToString());
                float X = UnityEngine.Random.Range(smallestX, largestX);
                float Z = UnityEngine.Random.Range(smallestZ, largestZ);
                Vector3 SpawnPosition = new Vector3(X, 0, Z);
                GameObject human = Instantiate(humanPrefab, SpawnPosition, UnityEngine.Random.rotation);
                var bound = human.GetOrAddComponent<PersonBound>();
                bounds_list.Add(bound);
                //objectList.Add(human);
            }
            /*
            r_humanList=RandomNum(humanList);
            r_SpawnList = RandomList();
            for(int i= 0;i<humanNum_inScene;i++)
            {
                GameObject testPrefab = Resources.Load<GameObject>(r_humanList[i].ToString());
                GameObject human = Instantiate(testPrefab, (Vector3)r_SpawnList[i], UnityEngine.Random.rotation);
                objectList.Add(human);
            }
            */
        }
    }

    /// <summary>
    /// Assign a unique PID
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="end"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public int Randoms(int begin, int end, int num)
    {
        ArrayList random = new ArrayList();
        /*
        System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < humanNum_inScene; i++)
        {
            random.Add(rnd.Next(begin, end));
        }
        return (random);
        */
        while (random.Count < num)
        {
            int i = UnityEngine.Random.Range(begin, end);
            if (!random.Contains(i))
            {
                random.Add(i);
                return i; 

            }
        }
        return -1;
    }


    /*
    public ArrayList RandomNum(ArrayList list)
    {
        int resultID;
        ArrayList result = new ArrayList();
        ArrayList listClone = new ArrayList();
        foreach(int num in list)
        {
            listClone.Add(num);
            
        }

        while (listClone.Count > list.Count - humanNum_inScene)
        {
            resultID= UnityEngine.Random.Range(0, listClone.Count);
            result.Add(listClone[resultID]);
            listClone.RemoveAt(resultID);
        }
        
            return (result);
        }
       
    public ArrayList RandomList()
    {
        int x;
        int z;
        ArrayList SpawnList = new ArrayList(); 
        while (SpawnList.Count < humanNum_inScene)
        {
            x = UnityEngine.Random.Range(smallestX, largestX);
            z = UnityEngine.Random.Range(smallestZ, largestZ);
            Vector3 SpawnPosition = new Vector3(x, 0, z);
            if (!SpawnList.Contains(SpawnPosition))
            {
                SpawnList.Add(SpawnPosition);
            }
        }
        return SpawnList;
    }*/
}
