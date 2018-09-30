# folkefinans-stock-productivity
Programming test for Folkefinans.

Notes:
~~~~~~
1. As the "programming_test.pdf" mentioned specific usage of web forms / web api, choice was made as web api in web forms. 
This is quite handy in web forms projects that need to make use of server api to perform certain tasks.

2. Styling is not taken into consideration. Used the ASP.NET web forms basic skeleton. Functionalities implemente using basic asp tables and textboxes

3. In "View Calculated Result" page, detailed resuls table is populated using postback call. This could have alternatively been handled using ajax and jquery. 
However, as these were not explicitly mentioned, relied on implementation using server postback.

How I tested?
~~~~~~~~~~~~~
1. Build the solution from Visual Studio
	This downloads the required Nuget packages ad builds the solution.
	ASP.NET creates database for user registration and login in local mdf file in App_Data folder.
	
2. Run the project "Folkefinans.StockProductivity"
	This should start the application in default browser (Google Chrome).
	Register a new user and login.
	Perform the "Enter Stock Details" and "View Calculated Result" workflows multiple times.
	Everything should work as expected (as mentioned in "programming_test.pdf")
	
3. Run the unit tests from Visual Studio or MSTest command line.
	This should run test cases for the StockDetailsController. All tests should pass.
	PS: Coverage was not measured.