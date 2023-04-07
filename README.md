# ListOfIngredients

<h1> List of Ingredients Coding Challenge </h1>
<h2> Overview </h2>
This project displays the ingredients of a list of randomly picked menu items.
The ingredients are displayed in two format:
1st: Just a list of unique ingredients ordered alphabetically required for thge list of picked menu items 
2nd: In the form of key: values / menu item: ingredients 

<h2> How to Run </h2>
<ol>
  <li>Clone the repository on your local computer</li>
  <li>You can open the sln/solution file and run the project in visual studio with .Net core and C# programming language extensions</li>
  <li>Keep in mind that the ListOfIngredients/Menu_Items_With_Ingredients must be in a correct directory based on the operating system you are using</li>
</ol>

<h3> Notes </h3>
All the ingredients of each menu item could be stored in a dictionary in order to decrease the run-time complexity of finding the list of ingredients for the picked menu items.
But, it would increase the space complexity. For that reason, I'm reading all text file each time one wants to find all the ingredients of a list of 
picked menu items.
Depending on the size of the menu items, pipe delimited list of ingredients and the number of times the project is expected to be run, either of the approches 
has its own prons and cons.
