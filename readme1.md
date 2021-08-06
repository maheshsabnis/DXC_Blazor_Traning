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


# Blazor Web Assembly App Development
1. Calls to API
2. Building Composit Application, i.e. Using Multiple Components at a time for Complex UI Apps
	- Communication Across Components
		- Components Knows Each other using Parent-Child Relationship
			- The 'EventCallback<T>' object is used to emit an event from Child Component to Parenty Component
				- T is Event Type Payload, the type of data to be emitted

		- Components are now knowing each other
	- Using Browser's State
		- LocalStorage and Sesion Storage
			- Use the same Origin Policy, they are instantiated for the DOmain from which the page is loaded in browser 
		- Balzored.LocalStorage
			- Maintain the  state of data even after the browser is closed 
			- This data will be available for next sesion for the same origin
		- Blazored.SesionStoreage
			- Volatile for a browser's instance. When the Browser is closed the LocalStorage will be cleaned
		- These packages must be registred at application level	
	- State Management across Components w/o using browser's resources
	- Templates for Components for reusability
	- Lazy Loading of Components
		- The Lazy Loading is an approach where the Blazor WAMS will mark the libraries as lazyloaded so that the browser knows when to provide process for execution for all components of them
			- Microsoft.AspNetCore.Components.WebAssembly.Services namespace which provides 
				the LazyAssemblyLoader class to manage elazy loading
					 - LoadAssembliesAsync() methis is used to load assermbly at run time in navigation context of the WASM application	   
		- Create a new Razor Class LIbrary Application
			- Add a Razor Component and write the required logic with HTML UI
			- Add the reference of the Project in Blazor WASM project
		- Modify the Project file of Blazor WASM to specify the RAzor Library will be loaded as lazy assembly
			- <ItemGroup>
		<BlazorWebAssemblyLazyLoad Include="Product_LazyLoad.dll"></BlazorWebAssemblyLazyLoad>
	</ItemGroup>	

3. Managing Application Security
	- UserName and Password
	- Using Azure AD





Hands-on-Tasks
Date: 02-08-2021 Create a component like Windows Calculator
Date: 03-08-2021 
	- Create a Search Component, that will show List of Employees based on Selected DeptName
	- Make sure that if the Department Does not have employees then the Empty Table should be generated showing mesage that nop recodrs found
	- The ListDepartment should generate table for Departments dynamically w/o hard-coding of Department properties
		- Use Reflection to read Properties from Department class
	- Modify the ListDepartment Component to Delete the Table Row to delete the Department. Make sure that, the Delete button is disabled if the department contains Employees
	- Show all Departments in sorted order of the DeptName
Date : 04-08-2021
	- Manage the Applicaiton State in Blazor WASM Standalone app to maintain the state for selected products from Category so that the enduser can select products to be purchased with Quantities. The Product Component should show list of Products for selected category with the Unit Price. The PurchaseComponent will allow enduser to select compoejnt from the ProductList and will allows user to enter quantity. This compoennt will calcluate total price. The TotalBillComponent will sholw list of all products purchased by enduser and will show the total bill by showing list of Products purchased.
	- CategoryComponent, ProductComponent, PurchaseComponent, TotalBillCOmponent
	- AppStateContainer
		- List<Purchase> is the State that will show List of all Products purchased
Date : 05-08-2021
1. Complete the Full-Stack Application using the ASP.NET COre 5 API and the Blazor WebAsembly Application with following Check Points
	- The CReate and Update COmponent for Department and Employee Must Validate the Inputs
		- Hint: Use <DataAnnotatiosValidator/> component and <ValidationSummary/> component in side EditForm
	- The Delete of Department must be Prohibited if there are Employees available for Deprtment. Show the Error Message for Delete Not Possible (Optional)
	- Modify the Department Table with the column as 'Capacity' as integer, while adding Employee in the department, if the capacity of Employees in the department is full, then generate erroir message from server and render it to client
Date :06-08-2021
1. From the WASM project, seperate the logic for Employee Operations by handling it in separate Razor library by creating New Employee component in it. Lazy Load this library in WAS Application