using System;
using System.Web;
using System.Text.RegularExpressions;

class SharePointLinkDecoder
{
    static void Main()
    {
        Console.WriteLine("SharePoint Shared Links Decoder by Andrei-Emilian Rachita");
        Console.WriteLine("==========================================================");
        Console.WriteLine(" ");
        Console.WriteLine("Enter SharePoint/OneDrive shared link URL:");
        string url = Console.ReadLine();

        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
        {
            Console.WriteLine("Invalid URL.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        DecodePath(uri.AbsolutePath);
        DecodeQuery(uri.Query);

        Console.WriteLine("\nDecoded successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    // Rest of the code remains unchanged...
    static void DecodePath(string path)
    {
        Console.WriteLine("\nDecoded Path Info:");

        var match = Regex.Match(path, @"/:(\w):/(\w)/([^/]+)/([^/?]+)");
        if (match.Success)
        {
            string fileTypeCode = match.Groups[1].Value;
            string permissionCode = match.Groups[2].Value;
            string siteName = match.Groups[3].Value;
            string fileRefOrId = match.Groups[4].Value;

            Console.WriteLine($"File Type: {DecodeFileType(fileTypeCode)}");
            Console.WriteLine($"Permissions: {DecodePermission(permissionCode)}");
            Console.WriteLine($"Site Name: {siteName}");
            Console.WriteLine($"File Reference/ID: {fileRefOrId}");
        }
        else
        {
            Console.WriteLine("No recognizable structure found in path.");
        }

        Console.WriteLine($"Full Path: {path}");
    }

    static void DecodeQuery(string query)
    {
        var queryParams = HttpUtility.ParseQueryString(query);
        if (queryParams.Count > 0)
        {
            Console.WriteLine("\nQuery Parameters:");

            foreach (string key in queryParams)
            {
                string value = queryParams[key];
                switch (key)
                {
                    case "d":
                        Console.WriteLine($"d = {value} (Allows Office Online view for users with existing access)");
                        break;
                    case "e":
                        Console.WriteLine($"e = {value} (Unique file ID for link persistency)");
                        break;
                    case "email":
                        Console.WriteLine($"email = {value} (Email of the recipient if shared with one person)");
                        break;
                    case "csf":
                        Console.WriteLine($"csf = {value} (Indicates link for people with existing access)");
                        break;
                    case "web":
                        Console.WriteLine($"web = {value} (Forces open in browser view if set to 1)");
                        break;
                    default:
                        Console.WriteLine($"{key} = {value} (Unknown or custom parameter)");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("No query parameters found.");
        }
    }

    static string DecodeFileType(string code)
    {
        return code switch
        {
            "w" => "Word document",
            "x" => "Excel document",
            "p" => "PowerPoint document",
            "o" => "OneNote document",
            "b" => "PDF document",
            "t" => "Text document",
            "f" => "Folder",
            "i" => "Image",
            "v" => "Video",
            "u" => "Other (web page, audio, visio, zip, publisher, mail, etc.)",
            _ => "Unknown"
        };
    }

    static string DecodePermission(string code)
    {
        return code switch
        {
            "r" => "Restricted to people with existing access (read-only)",
            "s" => "Shared editable link (existing access respected)",
            "t" => "Specific people link",
            "u" => "Organization-wide link",
            "g" => "Anonymous guest link",
            _ => "Unknown or custom permission"
        };
    }
}
