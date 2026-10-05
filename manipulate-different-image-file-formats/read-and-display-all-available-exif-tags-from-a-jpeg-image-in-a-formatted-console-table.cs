// HOW-TO: Read All EXIF Tags From JPEG And Display In Console Table C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                dynamic exifData = image.ExifData;
                if (exifData == null)
                {
                    Console.WriteLine("No EXIF data found.");
                    return;
                }

                Console.WriteLine("{0,-10} {1,-30} {2}", "Tag ID", "Tag Name", "Value");
                Console.WriteLine(new string('-', 70));

                foreach (var tag in exifData.Tags)
                {
                    string tagId = $"0x{tag.TagId:X4}";
                    string tagName = tag.TagName;
                    string value = tag.Value != null ? tag.Value.ToString() : "null";

                    Console.WriteLine("{0,-10} {1,-30} {2}", tagId, tagName, value);
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
 * 1. When you need to inspect camera metadata such as shutter speed, ISO, or GPS coordinates stored in a JPEG file during a photo‑management workflow.
 * 2. When building a diagnostic tool that verifies whether uploaded images contain required EXIF information before processing them further.
 * 3. When creating a batch script that logs all available EXIF fields of images to help auditors compare metadata across a collection.
 * 4. When developing a desktop utility that shows end‑users the complete set of EXIF tags so they can decide which images meet publishing standards.
 * 5. When troubleshooting image‑processing pipelines by printing EXIF data to the console to confirm that tags are being read correctly.
 */
