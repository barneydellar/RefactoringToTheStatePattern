<style>
label{
    color:orange;
}
heading{
    color:firebrick;
    font-weight: bold;
}
</style>
# <heading>Instructions</heading>

## <heading>Introduction</heading>

This kata is designed to help you learn how to refactor to the State pattern (https://refactoring.guru/design-patterns/state)

There is a class called Widget, which has complicated state transitions, and different behaviour in each state. 
Your goal is to create classes for each state, and to move the logic into these classes.

There are existing tests which should be comprehensive enough to give you a safety harness as you refactor.

You should be able to refactor in small incremental steps, and make sure that the tests are passing after each step.

## <heading>Step 1: Call setters/getters instead of private data</heading>

Create Set/Get methods for all private data on Widget. Use these methods instead of directly accessing the private data.

## <heading>Step 2: Create a State base class</heading>

Create a new IState interface. This should have the same public API as Widget, except that each function will also take in a reference to the Widget.

Create an implementation of IState, called something like DefaultState.

<label>Compile and run the tests. Commit if they pass.</label>

## <heading>Step 3: Move logic into States</heading>

In Widget, create a member pointer to an IState, and initialise it to point to an instance of DefaultState. 

<label>Compile and run the tests. Commit if they pass.</label>

Move all of the logic in the Mouse and Key functions into DefaultState. 

Replace the logic in Widget with calls to the IState member.

<label>As you move each function, Compile and run the tests. Commit if they pass.</label>

## <heading>Step 4: Replace type code with objects</heading>

In IState, change IState to have a MouseState member, and remove it from Widget.

Update the constructor for DefaultState to take in the MouseState.

Change the get function in Widget to get the MouseState from the IState that it owns. 

Change the set function in Widget with a function that sets the MouseState on the IState that it owns.

<label>Compile and run the tests. Commit if they pass.</label>

Replace the set function with one that takes in an IState and replaces the IState member.

In DefaultState, change calls to set the MouseState, to instead construct a new DefaultState with the appropriate MouseState, and set the new DefaultState on the widget.

<label>Compile and run the tests. Commit if they pass.</label>

## <heading>Step 5: Create derived State classes</heading>

Create six implementations of IState: one for each value of MouseState.

The constructors should take no argument, but should provide the relevant MouseState value to the IState base class.

<label>Compile and run the tests. Commit if they pass.</label>

In turn, replace each of calls to construct a new IState, with calls to create one of the derived types.

<label>Compile and run tests</label> after each change.

## <heading>Step 6: Move logic into State classes</heading>

Pick some code that switches on the type. For example:

```cpp
// DefaultState
void MouseDown(Widget widget) {
    if (widget.GetMouseState() == MouseUpState) {
        widget.SetMouseState(new MouseDownState);
    }
    ...
}
```

Move this logic into the derived class. In this case, create an override implementation of MouseDown() in the derived MouseUp class, and move just the code that sets the mouse state into it.

```cpp
// MouseUpState
void MouseDown(Widget) {
    w.SetMouseState(new MouseDownState);
}
```

<label>Compile and run tests</label> after each change.

Be warned that some of the conditional logic is entangled. For example, it might change the state, and then later in the same function, see if the state is now in that new state and do some more logic.

You should end up with the methods in DefaultState completely empty, and it should now be unused, so delete it. 

## <heading>Step 7: Remove the type code</heading>

You can now remove the MouseState enum and the MouseState member variables.

<label>Compile and run the tests. Commit if they pass.</label>

## <heading>Step 8: Consider a base class</heading>

If you're in a language like C#, then you have to implement all of the methods on an interface. But many of the state classes now have empty methods. You could consider making all state classes inherit from a base class which in turn implements the IState interface. Bu default, this base class could implement all of the methods to do nothing. This will tidy up the individual State classes.

## <heading>Step 9: Apply the Law Of Demeter</heading>

The derived classes of IState are now accessing functions such as ```DrawLine()``` from Canvas via the Widget.

This breaks the Law Of Demeter. 

Instead, remove the Canvas accessor, and instead provide functions on Widget such as ```DrawLine()```.

<label>Admire your work :)</label>