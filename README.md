In response to a Stackoverflow member's question, I wrote and posted some code. Later I completed it and put it on GitHub
The question was:

How to set the alignment and font in a custom textbox on edit mode?
The custom textbox displays the text as expected when not on edit mode, how to show the text vertically centered, with the same font and not overlapped in edit mode?
The textbox must allow setting the height without affecting the font size or vice versa.

Question link:

https://stackoverflow.com/questions/78654484/how-to-set-the-alignment-and-font-in-a-custom-textbox-on-edit-mode/78655324#78655324

Approach:

Since changing the drawing functions for Windows form components is a bit complicated and requires careful attention to many undocumented issues, and on the other hand, there is no guarantee that it will work exactly right in future versions of Windows, I suggest a simpler method:

Create a UserControl that does not inherit from TextBox and override its content as the repository codes.
It should be noted that the following properties can be adjusted in the form and the changes are applied in the Visual Studio form at the design time and before execution.

This code was developed in Visual Studio 2022 with .NET 4.6.2 on Windows 11.

Public Properties:

BorderColor

BorderThickness

BackColor

ForeColor

Font

Text

Multiline

TextAlign

