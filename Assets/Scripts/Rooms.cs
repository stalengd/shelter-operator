using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : SingletonMonoBehaviour<Rooms>
{
    [SerializeField] private List<Room> roomsList;

    public static List<Room> RoomsList => Instance.roomsList;
}