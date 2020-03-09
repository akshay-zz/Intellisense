# Intellisense
Provide suggestion for Monaco editor 

It creates a suggestion javascript object (string) for Monaco editor. Need to evaluate this string and pass it as a suggestion object
to maonco editor. Right now it only supports Csharp IntelliSense. This project is created over .NET-Fiddle-Intelligent-Completion[https://github.com/ericpopivker/.NET-Fiddle-Intelligent-Completion]

Run the project. Then the server will get start on a particular port. We need to consume endpoint **GetAutoCompletion**

To get suggestion on the basis of cursor position<br>
**GetAutoCompletion** (POST)<br>
Json Body<br>
{
  "RawCode": "using",
  "Language":"Csharp",
  "Pos": "5"
}

**GetBasicAutoCompletion** [POST]<br>
To get basic fixed sugesstion, independent of cursor position.
Json Body<br>
{
  "Language":"Csharp"
}


A small demo has been added to the project in the home directory. Run the **monacoEditorPlain** in browser. This particular demo show 
suggestion when you type **.** in the editor on the basis of cursor position.
