// HOW-TO: Read JPEG Dimensions From File And Print Width Height In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.jpg";
            string outputPath = @"C:\temp\output.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (required by the safety rules)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image and output its dimensions
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                Console.WriteLine($"Width: {jpegImage.Width}");
                Console.WriteLine($"Height: {jpegImage.Height}");
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
 * 1. When you need to verify the size of uploaded JPEG photos before storing them in a database.
 * 2. When generating a report that lists image dimensions for a batch of product photos in an e‑commerce application.
 * 3. When creating a validation step in a C# console tool that ensures images meet minimum width and height requirements for printing.
 * 4. When debugging an image processing pipeline and you want to quickly log the resolution of a JPEG file to the console.
 * 5. When building a simple utility that extracts metadata such as width and height from JPEG files for use in a content management system.
 */
