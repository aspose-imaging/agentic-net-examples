// HOW-TO: Convert CMX Image To JPEG With Quality 90 In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\sample.cmx";
            string outputPath = @"C:\temp\sample.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with the required quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save the image as JPEG using the configured options
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime error without crashing the application
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a CorelDRAW CMX drawing on a web page that only supports JPEG images.
 * 2. When you are generating thumbnails for CMX files to store in a database with a specific compression level.
 * 3. When you are migrating legacy CMX assets to a modern image workflow that requires JPEG with controlled quality.
 * 4. When you need to batch‑convert CMX files to JPEG for printing services that accept only JPEG at 90 % quality.
 * 5. When you want to programmatically compress CMX artwork for email attachments while preserving visual fidelity.
 */
