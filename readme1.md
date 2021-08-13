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
		- They are the Render Fragments used to simplify the complex component rendering
		- USed in case when the reusable component is complex and consit of multiple HTML Tags
		- USe RenderFragment and RenderFragment<T> types for defining Templates
			- T is the typeparameter taht is used to accept input data to generate HTML
		- POint of Cautions
			- Plan a UI with Raw design
				- Data Requirements
				- Behavioral Requirements aka Events
				- Logic
			- Plan for input data that is accepted by the UI
			- Plan what data will be emitted from the UI
		-  While Generating a Template, we need to use RenderTemplate<T>, the T will bge the data accepted by the templates using @typeparam, this data will be used to generate the UI rendering using RenderFragment
		- The Template also contains the '@context' property
			- THis property provides the Reflection PropertyInfo to read each public instance property from the typeparam passed to the Template
		- USe the Template with RenderFragment if, the component has frequent StateChanges and this may be a Rendering Overhead on UI thread on the browser because of the component  lifecycle
			- The Template or portion (fragment) of the Templae will be replaced with only the updated value 
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

4. Test for the Blazor
	- Use Case or User Stories
	- Test Data
	- Test Case
	- Tests for Interactive Apps
		- Test for Events
		- Test for UI Updates
	- Testing Framework suitbale for Blazor
		- Microsoft.Net.Test.Sdk	
			- The Test Object Model for Loading and Running the Test
			- This is integrated with VIsual Studio
		- MSTest.TestFramework
			- Microsoft Unit Test FRwk
			- BAsed on xUnit
		- MSTest.TestAdapter
			- The Test UI to show Statastics of Test Execution
			- UI Panel Integrated with VIsual Studio
			- Acts as aBridge between NUnit and Visual Studio with Projects those are using NUnit
		- Install bunit.web  for Unit Testing for Blazor
		- Install Moq for Mocking testing for all code that has external Depedencies
			- e.g. Http Calls, other exterrnal object used in COmponents using Dependencies
	- Unit Test Standard Implementation
		- Arrange
			- Get All Dependencies COnfigured for the Test
		- Act
			- Use the Dependencies for Test Execution
			- Call method to execute the Test
		- Assert
			- Run the Assertion to Verify the Success of the Test

5. Application MIgration from .NET Core 3.1 to .NET
- Monitor the .csproj file
	- Used by MSBuild to Generate a Dependency MAp for the Application
	- Decide/Set the Runtime requirements for the Application
	- Modify the CsProj file by Updating the Target Framework
		-  <TargetFramework>net5.0</TargetFramework>
	- Delete bin and obj folder
		- Its is recommended to clear the nuget cache on local server to clear older version NUget PAckages to the New one [Step to be FOllowed on Production Server]
			- dotnet nuget loccal --clear all
6. Deployment of .NET 5 Apps
	- On-Premises Deployment
		- On WIndows MAchine (Windows 10 / Windows Server 2016+)
			- Install IIS
				- Create App Pool as No Managed Code
				- Set AppPoolIdentity of the AppPool as LocalSystem
				- In Database Server add a User as IIS APPPOOL\[AppPoolName]
				- Create a Web Site for The AppPool
				- Under Web Site Craete an Application
				- Publish the App
			- Install .NET 5 SDK with ASP.NET Core 5 Module v2 ASPNETCoreModuleV2
		- On Linux Machine / Mac OSX
			- Install .NET SDK for Linux or Mac OSX
			- Create a Build and Copy it on these OS in Publish Folder
			- Navigate to Publish Folder and run 'dotnet run' Command
		- On Docker
			- Create a Docker Image for the Project and Copy it on 
				- Windows / Linux Machine
				- Docker run Command
	- On-Cloud {Lift and Shift} {On Azure}
		- Migrate the Database on Cloud
		- Update the Connection String of Database in appsettings.json
		- Publish the Application using Pubish Feature of Visual Studio, on Cloud as API App 
	- On-Cloud using Docker Image (Generally in case of Microservices)
		- Build the Docker Image Locally
			- docker build .
		- Push Docker Image to Azure Container Registry (ACR)
		- From the Dev. Maching Login on on ACR
		- Tag the Image to ACR Name
		- Push The Image to ACR from Dev. MAchine
		- Deply the Image as API App on Cloud



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
Date : 09-08-2021
1. Create a Template for Generating List of RedioButtons.
	The RenderFragment will define the data-value for each RedioButton in the list
2. Create a re-usable component that will render a CheckBoxList (Optional)
	- THis component will accept following 3 Parameters
		 - DataSource of the type IEnumerable<T>
		 - DataValueField, this will be the value returned by CheckBox when it is selected
		 - DataTextField, this will be the Lable/Caption for each CheckBox
3. MOdify the Core-API to Provide the FIle Download using Http Reqest made by the BLaozr Web Assembly client Project. 
	- MOdify the API for FOllowing FIle Checks
		- The Upload/Download must takes place for .jpg/.bmp/.png files
		- The Blazor WebAssembly Project should show the Uploaded Files in the HTMl TAble as Preview
		- The MAz Size Allowed for Upload OPeration is 15 MB
			- The Server Must respond the error if the file size is more than 15 mb
Date: 12-08-2021
1. Write a Test for a Blazor Component, that when the Department is added by click on Save Button, the Table SHowing list of Department is added with a <tr><td> with Department Values
	- Read the Sabe Button
	- Call the Save() method
	- Read the <table> with new <tr> with <td>s added in it

