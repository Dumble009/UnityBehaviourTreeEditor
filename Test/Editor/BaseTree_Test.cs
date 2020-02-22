using BT;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BaseTree_Test
{
BehaviourTree behaviourTree;
Dictionary<string, bool> calledFlag;
[UnityEngine.SerializeField]
public bool case2 = false;[UnityEngine.SerializeField]
public bool case3 = false;[UnityEngine.SerializeField]
public bool if_bool1 = false;[UnityEngine.SerializeField]
public bool case4 = false;[UnityEngine.SerializeField]
public bool while_bool1 = false;[UnityEngine.SerializeField]
public bool case5 = false;[UnityEngine.SerializeField]
public bool selector_bool1 = false;[UnityEngine.SerializeField]
public bool case6 = false;[UnityEngine.SerializeField]
public bool sequence_bool1 = false;[UnityEngine.SerializeField]
public bool case7 = false;[UnityEngine.SerializeField]
public bool case8 = false;[UnityEngine.SerializeField]
public bool case9 = false;[UnityEngine.SerializeField]
public bool case10 = false;[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent first_ev = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent itr_ev = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent if_ev1 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent if_ev2 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent if_ev3 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent while_ev1 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent while_ev2 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent selector_ev1 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent selector_ev2 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent selector_ev3 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent sequence_ev1 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent sequence_ev2 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent sequence_ev3 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent frameCounter_ev1 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent frameCounter_ev2 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent frameCounter_ev3 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent frameCounter_ev4 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent frameCounter_ev5 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent timerTest_ev1 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent timerTest_ev2 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent timerTest_ev3 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent timerTest_ev4 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public UnityEngine.Events.UnityEvent timerTest_ev5 = new UnityEngine.Events.UnityEvent();
[UnityEngine.SerializeField]
public float if_float1 = 100.5f;[UnityEngine.SerializeField]
int if_int1 = 0;

void InitParameters()
{
case2 =  false;
case3 =  false;
if_bool1 =  false;
case4 =  false;
while_bool1 =  false;
case5 =  false;
selector_bool1 =  false;
case6 =  false;
sequence_bool1 =  false;
case7 =  false;
case8 =  false;
case9 =  false;
case10 =  false;
if_float1 =  100.5f;
if_int1 =  0;

}

void ResetCalledFlag(){
var keys = calledFlag.Keys.ToArray();
foreach(var key in keys)
{
	calledFlag[key] = false;
}
}

[SetUp]
public void Init()
{
BT_Root root = new BT_Root();behaviourTree = new BehaviourTree(root);BT_Execute firstEx = new BT_Execute();
BT_Interrupt itr_1 = new BT_Interrupt();
BT_Execute itrEx = new BT_Execute();
BT_Interrupt itr_2 = new BT_Interrupt();
BT_If if1 = new BT_If();
BT_Execute ifEx1 = new BT_Execute();
BT_If if2 = new BT_If();
BT_Execute ifEx2 = new BT_Execute();
BT_If if3 = new BT_If();
BT_Execute ifEx3 = new BT_Execute();
BT_Interrupt itr_3 = new BT_Interrupt();
BT_While while1 = new BT_While();
BT_Execute whileEx1 = new BT_Execute();
BT_Execute whileEx2 = new BT_Execute();
BT_Interrupt itr_4 = new BT_Interrupt();
BT_Selector selector1 = new BT_Selector();
BT_Execute selectorEx2 = new BT_Execute();
BT_If selectorIf1 = new BT_If();
BT_Execute selectorEx1 = new BT_Execute();
BT_Execute selectorEx3 = new BT_Execute();
BT_Interrupt SequenceTest = new BT_Interrupt();
BT_Sequence sequence1 = new BT_Sequence();
BT_Execute sequenceEx1 = new BT_Execute();
BT_If sequenceIf1 = new BT_If();
BT_Execute sequenceEx2 = new BT_Execute();
BT_Execute sequenceEx3 = new BT_Execute();
BT_Interrupt frameCounterTest = new BT_Interrupt();
BT_Execute frameCounterEx1 = new BT_Execute();
BT_Timing frameCounter1 = new BT_Timing(behaviourTree, false, false);
BT_Interrupt frameCounterTest2 = new BT_Interrupt();
BT_Execute frameCounterEx2 = new BT_Execute();
BT_Interrupt frameCounterTest3 = new BT_Interrupt();
BT_Execute frameCounterEx3 = new BT_Execute();
BT_Timing frameCounter2 = new BT_Timing(behaviourTree, false, true);
BT_Interrupt frameCounterTest4 = new BT_Interrupt();
BT_Execute frameCounterEx4 = new BT_Execute();
BT_Timing frameCounter3 = new BT_Timing(behaviourTree, true, false);
BT_Interrupt frameCounterTest5 = new BT_Interrupt();
BT_Execute frameCounterEx5 = new BT_Execute();
BT_Interrupt timerTest = new BT_Interrupt();
BT_Execute timerTestEx1 = new BT_Execute();
BT_Timing timer1 = new BT_Timing(behaviourTree, false, false);
BT_Interrupt timerTest2 = new BT_Interrupt();
BT_Execute timerTestEx2 = new BT_Execute();
BT_Interrupt timerTest3 = new BT_Interrupt();
BT_Execute timerTestEx3 = new BT_Execute();
BT_Timing timer2 = new BT_Timing(behaviourTree, false, true);
BT_Interrupt timerTest4 = new BT_Interrupt();
BT_Execute timerTestEx4 = new BT_Execute();
BT_Timing timer3 = new BT_Timing(behaviourTree, true, false);
BT_Interrupt timerTest5 = new BT_Interrupt();
BT_Execute timerTestEx5 = new BT_Execute();
firstEx.AddEvent(()=>{
	first_ev.Invoke();
});
root.AddChild(firstEx);
itr_1.SetCondition(()=>{
	return case2;
});
behaviourTree.AddInterrupt(itr_1);
itr_1.AddChild(itrEx);
itrEx.AddEvent(()=>{
	itr_ev.Invoke();
});
itr_2.SetCondition(()=>{
	return case3;
});
behaviourTree.AddInterrupt(itr_2);
itr_2.AddChild(if1);
if1.SetCondition(()=>{
	return if_bool1;
});
if1.AddChild(ifEx1);
ifEx1.AddEvent(()=>{
	if_ev1.Invoke();
});
ifEx1.AddChild(if2);
if2.SetCondition(()=>{
	return if_int1 > 10;
});
if2.AddChild(ifEx2);
ifEx2.AddEvent(()=>{
	if_ev2.Invoke();
});
ifEx2.AddChild(if3);
if3.SetCondition(()=>{
	return if_float1 < 10.0f;
});
if3.AddChild(ifEx3);
ifEx3.AddEvent(()=>{
	if_ev3.Invoke();
});
while1.SetCondition(()=>{
	return while_bool1;
});
while1.AddChild(whileEx2);
itr_3.SetCondition(()=>{
	return case4;
});
behaviourTree.AddInterrupt(itr_3);
itr_3.AddChild(whileEx1);
whileEx1.AddEvent(()=>{
	while_ev1.Invoke();
});
whileEx1.AddChild(while1);
whileEx2.AddEvent(()=>{
	while_ev2.Invoke();
});
selectorIf1.SetCondition(()=>{
	return selector_bool1;
});
selectorIf1.AddChild(selectorEx1);
selectorEx1.AddEvent(()=>{
	selector_ev1.Invoke();
});
itr_4.SetCondition(()=>{
	return case5;
});
behaviourTree.AddInterrupt(itr_4);
itr_4.AddChild(selector1);

selector1.AddChild(selectorIf1);
selector1.AddChild(selectorEx2);
selector1.AddChild(selectorEx3);
selectorEx2.AddEvent(()=>{
	selector_ev2.Invoke();
});
selectorEx3.AddEvent(()=>{
	selector_ev3.Invoke();
});
sequenceEx1.AddEvent(()=>{
	sequence_ev1.Invoke();
});
SequenceTest.SetCondition(()=>{
	return case6;
});
behaviourTree.AddInterrupt(SequenceTest);
SequenceTest.AddChild(sequence1);

sequence1.AddChild(sequenceEx1);
sequence1.AddChild(sequenceIf1);
sequence1.AddChild(sequenceEx3);
sequenceIf1.SetCondition(()=>{
	return sequence_bool1
;
});
sequenceIf1.AddChild(sequenceEx2);
sequenceEx2.AddEvent(()=>{
	sequence_ev2.Invoke();
});
sequenceEx3.AddEvent(()=>{
	sequence_ev3.Invoke();
});
frameCounterEx2.AddEvent(()=>{
	frameCounter_ev2.Invoke();
});
frameCounterTest.SetCondition(()=>{
	return case7;
});
behaviourTree.AddInterrupt(frameCounterTest);
frameCounterTest.AddChild(frameCounterEx1);
frameCounter1.SetTimingCreator(()=>{
	return new FrameCounter(frameCounterTest2, 1);
});
frameCounterTest2.SetCondition(()=>{
	return false;
});
behaviourTree.AddInterrupt(frameCounterTest2);
frameCounterTest2.AddChild(frameCounterEx2);
frameCounterEx1.AddEvent(()=>{
	frameCounter_ev1.Invoke();
});
frameCounterEx1.AddChild(frameCounter1);
frameCounterTest3.SetCondition(()=>{
	return case8;
});
behaviourTree.AddInterrupt(frameCounterTest3);
frameCounterTest3.AddChild(frameCounterEx3);
frameCounterEx3.AddEvent(()=>{
	frameCounter_ev3.Invoke();
});
frameCounterEx3.AddChild(frameCounter2);
frameCounter2.SetTimingCreator(()=>{
	return new FrameCounter(frameCounterTest4, 1);
});
frameCounterTest4.SetCondition(()=>{
	return false;
});
behaviourTree.AddInterrupt(frameCounterTest4);
frameCounterTest4.AddChild(frameCounterEx4);
frameCounterEx4.AddEvent(()=>{
	frameCounter_ev4.Invoke();
});
frameCounterEx4.AddChild(frameCounter3);
frameCounter3.SetTimingCreator(()=>{
	return new FrameCounter(frameCounterTest5, 1);
});
frameCounterTest5.SetCondition(()=>{
	return false;
});
behaviourTree.AddInterrupt(frameCounterTest5);
frameCounterTest5.AddChild(frameCounterEx5);
frameCounterEx5.AddEvent(()=>{
	frameCounter_ev5.Invoke();
});
timerTest.SetCondition(()=>{
	return case9;
});
behaviourTree.AddInterrupt(timerTest);
timerTest.AddChild(timerTestEx1);
timerTestEx1.AddEvent(()=>{
	timerTest_ev1.Invoke();
});
timerTestEx1.AddChild(timer1);
timer1.SetTimingCreator(()=>{
	return new Timer(timerTest2, 3);
});
timerTest2.SetCondition(()=>{
	return false;
});
behaviourTree.AddInterrupt(timerTest2);
timerTest2.AddChild(timerTestEx2);
timerTestEx2.AddEvent(()=>{
	timerTest_ev2.Invoke();
});
timerTest3.SetCondition(()=>{
	return case10;
});
behaviourTree.AddInterrupt(timerTest3);
timerTest3.AddChild(timerTestEx3);
timerTestEx3.AddEvent(()=>{
	timerTest_ev3.Invoke();
});
timerTestEx3.AddChild(timer2);
timer2.SetTimingCreator(()=>{
	return new Timer(timerTest4, 1.5);
});
timerTest4.SetCondition(()=>{
	return false;
});
behaviourTree.AddInterrupt(timerTest4);
timerTest4.AddChild(timerTestEx4);
timerTestEx4.AddEvent(()=>{
	timerTest_ev4.Invoke();
});
timerTestEx4.AddChild(timer3);
timer3.SetTimingCreator(()=>{
	return new Timer(timerTest5, 3);
});
timerTest5.SetCondition(()=>{
	return false;
});
behaviourTree.AddInterrupt(timerTest5);
timerTest5.AddChild(timerTestEx5);
timerTestEx5.AddEvent(()=>{
	timerTest_ev5.Invoke();
});


calledFlag = new Dictionary<string, bool>();
calledFlag.Add("firstEx", false);
first_ev.AddListener(()=>{
	calledFlag["firstEx"] = true;
});calledFlag.Add("itrEx", false);
itr_ev.AddListener(()=>{
	calledFlag["itrEx"] = true;
});calledFlag.Add("ifEx1", false);
if_ev1.AddListener(()=>{
	calledFlag["ifEx1"] = true;
});calledFlag.Add("ifEx2", false);
if_ev2.AddListener(()=>{
	calledFlag["ifEx2"] = true;
});calledFlag.Add("ifEx3", false);
if_ev3.AddListener(()=>{
	calledFlag["ifEx3"] = true;
});calledFlag.Add("whileEx1", false);
while_ev1.AddListener(()=>{
	calledFlag["whileEx1"] = true;
});calledFlag.Add("whileEx2", false);
while_ev2.AddListener(()=>{
	calledFlag["whileEx2"] = true;
});calledFlag.Add("selectorEx2", false);
selector_ev2.AddListener(()=>{
	calledFlag["selectorEx2"] = true;
});calledFlag.Add("selectorEx1", false);
selector_ev1.AddListener(()=>{
	calledFlag["selectorEx1"] = true;
});calledFlag.Add("selectorEx3", false);
selector_ev3.AddListener(()=>{
	calledFlag["selectorEx3"] = true;
});calledFlag.Add("sequenceEx1", false);
sequence_ev1.AddListener(()=>{
	calledFlag["sequenceEx1"] = true;
});calledFlag.Add("sequenceEx2", false);
sequence_ev2.AddListener(()=>{
	calledFlag["sequenceEx2"] = true;
});calledFlag.Add("sequenceEx3", false);
sequence_ev3.AddListener(()=>{
	calledFlag["sequenceEx3"] = true;
});calledFlag.Add("frameCounterEx1", false);
frameCounter_ev1.AddListener(()=>{
	calledFlag["frameCounterEx1"] = true;
});calledFlag.Add("frameCounterEx2", false);
frameCounter_ev2.AddListener(()=>{
	calledFlag["frameCounterEx2"] = true;
});calledFlag.Add("frameCounterEx3", false);
frameCounter_ev3.AddListener(()=>{
	calledFlag["frameCounterEx3"] = true;
});calledFlag.Add("frameCounterEx4", false);
frameCounter_ev4.AddListener(()=>{
	calledFlag["frameCounterEx4"] = true;
});calledFlag.Add("frameCounterEx5", false);
frameCounter_ev5.AddListener(()=>{
	calledFlag["frameCounterEx5"] = true;
});calledFlag.Add("timerTestEx1", false);
timerTest_ev1.AddListener(()=>{
	calledFlag["timerTestEx1"] = true;
});calledFlag.Add("timerTestEx2", false);
timerTest_ev2.AddListener(()=>{
	calledFlag["timerTestEx2"] = true;
});calledFlag.Add("timerTestEx3", false);
timerTest_ev3.AddListener(()=>{
	calledFlag["timerTestEx3"] = true;
});calledFlag.Add("timerTestEx4", false);
timerTest_ev4.AddListener(()=>{
	calledFlag["timerTestEx4"] = true;
});calledFlag.Add("timerTestEx5", false);
timerTest_ev5.AddListener(()=>{
	calledFlag["timerTestEx5"] = true;
});
}

[Test]
public void ExecuteTest()
{
InitParameters();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["firstEx"]);

ResetCalledFlag();
}[Test]
public void InterruptTest()
{
InitParameters();
case2 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["itrEx"]);

ResetCalledFlag();
}[Test]
public void IfTest()
{
InitParameters();
case3 = true;
if_bool1 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["ifEx1"]);
Assert.AreEqual(false, calledFlag["ifEx2"]);
Assert.AreEqual(false, calledFlag["ifEx3"]);
ResetCalledFlag();
if_int1 = 100;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["ifEx1"]);
Assert.AreEqual(true, calledFlag["ifEx2"]);
Assert.AreEqual(false, calledFlag["ifEx3"]);
ResetCalledFlag();
if_float1 = -100.05f;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["ifEx1"]);
Assert.AreEqual(true, calledFlag["ifEx2"]);
Assert.AreEqual(true, calledFlag["ifEx3"]);

