using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.jpg";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Retrieve EXIF data container
                JpegExifData exifData = image.ExifData as JpegExifData;

                if (exifData == null)
                {
                    Console.WriteLine("No EXIF data found in the image.");
                    return;
                }

                // All EXIF tags (common, EXIF, GPS) are available via the Properties collection
                var allTags = exifData.Properties;

                // Table header
                Console.WriteLine("{0,-10} | {1,-30} | {2}", "Tag ID", "Tag Name", "Value");
                Console.WriteLine(new string('-', 70));

                // Iterate and display each tag
                foreach (var tag in allTags)
                {
                    // TagId is a ushort, TagName is a string, Value is an object
                    // Use reflection to get the tag name if available; otherwise fallback to tag.ToString()
                    string tagName = tag.GetType().GetProperty("TagName")?.GetValue(tag) as string ?? tag.ToString();
                    string value = tag.GetType().GetProperty("Value")?.GetValue(tag)?.ToString() ?? "null";

                    Console.WriteLine("{0,-10} | {1,-30} | {2}", tag.GetType().GetProperty("TagId")?.GetValue(tag) ?? "N/A", tagName, value);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to audit or log JPEG metadata in a digital asset management system, this code extracts and prints every EXIF tag in a readable console table.
 * 2. When building a photo‑organizing tool that groups images by camera settings, the code can display all EXIF properties to verify the data before applying filters.
 * 3. When troubleshooting image‑processing pipelines that rely on GPS coordinates, a developer can use this snippet to confirm that the required EXIF GPS tags are present and correctly formatted.
 * 4. When creating a compliance report for media files that must include copyright or author information, the code quickly lists the EXIF fields such as Artist, Copyright, and DateTime.
 * 5. When integrating Aspose.Imaging into a C# application that needs to validate incoming JPEG uploads, this example shows how to read every EXIF tag to detect missing or malformed metadata.
 */