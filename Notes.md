## Foundational Principles
### Dependency Inversion
- Decoupling modules
- Dependencies should be pointing to abstractions
    - Typically  top to bottom
- Helps with building more loosely-coupled applications
### Separation of Concerns
- Split into blocks of functionality
    - Each covering a concern
- More modular code
    - Encapsulation within a module
- Typical layered application
- Easier to maintain
### Single Responsibility
- Each block should just have one single responsibility which it encapsulates
- More, new classes are created
### DRY
- aka Don't Repeat Yourself
- Less code repetition
- Easier to make changes
### Persistence Ignorance
- POCO
- Domain classes shouldn't be impacted by how they are persisted
- Typically required base class or attributes

## Different Application Architectures
### All-in-one Architecture
- "Layers" are folders
- Can be difficult to maintain
- Contained typically in one (large) Visual Studio project
### Layered Architecture
- Split according to concern
    - Different projects in a visual studio solution
    - Pushes Separation of Concerns
    - Dry Principle
- Promote reuse
    - If we need to change something that is used in multiple places, we only need to do so in one place
- Easier to maintain
    - Results in less errors, hopefully
    - Easier to find something
    - Component focused on one task means changing won't affect other code
- Presentation layer, Business logic layer, Data access layer
- Disadvantages
    - Business logic layer will have dependency on Data access layer
    - Coupled layers
    - Still behaves as single application
### Clean Architecture
- Based on design principles
- Separate concerns
- Create maintainable and testable application code
- Variation on hexagonal and onion architecture
    - Introduced in 2012
- Separation of concerns
- Loose coupling
- Indpendent of "external" influences
    - UI
    - Database
- Circular Design
    - Different circles for different "layers"
    - Application Core
        - Abstractions (high-level)
        - Interfaces and entities
        - Business logic at the centre of the application (use-cases)
        - Agnostic to outer circles
        - has no dependencies on external influences
    - Outer circles are infrastructure (mechanisms)
        - Depends on Core
        - Implements interfaces from Core
    - Dependencies are inverted
        - Pointing inwards
    - UI
        - Depends on Core
- Business logic and Application logic are considered part of the Core
- Application Core knows nothing about the implimentation details
    - No references to packages that have anything to do with things like data persitence and logging
    - These types of things belong in the Infrastructure layer
- Infrastructure layer contains the mechanisms and implementations for the abstractions defined in the Core
- UI depends on the Core
#### Two Important Principles
- Dependency Inversion
    - At runtime, Dependencies defined in the Core will be plugged in from other layers
    - When testing we can plug in a different "test" implementation
- Mediator Pattern
    - Enables messaging between loosely coupled objects
### Clean Architecture Benefits
- Independant of UI of used frameworks
- No knowledge of used database
- Testable and maintainable
## Requirements for Ticket Management
- Manage Events
- Overview of events in their categories
- Orders for the different events
### Key Entities
- Events
- Categories
- Orders
### 
- Menu down left side
- Events should show a list of events with details
- Can add new event or edit existing event
- When Editing, the delete option is shown
- Events require a name, a price, and a date
- Events belong to a category
- Categories will show a list of categories with their events
- Can add a category
- Categories require a name that is no longer than 50 characters
- Sales shows sales for a given month