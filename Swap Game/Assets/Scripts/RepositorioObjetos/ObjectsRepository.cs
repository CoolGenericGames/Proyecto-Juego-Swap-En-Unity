using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRepository : MonoBehaviour
{
    public static Dictionary<string, Queue<GameObject>> RepositoryObj = new Dictionary<string, Queue<GameObject>>();

    #region Métodos

    public static void CreateInstance(string objectTag, GameObject ObjectToInstance, int quantity)
    {
        RepositoryObj.Add(objectTag, new Queue<GameObject>());
        FillQueue(objectTag, ObjectToInstance, quantity);
    }

    static void FillQueue(string objectTag, GameObject instantiatedObject, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject CreatedInstanceObject = Instantiate(instantiatedObject);
            RepositoryObj[objectTag].Enqueue(CreatedInstanceObject);
            CreatedInstanceObject.SetActive(false);
        }
    }

    public static GameObject UseRepository(string ReferenceTag, Vector3 position, Quaternion rotation)
    {
        if (RepositoryObj.ContainsKey(ReferenceTag))
        {
            if (RepositoryObj[ReferenceTag].Count <= 1)
            {
                FillQueue(ReferenceTag, RepositoryObj[ReferenceTag].Peek(), 3);
            }
            GameObject newObjectToUse = RepositoryObj[ReferenceTag].Dequeue();
            newObjectToUse.transform.position = position;
            newObjectToUse.transform.rotation = rotation;
            newObjectToUse.SetActive(true);
            return newObjectToUse;
        }
        else { return null; }
    }

    public static void BackToRepository(GameObject GameObjectToReturn)
    {
        string keyReference = GameObjectToReturn.GetComponent<DirectoryKey>().TheKey;
        if (RepositoryObj.ContainsKey(keyReference))
        {
            GameObjectToReturn.transform.SetParent(null);
            GameObjectToReturn.transform.rotation = Quaternion.identity;
            RepositoryObj[GameObjectToReturn.GetComponent<DirectoryKey>().TheKey].Enqueue(GameObjectToReturn);
            GameObjectToReturn.SetActive(false);
        }
    }
    #endregion
}
