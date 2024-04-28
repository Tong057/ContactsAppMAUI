# ContactsAppMAUI

Welcome to the ContactsAppMAUI repository! This project is a contact management application developed with .NET Multi-platform App UI (MAUI), offering a cross-platform solution for managing contacts across mobile and desktop devices.

## Features

- **Cross-Platform Compatibility**: The application is designed to run on iOS, Android, Windows, and MacOS, providing a consistent experience across different platforms.
- **Contact Management**: Users can create, edit, and view contacts. The app allows for easy organization and offers an intuitive interface for managing contacts.
- **Search Functionality**: A built-in search feature lets users quickly find contacts by name, phone number, or other attributes.
- **Swipe and Context Menu Actions**: On mobile platforms, users can use swipe gestures to perform actions like deleting contacts. On desktop platforms, additional context menu options are available.
- **Bottom Sheet Tools**: The app includes a bottom sheet containing various tools for filtering, segregating, and testing contacts. This provides advanced functionality for organizing and managing contacts in a more detailed manner.

## Technologies and Frameworks

- **EntityFramework Core**: The project uses EntityFramework Core for data storage and retrieval, supporting various databases and providing flexibility in data management.
- **Dependency Injection**: Dependency injection is utilized to manage dependencies, allowing for easier testing and a more maintainable codebase.
- **MVVM Toolkit**: The application follows the Model-View-ViewModel (MVVM) pattern, with the MVVM Toolkit providing helpers for creating view models and managing bindings.
- **Data Binding and Commands**: The MVVM architecture allows for efficient data binding between the UI and the view models, facilitating a clean separation of concerns. Commands are used to handle user interactions.

## Architecture

- **Model-View-ViewModel (MVVM)**: The application is structured using the MVVM pattern. Models represent the data structure, views represent the user interface, and view models act as the intermediary, handling the logic and data bindings.
- **Dependency Injection**: Services and other dependencies are injected into view models and other components, promoting a modular and testable codebase.
- **EntityFramework Integration**: EntityFramework is used to interact with the data layer, enabling robust data management with support for migrations and complex queries.

## How to Build and Run

To build and run the ContactsAppMAUI application, ensure you have .NET MAUI set up on your development environment. Clone the repository, open it in Visual Studio, and select the target platform to build and run the application.

![contactsapp-readme](https://github.com/Tong057/ContactsAppMAUI/assets/130866438/b504c50c-5c54-48fc-ab4c-2175368e69cd)
