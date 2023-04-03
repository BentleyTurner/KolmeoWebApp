# :wrench: Kolmeo Product API :hammer:
Hello and welcome to my coding challenge submission! I have had a lot of fun with this and hope you enjoy my work!

## The Challenge
Product Api
Create a simple service that can be used to add and retrieve products via a public endpoint.

Use this as an opportunity to flex your engineering and create a small production ready api.
Product Model {
 Id
 Name
 Description
 Price
}

### Stack                               
 - ASP.NET Core
 - Entity Framework Core  

### Not required:
 - Authentication
 - Physical Persistence (in memory will do)

## How to run
How to run the main project
```bash
cd KolmeoWebApp
dotnet run
```
How to run the test project (says cd .. but thats assuming you are still in the KolmeoWebApp directory from previous command)
```bash
cd ..
dotnet test
```
## My Thoughts
### What does production ready mean?
In order for me to consider the API 'production ready' there are a few things I'd need to include:
1. Clear folder structure that closely matches the standard practices of .NET Web projects (or as close as I can get from my own research)
2. Easy to run code that utilises appropriate libraries and packages
3. Readability needs to be at a level that someone else could take the application to the next level
4. Sucessfully runs in local stack and all functionality delivered
5. Unit tests are written and can be run easily
6. Unit tests cover the core logic and use cases of the API 
7. README explains what has been done and whats next

## My Implementation 
### Folder Structure
The basic folder structure is as follows:

<img width="350" alt="image" src="https://user-images.githubusercontent.com/20896353/229490028-996ceda9-8595-4bd5-b059-31fafad2275f.png">

### Notable Mentions
I included a DTO so that the API doesnt interact with the Product object directly for security reasons and as a general good practise. The Product class has a secret field that the DTO does not (To represent whatever we dont want to show to end users)

<img width="750" alt="image" src="https://user-images.githubusercontent.com/20896353/229491114-e6204866-0a84-42fe-a107-31a7cc4b839c.png">

Here are the CRUD methods in the controller:

<img width="750" alt="image" src="https://user-images.githubusercontent.com/20896353/229491730-14c377d2-cb60-4f1a-bae1-57a665262d08.png">



### Tests
The tests I included are captured below:

<img width="350" alt="image" src="https://user-images.githubusercontent.com/20896353/229489854-cff0e13b-024f-4357-a12a-885ac486bbd9.png">


