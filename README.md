CSDX
====

C#/DirectX based graphics coding framework based on SharpDX (http://www.sharpdx.org)

The idea behind this project was to create a new graphics coding framework in the same vein as Processing, openFrameworks and Cinder, for C# and .NET programmers or those wanting to learn C# as well as the workings of DirectX.

Currently, the codebase is fairly small.  All you can really do is create ellipses and rectangles, but I want to fully flush this out.

============================================================

The current codebase

CSDX
---------
This is the main library.  Contains calls to SharpDX functionality and abstracts a lot of the time-consuming and difficult stuff.

CSDXCore is  the main class of the library.  Used to create the DX window and will contain static calls to other classes in the library.

ExampleSketch
---------------------
The ExampleSketch is fairly basic.  Program.cs creates a reference to the main class where all setup and drawing will be done and then calls Setup and StartDraw to begin the render loop.

ExampleSketch.cs inherits from CSDXCore and overrides the Setup() and Draw() calls.  These two methods will be where most of the work is done and are both required.

=============================================================

Future plans
----------------

I'd like to build a template to automatically create the Program.cs and the main cs file and take any confusion out of the users hands.

Otherwise it's basically creating new methods as I/we see fit and getting this thing off the ground.

Also, a learning experience for me to learn a lot more about programming and DirectX.
