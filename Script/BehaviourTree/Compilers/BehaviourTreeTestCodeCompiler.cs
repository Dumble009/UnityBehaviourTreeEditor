﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;
using XNode;

[CreateAssetMenu(fileName = "BehaviourTreeTestCodeCompiler",
								menuName = "TestCodeCompilers/BehaviourTreeTestCodeCompiler")]
public class BehaviourTreeTestCodeCompiler : TestCodeCompiler
{
	List<string> createdNodes;
	public override void Compile(string fileName, List<Node> nodes)
	{
		Debug.Log("Start Compile");
		List<SubNode> subNodes = new List<SubNode>();
		createdNodes = new List<string>();
		RootNode root = new RootNode();
		foreach (Node node in nodes)
		{
			if (node is SubNode s)
			{
				subNodes.Add(s);
			}
			else if (node is RootNode r)
			{
				root = r;
			}
		}
		foreach (Node node in nodes)
		{
			if (node is RootNode r)
			{
				root = r;
			}
		}

		CodeTemplateReader.Init(Path.Combine(Application.dataPath, codeTemplatePath));

		string classTemplate = CodeTemplateReader.GetTemplate("Base", "Class");

		string className = FileNameToClassName(fileName);

		string declareParameters = "";
		declareParameters = BehaviourTreeCompilerCommon.GetDeclareParameters(nodes);

		string initParameters = "";
		var sortedSubNodes = subNodes
											.Where(x => x != null)
											.OrderBy(x => x.GetType().ToString())
											.ToArray();
		/*foreach (SubNode node in sortedSubNodes)
		{
			if (!node.isInherited)
			{
				CodeTemplateParameterHolder holder = node.GetParameterHolder();
				string key = node.GetKey();
				string source = CodeTemplateReader.GetTemplate("Declare", key);
				declareParameters += CodeTemplateInterpolator.Interpolate(source, holder);

				if (!(node is EventNode))
				{
					string initSource = CodeTemplateReader.GetTemplate("Init", "InitParameter");
					initParameters += CodeTemplateInterpolator.Interpolate(initSource, holder);
				}
			}
		}*/
		foreach (SubNode node in sortedSubNodes)
		{
			if (!(node is EventNode))
			{
				CodeTemplateParameterHolder holder = node.GetParameterHolder();
				string key = node.GetKey();
				string initSource = CodeTemplateReader.GetTemplate("Init", "InitParameter");
				initParameters += CodeTemplateInterpolator.Interpolate(initSource, holder);
			}
		}

		string constructedTree = "";
		constructedTree = BehaviourTreeCompilerCommon.GetConstructedTree(nodes);
		/*CodeTemplateParameterHolder rootParameter = root.GetParameterHolder();
		string rootKey = root.GetKey();
		string rootDeclare = CodeTemplateInterpolator.Interpolate(CodeTemplateReader.GetTemplate("Declare", rootKey), rootParameter);
		string rootInit = CodeTemplateInterpolator.Interpolate(CodeTemplateReader.GetTemplate("Init", rootKey), rootParameter);
		constructedTree += rootDeclare + rootInit;
		var rootChild = root.GetOutputPort("output").GetConnection(0).node as ITreeGraphNode;

		foreach (Node node in nodes)
		{
			if (!(node is SubNode) && !(node is RootNode))
			{
				if (node is ITreeGraphNode i)
				{
					CodeTemplateParameterHolder holder = i.GetParameterHolder();
					string key = i.GetKey();
					string source = CodeTemplateReader.GetTemplate("Declare", key);
					constructedTree += CodeTemplateInterpolator.Interpolate(source, holder) + "\n";
				}
			}
		}

		Node[] sortedNodes = nodes
											.Where(x => x != null)
											.OrderBy(x => x.position.y)
											.ToArray();
		foreach (Node node in sortedNodes)
		{
			if (!(node is SubNode))
			{
				if (node is ITreeGraphNode i)
				{
					if (!(node is RootNode))
					{
						CodeTemplateParameterHolder holder = i.GetParameterHolder();
						string key = i.GetKey();
						string source = CodeTemplateReader.GetTemplate("Init", key);
						constructedTree += CodeTemplateInterpolator.Interpolate(source, holder) + "\n";
					}
					var children = node.GetOutputPort("output").GetConnections()
											.OrderBy(x => x.node.position.y)
											.ToArray();
					foreach (NodePort port in children)
					{
						Node child = port.node;
						if (child is ITreeGraphNode i_child)
						{
							constructedTree += i.GetNodeName() + ".AddChild(" + i_child.GetNodeName() + ");\n";
						}
					}
				}
			}
		}*/

		//Init CalledFlag
		string initCalledFlag = "";
		var exNodes = nodes
								.Where(x => x  != null)
								.Where(x => {
									return x is ExecuteNode;
								})
								.Cast<ExecuteNode>()
								.ToArray();
		string initCalledFlagTemplate = CodeTemplateReader.GetTemplate("Test", "InitCalledFlag");
		foreach (var exNode in exNodes)
		{
			var parameterHolder = exNode.GetParameterHolder();
			initCalledFlag += CodeTemplateInterpolator.Interpolate(initCalledFlagTemplate, parameterHolder);
		}

		//Create TestCases
		string testCases = "";
		string functionTemplate = CodeTemplateReader.GetTemplate("Test", "TestFunction");
		var testRootNodes = nodes
								 .OfType<TestCaseRootNode>()
								 .ToArray();
		foreach (var testRoot in testRootNodes)
		{
			string testProcess = "";
			var current = testRoot.GetOutputPort("output").GetConnections().First().node;
			while (current is ITestTreeGraphNode i)
			{
				string template = CodeTemplateReader.GetTemplate("Test", i.GetKey());
				var parameterHolder = i.GetParameterHolder();
				testProcess += CodeTemplateInterpolator.Interpolate(template, parameterHolder);
				
				var connections = current.GetOutputPort("output").GetConnections().ToArray();
				if (connections.Length == 0)
				{
					break;
				}
				else
				{
					current = connections[0].node;
				}
			}

			var testCaseParameterHolder = new CodeTemplateParameterHolder();
			testCaseParameterHolder.SetParameter("functionName", testRoot.GetNodeName());
			testCaseParameterHolder.SetParameter("testProcess", testProcess);

			testCases += CodeTemplateInterpolator.Interpolate(functionTemplate, testCaseParameterHolder);
		}

		//string code = string.Format(template, className, inheritName, declareParameters, constructTree);
		CodeTemplateParameterHolder templateParameter = new CodeTemplateParameterHolder();
		templateParameter.SetParameter("className", className);
		templateParameter.SetParameter("declareParameters", declareParameters);
		templateParameter.SetParameter("initParameters", initParameters);
		templateParameter.SetParameter("constructTree", constructedTree);
		templateParameter.SetParameter("initCalledFlag", initCalledFlag);
		templateParameter.SetParameter("testCases", testCases);
		string code = CodeTemplateInterpolator.Interpolate(classTemplate, templateParameter);

		//Save TestCode file
		string path = EditorUtility.SaveFilePanelInProject("", className, "cs", "");
		if (!string.IsNullOrEmpty(path))
		{
			using (StreamWriter sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.ASCII))
			{
				sw.Write(code);
			}
			AssetDatabase.Refresh();
		}
	}
}
