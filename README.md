# GraphQL
A playground for GraphQL in .net core

##
Run project and open a browser to this url https://localhost:44369/graphql


## Example requests

### Query
```
query {
  students {
    id
    firstName
    lastName  
    dateOfBirth
  }
}
```

```
query{
  student(id: 265){
    firstName
    dateOfBirth
  }
}
```

### Mutation
```
mutation	{
  createStudent(
    student: {
      firstName: "Harrie"
      lastName: "Nak"
      dateOfBirth:  "2000-08-27"
    }
  )
  {
    id
    firstName
    dateOfBirth
  }
}
```