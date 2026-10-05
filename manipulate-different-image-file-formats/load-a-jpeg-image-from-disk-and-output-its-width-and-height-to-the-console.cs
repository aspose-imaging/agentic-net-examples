// HOW-TO: Read JPEG Dimensions (Width and Height) In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                Console.WriteLine($"Width: {image.Width}");
                Console.WriteLine($"Height: {image.Height}");
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
 * 1. When a developer needs to display the pixel width and height of a JPEG image in a UI or log file.
 * 2. When validating that uploaded JPEG files meet minimum dimension requirements before further processing.
 * 3. When calculating scaling factors for thumbnail generation or image resizing based on the original JPEG size.
 * 4. When creating a batch script to report the dimensions of multiple JPEG photos for inventory or cataloging purposes.
 * 5. When troubleshooting image rendering problems by confirming the actual width and height of a JPEG file.
 */