ResetCalledFlag();
}[Test]
public void WhileTest()
{
InitParameters();
case4 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["whileEx1"]);
Assert.AreEqual(false, calledFlag["whileEx2"]);
ResetCalledFlag();
while_bool1 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["whileEx1"]);

ResetCalledFlag();
}[Test]
public void SelectorTest()
{
InitParameters();
case5 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["selectorEx1"]);
Assert.AreEqual(true, calledFlag["selectorEx2"]);
Assert.AreEqual(false, calledFlag["selectorEx3"]);
ResetCalledFlag();
selector_bool1 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["selectorEx1"]);
Assert.AreEqual(false, calledFlag["selectorEx2"]);
Assert.AreEqual(false, calledFlag["selectorEx3"]);

ResetCalledFlag();
}[Test]
public void SequenceTest()
{
InitParameters();
case6 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["sequenceEx1"]);
Assert.AreEqual(false, calledFlag["sequenceEx2"]);
Assert.AreEqual(false, calledFlag["sequenceEx3"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["sequenceEx1"]);
Assert.AreEqual(false, calledFlag["sequenceEx2"]);
Assert.AreEqual(false, calledFlag["sequenceEx3"]);
ResetCalledFlag();
sequence_bool1 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["sequenceEx1"]);
Assert.AreEqual(true, calledFlag["sequenceEx2"]);
Assert.AreEqual(false, calledFlag["sequenceEx3"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["sequenceEx1"]);
Assert.AreEqual(false, calledFlag["sequenceEx2"]);
Assert.AreEqual(true, calledFlag["sequenceEx3"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["sequenceEx1"]);
Assert.AreEqual(false, calledFlag["sequenceEx2"]);
Assert.AreEqual(false, calledFlag["sequenceEx3"]);

ResetCalledFlag();
}[Test]
public void FrameCounterTest()
{
InitParameters();
case7 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["frameCounterEx1"]);
Assert.AreEqual(false, calledFlag["frameCounterEx2"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["frameCounterEx1"]);
Assert.AreEqual(false, calledFlag["frameCounterEx2"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["frameCounterEx1"]);
Assert.AreEqual(true, calledFlag["frameCounterEx2"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["frameCounterEx1"]);
Assert.AreEqual(false, calledFlag["frameCounterEx2"]);

ResetCalledFlag();
}[Test]
public void FrameCounterTest2()
{
InitParameters();
case8 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["frameCounterEx3"]);
Assert.AreEqual(false, calledFlag["frameCounterEx4"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["frameCounterEx3"]);
Assert.AreEqual(true, calledFlag["frameCounterEx4"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["frameCounterEx3"]);
Assert.AreEqual(true, calledFlag["frameCounterEx4"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["frameCounterEx3"]);
Assert.AreEqual(false, calledFlag["frameCounterEx4"]);
ResetCalledFlag();
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["frameCounterEx3"]);
Assert.AreEqual(false, calledFlag["frameCounterEx4"]);
Assert.AreEqual(true, calledFlag["frameCounterEx5"]);

ResetCalledFlag();
}[Test]
public void TimerTest1()
{
InitParameters();
case9 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["timerTestEx1"]);
Assert.AreEqual(false, calledFlag["timerTestEx2"]);
ResetCalledFlag();
System.Threading.Thread.Sleep((int)(1.5 * 1000));
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["timerTestEx1"]);

ResetCalledFlag();
}[Test]
public void TimerTest2()
{
InitParameters();
case10 = true;
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["timerTestEx3"]);
Assert.AreEqual(false, calledFlag["timerTestEx4"]);
Assert.AreEqual(false, calledFlag["timerTestEx5"]);
ResetCalledFlag();
System.Threading.Thread.Sleep((int)(0.8 * 1000));
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["timerTestEx3"]);
Assert.AreEqual(false, calledFlag["timerTestEx4"]);
Assert.AreEqual(false, calledFlag["timerTestEx5"]);
ResetCalledFlag();
System.Threading.Thread.Sleep((int)(0.8 * 1000));
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["timerTestEx3"]);
Assert.AreEqual(true, calledFlag["timerTestEx4"]);
Assert.AreEqual(false, calledFlag["timerTestEx5"]);
ResetCalledFlag();
System.Threading.Thread.Sleep((int)(2 * 1000));
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["timerTestEx3"]);
Assert.AreEqual(true, calledFlag["timerTestEx4"]);
Assert.AreEqual(false, calledFlag["timerTestEx5"]);
ResetCalledFlag();
System.Threading.Thread.Sleep((int)(2 * 1000));
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(true, calledFlag["timerTestEx3"]);
Assert.AreEqual(false, calledFlag["timerTestEx4"]);
Assert.AreEqual(false, calledFlag["timerTestEx5"]);
ResetCalledFlag();
System.Threading.Thread.Sleep((int)(1.2 * 1000));
for(int __i__ = 0; __i__ < 1; __i__++){
	behaviourTree.Tick();
}
Assert.AreEqual(false, calledFlag["timerTestEx3"]);
Assert.AreEqual(false, calledFlag["timerTestEx4"]);
Assert.AreEqual(true, calledFlag["timerTestEx5"]);

ResetCalledFlag();
}
}