using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject nearestLoot; // ��������� ������� ��� �������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // ���� ������ ������� H
        {
            PickUpNearestLoot(); // �������� ����� ��� ������� ���������� ��������
        }
    }

    void PickUpNearestLoot()
    {
        GameObject[] lootObjects = GameObject.FindGameObjectsWithTag("loot"); // ������� ��� ������� � ����� "loot"
        float nearestDistance = Mathf.Infinity; // ��������� �������� ���������� �� ���������� ��������

        foreach (GameObject lootObject in lootObjects)
        {
            float distance = Vector3.Distance(transform.position, lootObject.transform.position); // ���������� �� �������� ��������

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestLoot = lootObject; // ��������� ��������� �������
            }
        }

        if (nearestLoot != null)
        {
            Debug.Log("�������� �������: " + nearestLoot.name);
            Destroy(nearestLoot); // ������� ����������� ������� �� �����
        }
        else
        {
            Debug.Log("���������� ��������� �� �������.");
        }
    }
}
