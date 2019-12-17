# User Attributes

```json
User(
    id:             str             # unique identifier for user
    displayName:    str             # name shown to other users
    graduationDate: DateTime        # expected graduation date of user
    permissions:    UserPermissions # permissions that a user has
)
```

# Project Attributes

```json
Project(
    id:                     str            # unique identifier for project
    name:                   str            # name shown to users
    description:            str            # project purpose and requirements
    extendedDescription:    str            # extended project purpose and requirements
    imageSource             str            # location of media
    isNewProject            bool           # whether or not it is a new project for the semester
    projectOwner:           int            # id of the user who owns the project
)
```

# Event Attributes

```json
Event(
    id:             str            # unique identifier for event89       
    name:           str            # name shown to users
    startDate:      DateTime       # date event starts
    endDate:        int            # date event ends
)
```