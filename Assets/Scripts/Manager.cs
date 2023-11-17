using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{
    private static readonly Lazy<Manager> Instance = new(() => new Manager());
    public bool StartGame = false;

    private Manager(){}
    
    public static Manager GetInstance => Instance.Value;
}
