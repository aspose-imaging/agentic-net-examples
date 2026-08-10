// HOW-TO: Create a 1024x768 BMP Image and Save to File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\Temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                // Define where the image will be created
                Source = new FileCreateSource(outputPath, false),
                BitsPerPixel = 24,
                ResolutionSettings = new ResolutionSetting(96.0, 96.0)
            };

            // Create a blank 1024x768 BMP image and save it
            using (Image image = Image.Create(bmpOptions, 1024, 768))
            {
                image.Save(); // Saves to the path specified in bmpOptions.Source
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
 * 1. When you need to generate a blank 24‑bit BMP canvas for later drawing or watermarking in a C# application.
 * 2. When an automated report generator must create a fixed‑size bitmap thumbnail and store it directly on disk without intermediate streams.
 * 3. When a server‑side service prepares a background image of specific resolution (1024×768) for use in a legacy Windows application that only accepts BMP files.
 * 4. When a batch process has to ensure the output directory exists and then create a BMP file with 96 dpi resolution for printing or archival purposes.
 * 5. When you want to programmatically produce a BMP file with custom bits‑per‑pixel settings using Aspose.Imaging’s ImageOptions in .NET.
 */
