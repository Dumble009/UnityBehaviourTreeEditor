﻿using XNode;
using System.Collections.Generic;
public interface IBTGraphNode{
    string GetNodeName();
	void SetNodeName(string name);
    bool Test(List<Node> nodes);
	string GetDeclare();
    string GetInit();
	void InheritFrom(Node original);
}
