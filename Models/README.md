# User Attributes

```json
User(
    userID:         int            # unique identifier for user
    displayName:    str            # name shown to other users
    graduationDate: DateTime       # expected graduation date of user
)
```

# Project Attributes

```json
Project(
    projectID:      int            # unique identifier for project
    name:           str            # name shown to users
    description:    str            # project purpose and requirements
    projectOwner:   int            # id of the user who owns the project
)
```