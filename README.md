# Contents
* [The Project](#the-project)
  * [Structure](#structure)
  * [Documentation](#docs)
  * [Tests](#tests)

# The Project
Thiss C# library encapsulates the CRUD operations atop of Entity Framework in a comprehensive an very easy to use MVC like structure (without views, of course).

## Structure

As said before, we follow MVC pattern. So, the classes and interfaces come in the following structure:

* **Generic_Entity_CRUD**  
    * **Model**
        * **IEntity**  
        Generic interface for any entity in the models
        * **IIdentified**  
        Interface for entites with integer primary key
        * **IKeyed**  
        Interface for entites with string primary key
        * **IDated**  
        Interface for entites with creation and update date
    * **Controller**
        * **ICrudController**  
        Generic interface that defines the avaliable CRUD method and their signatures
        * **CrudController**  
        Abstract Controller class that implements the CRUD functionality and exposes it to descendants 

## Documentation

All files are very documented with C#'s XML comments,  there's no hidden functionality or obscure undocumented function in this project.

## Tests

We're implementing some tools to test the library and it's releases, but the project is in it's very begining yet - the crative phase, we can say.