Blazor Apps
The 'ComponentBase' is the base class for all components - This contains the Component Lifecycle methods The 'LayoutComponentBase' class will be used to define the rendering of Other components on Browser. This is derivedd from the COmponentBase - RenderFragment, the class that represents the Rendering Area for the component IMP Note: The name of the Component File will be the Component Name

#_framework/blazor.server.js

The JavaScript file used in ASP.NET Core Server Hosted Balozr application to make call to the server from browser using Socket to fetech the Pre-Rendered HTML of Component for loading in browser
 &ltcomponent type="typeof(App)" render-mode="ServerPrerendered" /&gt
The 'component' is TagHelper to redner HTML in Browser

The 'rendered-mode': ServerPrerendered means that the updated component's HTML will be serailized back to the browser over the socket

Blazor Decorator
Thesre are the objects used to define execution behavaior of the .NET 5 types when used in Blazor component

@page: the directive used to define the URL for accessing the Component
@using: used to refer and load namespace on component
@code: the logical section of component that is the C# code for the component. This contains parameters, properties, methoods, lifecyclem hooks, etc.
@inject: To inject depednency in component
Creating Component
Standard Components
InputText, InputNumber, InputCheck, InputRadio, InputTextArea, etc
Data Binding Attributes
@bind-value="[Property-OF-THE-COMPONENT]"
EditForm
The Blazor 'form' component. This will map itself with HTML form
Model property, used to load and bind the CLR object aka entity class on Form
The OnValidSubmit event to submit the form
DataAnnotationValidator
Component to validate the Form
All component must be added in Pages Folder
Right-Click-->Add-->Razor Component
Hands-on-Tasks
Date: 02-08-2021 Create a component like Windows Calculator
Date: 03-08-2021 
	- Create a Search Component, that will show List of Employees based on Selected DeptName
	- Make sure that if the Department Does not have employees then the Empty Table should be generated showing mesage that nop recodrs found
	- The ListDepartment should generate table for Departments dynamically w/o hard-coding of Department properties
		- Use Reflection to read Properties from Department class
	- Modify the ListDepartment Component to Delete the Table Row to delete the Department. Make sure that, the Delete button is disabled if the department contains Employees
	- Show all Departments in sorted order of the DeptName