
# Directory Content Parser
A small c# script to get directories and files via path



# Usage

### Function to get all folders and files from a given path
```c#
bool GetDirectoryContents(
    string path, 
    out string[]? directoryContents
);
```
This function can also be overloaded with a file attributes to exclude from result
```c#
bool GetDirectoryContents(
    string path, 
    FileAttributes[] excludeAttributes,
    out string[]? directoryContents
);
```

### Function for getting a name from path to a file, if needed also can return all parts of a given path
```c#
bool ExtractContentLastName(
    string fullName, 
    out string viewName, 
    out string[]? splitParts
);
```
