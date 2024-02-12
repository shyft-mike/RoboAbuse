# RoboAbuse

This is a Unity project for ForgeFX authored by Michael Ferguson.

## Philosophy

My philosophy for these tasks was to make things as reusable and extensible as I could, within reason. I also tried to avoid putting code in the Update methods unless it was absolutely necessary. This resulted in several modular components that depend on Event handling as well as a bit of explicit setting up in the editor. I felt like this would result in a bit more work on the front end of things to get it all set up, but would ultimately make it more reusable and able to be extended as well as saving on performance (due to explicit checks rather than maybe doing something on Update and traversing components on the fly, etc). This does have setbacks, mostly that it can be tedious, as well as prone to mistakes in configuration.

## Usage

### Running

- Open the project in Unity
- Load MainScene (Scenes/MainScene)
- Press play in editor or press Ctrl + B to build and run

### Feature 1 - Camera Movement

Controls for camera movement

- W - move forward
- A - strafe left
- S - move backwards
- D - strafe right
- Q - rotate left
- E - rotate right
- Spacebar - move up
- Left Ctrl - move down

> Notes: could provide visual representation of these controls in the UI. Could also include a "Reset Camera" button.

> See: [CameraController.cs](Assets/Components/CameraController.cs)

### Feature 2 - Robot Highlighting

- Hovering the mouse over the torso of the robot should result in a green highlight on the entire robot
- If the arms are detached they should not receive highlighting

> Notes: I was up in the air on using the "Highlighter" component, since I could have set things up to just check for child Highlightable components. Keeping it results in a little extra code handling detachment, but it allows for highlighting objects outside of the current GameObject tree.

> See: [Highlighter.cs](Assets/Components/Highlighter.cs), [Highlightable.cs](Assets/Components/Highlightable.cs)

### Feature 3 - Robot Movement

- Left clicking on the torso of the robot and dragging should result in translation of all attached parts
- If either of the arms is detached they will not move with the robot

> See: [MouseEventManager.cs](Assets/Components/MouseEventManager/MouseEventManager.cs), [Moveable.cs](Assets/Components/Moveable.cs)

### Feature 4 - Robot Arm Highlighting

- Hovering the mouse over any part of the robot arms should result in a green highlight on the entire arm
- Highlighting should occur whether attached or not

> See: [Highlighter.cs](Assets/Components/Highlighter.cs), [Highlightable.cs](Assets/Components/Highlightable.cs)

### Feature 5/6/7 - Robot Arm Detach/Attach

- Clicking the mouse on any part of the robot arm and dragging should start moving the arm
- Once it reaches the arbitrary "Detach Threshold" the UI should alert it is detached, and once the mouse is released the arm should remain in place
- Clicking and dragging the arm back within the detach threshold should cause the UI to update that it is attached, and releasing the mouse should cause the arm to snap into place

> See: [MouseEventManager.cs](Assets/Components/MouseEventManager/MouseEventManager.cs), [Moveable.cs](Assets/Components/Moveable.cs), [Detachable.cs](Assets/Components/Detachable/Detachable.cs), [AttachPoint.cs](Assets/Components/AttachPoint.cs), [StatusPanel.cs](Assets/Scenes/StatusPanel.cs)

### Feature 8 - Unit Tests

- Running tests in the test runner should all pass

> See [Components/Tests](Assets/Components/Tests/)
