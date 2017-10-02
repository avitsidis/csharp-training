#Csharp Training
##Exercice 1 : Linq - Where clause
###1.1 Search consultant
Users want to filter consultant base on their name and firstname(partial). Your colleague tried to implement it but it seems that the code always returns all record... 
You have to fix his code in order to make it work

###1.2 Search consultant by team name
Users wants to search consultant based on their team name(exact name). You have to add the functionnality in the search action.

##Exercice 2 : Linq - Aggregations
Management would like a dashboard with real time company information such as:
* number of consultant without a mission
* Number of hired employee each years
* Top 5 clients
* 3 Newest missions

As the dashboard will be available in a web application you have to implement a Dashboard rest service.

###2.2: number of consultant without a mission
You must provide the number of consultants that do not have an active mission at the moment.

###2.2: Number of hired employee each years
You must provide a map where key is year and value is the number of employee hired that year
optionnal: If there is no employee we want an item in the map with value 0

###2.2: Top 5 clients
Provide biggest clients in terms of current mission number.

###2.2: 3 Newest missions
Provide the 3 latest missions. You must provide:
Consultant FullName, Customer Name, Customer country, Mission Start Date

result must be ordered by mission Start date