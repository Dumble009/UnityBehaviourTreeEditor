﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase : ScriptableObject
{
	public string caseName;
	public Dictionary<string, string> parameters;
	public List<string> otherNodes;
	public List<string> needToCallNodes;
	public string extraCondition;

	public void Init()
	{
		caseName = "";
		parameters = new Dictionary<string, string>();
		otherNodes = new List<string>();
		needToCallNodes = new List<string>();
		extraCondition = "";
	}
}
