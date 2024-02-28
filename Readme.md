# <heading>Instructions</heading>

## <heading>Introduction</heading>

This kata is designed to help you learn how to refactor to the State pattern.

There is a class called Widget, which has complicated state transitions, and different behaviour in each state. 

A Widget can receive mouse messages, such as MouseMove, or MouseDown, and it notes the current state of the mouse, and 
draws lines on a canvas in response to the mouse actions.

The state logic is complicated, and could be better expressed as the State Pattern. 
Have a look here: https://refactoring.guru/design-patterns/state.

Your goal is to create classes for each state, and to move the logic into these classes.

There are existing tests which should be comprehensive enough to give you a safety harness as you refactor.

You should be able to refactor in small incremental steps, and make sure that the tests are passing after each step.

## <heading>Step 1: Call setters/getters instead of private data</heading>

Create public Set/Get methods for all private data on Widget. Use these methods instead of directly accessing the 
private data.

**Compile and run the tests. Commit if they pass.**

## <heading>Step 2: Create a State base class</heading>

Create a new IState interface. This should have the same public API as Widget, except that each function will also take 
in a reference to the Widget.

Create an implementation of IState, called something like DefaultState.

**Compile and run the tests. Commit if they pass.**

## <heading>Step 3: Move logic into States</heading>

In Widget, create an IState member, and initialise it to point to an instance of DefaultState. 

**Compile and run the tests. Commit if they pass.**

Move all of the logic in the Mouse and Key functions into DefaultState. 

Replace the logic in Widget with calls to the IState member.

**As you move each function, Compile and run the tests. Commit if they pass.**

## <heading>Step 4: Replace type code with objects</heading>

Change DefaultState to have a Mouse member, and remove it from Widget. But keep the Mouse getters/setters in Widget.

Add Mouse Getters/Setters to IState and implement them in DefaultState.

Update the constructor for DefaultState to take in the Mouse.

Change the Mouse getter function in Widget to get the Mouse from the IState that it owns. 

Change the Mouse setter function in Widget with a function that sets the Mouse on the IState that it owns.

At this point, when the DefaultState needs the Mouse value, it should ask the Widget, which should ask back to the 
DefaultState. This might seem wrong, but it's a useful step.

**Compile and run the tests. Commit if they pass.**

Replace the Mouse setter function with one that takes in an IState and replaces the IState member.

In DefaultState, change calls that set the Mouse to instead construct a new DefaultState with the appropriate Mouse, 
and set the new DefaultState on the widget.

**Compile and run the tests. Commit if they pass.**

## <heading>Step 5: Create derived State classes</heading>

Create six implementations of IState: one for each value of Mouse. Do this by deriving from DefaultState

The constructors should take no argument, but should provide the relevant Mouse value to the base class.

Make the DefaultState constructor protected.

**Compile and run the tests. Commit if they pass.**

In turn, replace each of the calls to construct a new IState, with calls to create one of the derived types.

**Compile and run tests** after each change.

## <heading>Step 6: Move logic into State classes</heading>

Pick some code that switches on the type. For example:

```cpp
// DefaultState
void MouseDown(Widget widget) {
    if (widget.GetMouse() == MouseUpState) {
        widget.SetMouse(new MouseDownState);
    }
    ...
}
```

Move this logic into the derived class. In this case, create an override implementation of MouseDown() in the derived 
MouseUp class, and move just the code that sets the mouse state into it.

```cpp
// MouseUpState
void MouseDown(Widget) {
    w.SetMouse(new MouseDownState);
}
```

**Compile and run tests** after each change.

Be warned that some of the conditional logic is entangled. For example, it might change the state, and then later in 
the same function, see if the state is now in that new state and do some more logic.

You should end up with the methods in DefaultState completely empty, and it should now be unused, so delete it. 

## <heading>Step 7: Remove the type code</heading>

You can now remove the Mouse enum and the Mouse member variables.

**Compile and run the tests. Commit if they pass.**

## <heading>Step 8: Remove the back-reference</heading>

Currently we're providing a Widget reference to the IState methods, so that the states can change the
state held by the widget.

Change the IState API to return an IState, instead. Whenever the widget calls an IState method, it
should update its reference.

## <heading>Step 9: Apply the Law Of Demeter</heading>

The derived classes of IState are now accessing functions such as ```DrawLine()``` from Canvas via the Widget.

This breaks the Law Of Demeter. 

Instead, remove the Canvas accessor, and instead provide functions on Widget such as ```DrawLine()```.

**Admire your work :)**