
## Module 6: User Interface elements & navigation

### User Interface native elements
Because a mobile application can have so many features and actions taken care of, it is important to be able to add special designed elements for each action to improve user experience: for instance, to navigate to the previous page the user would expect a button on the left side of the application because this is consistent with turning left to go back to one previous place - therefore, it is expected. No user would think a toggle would take him or her back to the previous page, just like no one will think an image will expect an input.

### Buttons
_What does this button do?_
<p align="left"><img alt="But-buttons" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/buttons.png?raw=true" margin=auto></p>

[Image source](https://codepen.io/g13nn/pen/yqiDG/image/large.png)

Ever since Dexter's sister Dee Dee started pushing buttons in her brother's laboratory, people started to _experience_ pushing buttons, having already in their subconscious that something would (or at least should) happen.

In terms of mobile applications, buttons are used generally to submit or enter data - any user would first complete some text entries and push a button after, expecting for that data to be added.

In the shopping list application, it was previously mentioned that the MainPage consist of two parts, the content and the action part. In the action part, a button is added to allow the user to add a new element to the list - add a suggestive icon to that button and you create a good user experience.

A button has three main properties that need to be set in order to implement a functionality:
- an ID (using the Name property), just like all other elements;
- either a name or an icon, so the user understands what the button does;
- a [clicked event handler](https://developer.xamarin.com/api/type/Xamarin.Forms.Button/) which is a method implemented in the back-end which will be discussed in the Back-end part of this course.

```cs
<Button 
   x:Name="addNewItem_button"
   HorizontalOptions="Center" 
   VerticalOptions="CenterAndExpand" 
   Margin="0,0,0,10"
   WidthRequest="48"
   HeightRequest="48"
   BackgroundColor="Transparent"
   Image="Assets\ic_add_box_black_24dp.png" 
   Clicked="addNewItem_button_Clicked"/>
```

We will now run the *UWP* project and see that the button is displayed but no image is displayed. This happens because we need to copy the actual image to the `Assets` folder.

### Icons
Though are not a specific element used in Xamarin Forms mobile development, icons are used (and have been in this course, too) used to give an image to buttons or ListViews and therefore need a mention.
When using Visual Studio, all the elements need to be added in the project - images, too - and as all used icons are present as images those were added on all the draw-able dimensions.
The Resource drawable folders are named this way because a version of the icon is needed for all sizes of the mobile devices, there fore the specific icon needs to be included in the project files on all mobile platforms, just like below:
<p align="center"><img height="350" alt="Icons" src="https://github.com/microsoft-dx/xamarin-fundamentals-ui/blob/master/Images/android-icons.PNG?raw=true" margin=auto></p>

A great icons website is [material.io](https://material.io/icons/) which also provides icons on various dimensions and file formats. The images we will be using are [this one](https://github.com/microsoft-dx/xamarin-fundamentals/blob/master/Images/ic_add_box_black_48dp.png) and [this one](https://github.com/microsoft-dx/xamarin-fundamentals/blob/master/Images/ic_add_box_black_24dp.png) from [material.io](https://material.io/icons/) which we will copy in the `Assets` folder and run the UWP project. Try now to run the Android project, does it work? It doesn't because the image assets are copied to a whole other folder in the Android project (the same applies for iOS).

### Device.RuntimePlatform
As you know there are 3 main platforms:

 - Android
 - iOS
 - UWP

Depending on which one you the application is currently running the resources or behavior might differ. Those being said, for a resource we might want to check the platform.

For example:

     // The source depends on the Platforms
            string imageSource = 
	            Device.RuntimePlatform == Device.UWP ? 
	            "Assets\\glossy-black-circle-button-md.png" : 
	            "glossy-black-circle-button-md.png";

            MainStack.Children.Add(new Image { Source = imageSource });

### Events and delegates

#### What are delegates?

> A delegate is a type that represents references to methods with a particular parameter list and return type. Delegates are used to pass methods as arguments to other methods. You create a custom method, and a class such as a windows control can call your method when a certain event occurs.
    
[More on the official MSDN documentation](https://msdn.microsoft.com/en-us/library/ms173171.aspx)

#### What are events?

> Events enable a class or object to notify other classes or objects when something of interest occurs. The class that sends (or raises) the event is called the publisher and the classes that receive (or handle) the event are called subscribers.

[More on the official MSDN documentation](https://msdn.microsoft.com/en-us/library/awbftdfh.aspx)

### Enable navigation with ContentPage
All we have to do to enable navigation, is to instantiate the `MainPage` into a navigation context. To do that, we will pass the `MainPage` instance to a `NavigationPage` instance, in the `App.xaml.cs` file like this:

```cs
MainPage = new NavigationPage(new MobileDemo.MainPage());
```

by doing this, we will have access to the `NavigationStack` in Xamarin.Forms into which we will push or pop instance of new pages that we want to visit. On the Click event, we will push a new instance of the `NewItem` page that we created in the previous modules in order to insert data into the shopping list using the following line of code:

```cs
Navigation.PushAsync(new NewItem());
```

We will now run and test and as we can see, the NewItem page is navigated to when we click the button, but how do we get back? In UWP and Android there is the endless `back to button` implemented in the operating system, but on iOS there is no such thing. So in order to go back to the previous page, the one we came from, on the button that will execute the insertion to the database, we will call:

```cs
Navigation.PopAsync();
```

### Other native elements
Of course, there are more native elements provided by Xamarin Forms but they weren't presented in this course as only the elements that were used were detailed. If you want more information about other elements, visit Xamarin Forms' [official page](https://developer.xamarin.com/guides/xamarin-forms/user-interface/controls/).
