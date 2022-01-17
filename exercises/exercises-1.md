# Exercise 1

## Requirements

**Requirement 1.** Create a new Razor Component in the `Pages` folder named "CarTool".

**Requirement 2.** Add a menu item for the new page. Give the menu item a name of "CarTool".

**Requirement 3.** Display the following header on Car Tool page. Be sure to define the page attribute to configure the routing.

```html
<header>
    <h1>Car Tool</h1>
</header>
```

**Requirement 4.** Create a new component named Car Table in the `Components` project. Please setup the appropriate folder structure (add a namespace for `CarTool` to the components project). Call the Car Table component from Car Tool.

**Requirement 5.** In the Car Table component display a table of cars with the following columns:

Columns:
- Id
- Make
- Model
- Year
- Color
- Price

Please use the HTML `<table>` element and related elements for the table.

**Requirement 6.** Define a Car Model in the `ToolsApp.Models` project.

Properties
- Id (long)
- Make (string)
- Model (string)
- Year (int)
- Color (string)
- Price (decimal)

**Requirement 7.** Create a list of two Car record objects. The list of cars should continue to be managed within the Car Tool component.

**Requirement 8.** Populate the Car Table dynamically with the list of cars.

Ensure it works!