// HOW-TO: Convert OTG Vector Image to PNG with Proper Resource Disposal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image and ensure proper disposal
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options to match the source size
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up PNG save options with the vector rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a PNG preview of an OTG vector diagram in a C# desktop application while ensuring memory is released promptly.
 * 2. When a server‑side service must batch‑convert uploaded OTG files to PNG for web display without leaking file handles.
 * 3. When integrating Aspose.Imaging into an automated build pipeline that transforms OTG assets into PNG thumbnails and requires deterministic disposal of the Image object.
 * 4. When creating a Windows service that monitors a folder for new OTG files and saves them as PNG, using a using block to avoid resource exhaustion.
 * 5. When developing a C# utility that validates the existence of OTG files, creates the output directory, and safely converts them to PNG with vector rasterization options.
 */
