using System;
using System.IO;
using System.Reflection;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\Images\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Get the EXIF data container
                JpegExifData jpegExif = image.ExifData as JpegExifData;
                if (jpegExif == null)
                {
                    Console.WriteLine("No EXIF data found in the image.");
                    return;
                }

                // Prepare table header
                const int tagWidth = 40;
                const int valueWidth = 60;
                Console.WriteLine($"{ "Tag".PadRight(tagWidth) } | { "Value".PadRight(valueWidth) }");
                Console.WriteLine(new string('-', tagWidth + valueWidth + 3));

                // Use reflection to enumerate all public instance properties of JpegExifData
                PropertyInfo[] properties = typeof(JpegExifData).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in properties)
                {
                    // Skip indexer properties
                    if (prop.GetIndexParameters().Length > 0) continue;

                    object val = prop.GetValue(jpegExif);
                    string displayValue;

                    if (val == null)
                    {
                        displayValue = "(null)";
                    }
                    else if (val is Array arr && !(val is byte[]))
                    {
                        // For array types (except byte[]), join elements
                        displayValue = string.Join(", ", arr);
                    }
                    else
                    {
                        displayValue = val.ToString();
                    }

                    Console.WriteLine($"{ prop.Name.PadRight(tagWidth) } | { displayValue.PadRight(valueWidth) }");
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
 * 1. When a developer needs to audit or debug metadata of JPEG photos uploaded to a web service, they can use this code to read and display all EXIF tags in a console table.
 * 2. When building a migration tool that moves images between storage systems and must verify that orientation, GPS, and camera settings are preserved, this snippet extracts the full EXIF set for comparison.
 * 3. When creating a command‑line utility for photographers to quickly inspect camera make, model, exposure, and other EXIF information without opening an image editor, the code provides a formatted view of every tag.
 * 4. When implementing a compliance check that ensures images contain required legal metadata such as copyright or author fields before publishing, the program lists all EXIF entries for easy validation.
 * 5. When developing a batch‑processing pipeline that logs image metadata for analytics or indexing, this example shows how to enumerate JpegExifData properties in C# and output them in a readable table.
 */