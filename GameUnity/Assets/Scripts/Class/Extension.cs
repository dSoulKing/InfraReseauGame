﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static void CenterOnChildred(this Transform aParent)
    {
        var childs = aParent.Cast<Transform>().ToList();
        var pos = Vector3.zero;
        foreach (var C in childs)
        {
            pos += C.position;
            C.parent = null;
        }
        pos /= childs.Count;
        aParent.position = pos;
        foreach (var C in childs)
            C.parent = aParent;
    }
}
