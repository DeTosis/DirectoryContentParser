public static class DirectoryContentParser {
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

    public static bool GetDirectoryContents(string path, out string[]? directoryContents) {
        if (!GetDirectories(path, out var directories) || !GetDirectoryFiles(path, out var files)) {
            directoryContents = null;
            return false;
        }

        directoryContents = directories.Concat(files).ToArray();
        return true;
    }

    public static bool GetDirectoryContents(string path, FileAttributes[] excludeAttributes, out string[]? directoryContents) {
        if (!GetDirectories(path, out var directories) || !GetDirectoryFiles(path, out var files)) {
            directoryContents = null;
            return false;
        }

        directoryContents = directories.Concat(files).ToArray()
            .Where(item => excludeAttributes.All(flag => !File.GetAttributes(item).HasFlag(flag))).ToArray();

        return true;
    }

    public static bool ExtractContentLastName(string fullName, out string viewName, out string[]? splitParts) {
        if (!File.Exists(fullName) && !Directory.Exists(fullName)) {
            viewName = String.Empty;
            splitParts = null;
            return false;
        }

        splitParts = fullName.Split("\\");
        viewName = splitParts.Last();
        return true;
    }
}
