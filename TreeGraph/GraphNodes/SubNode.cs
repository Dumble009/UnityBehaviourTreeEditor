﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class SubNode : Node, IBTGraphNode
{
    public string nodeName;
    
	[HideInInspector]
	public bool isInherited = false;

    public void Test(List<Node> nodes){
        if(string.IsNullOrEmpty(nodeName)){
            Debug.LogError(this.GetType().Name+":This node doesn't have any names.");
        }else{
            foreach(Node node in nodes){
                if(node is IBTGraphNode bt){
                    if(bt.GetNodeName() == this.nodeName && node != this){
                        Debug.LogError(nodeName+":This nodename is not unique.");
                    }
                }
            }
        }
    }

	public string GetNodeName()
	{
		return nodeName;
	}
	public void SetNodeName(string name)
	{
		nodeName = name;
	}

	virtual public string GetDeclare()
	{
		return "";
	}

	virtual public string GetInit()
	{
		return "";
	}

	virtual public void InheritFrom(Node original)
	{

	}
}
