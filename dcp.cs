public static class dcp {
    private static bool GetDirectories(string path, out string[]? directories) {
        if (Directory.Exists(path)) {
            directories = Directory.GetDirectories(path);
            return true;
        }
        directories = null;
        return false;
    }

    private static bool GetDirectoryFiles(string path, out string[]? files) {
        if (Directory.Exists(path)) {
            files = Directory.GetFiles(path);
            return true;
        }
        files = null;
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path">
    //      Directory path to the item 
    //  </param>
    /// <param name="directoryContents">
    //      Result of parsing directory for it's contents in array     
    // </param>
    /// <returns></returns>
    public static bool GetDirectoryContents(string path, out string[]? directoryContents) {
        if (!GetDirectories(path, out var directories) || !GetDirectoryFiles(path, out var files)) {
            directoryContents = null;
            return false;
        }
        directoryContents = null;
        directoryContents = directories.Concat(files).ToArray();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path">
    //      Directory path to the item 
    //  </param>
    /// <param name="excludeAttributes">
    //      Exclude items's from result by specifying a file attributes  
    //  </param>
    /// <param name="directoryContents">
    //      Result of parsing directory for it's contents     
    //  </param>
    /// <returns></returns>
    public static bool GetDirectoryContents(string path, FileAttributes[] excludeAttributes, out string[]? directoryContents) {
        if (!GetDirectories(path, out var directories) || !GetDirectoryFiles(path, out var files)) {
            directoryContents = null;
            return false;
        }

        directoryContents = null;
        directoryContents = directories.Concat(files).ToArray()
            .Where(item => excludeAttributes.All(flag => !File.GetAttributes(item).HasFlag(flag))).ToArray();

        return true;
    }

    /// <summary>
    ///     
    /// </summary>
    /// <param name="fullName">
    //      Directory path to the item 
    //  </param>
    /// <param name="viewName">
    //      Last sequens of characters in item's path
    //  </param>
    /// <param name="splitParts"> 
    //      Array with all parsts of a content item path separated by '/' 
    //  </param>
    /// <returns></returns>
    public static bool ExtractContentLastName(string fullName, out string viewName, out string[]? splitParts) {
        if (!File.Exists(fullName) && !Directory.Exists(fullName)) {
            viewName = String.Empty;
            splitParts = null;
            return false;
        }

        splitParts = null;
        viewName = null;
        splitParts = fullName.Split("\\");
        viewName = splitParts.Last();
        return true;
    }
}
