// HOW-TO: Convert OTG Vector Image To PNG With White Background In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Create rasterization options for OTG
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    // Set desired background color
                    BackgroundColor = Color.White,
                    // Preserve original page size
                    PageSize = image.Size
                };

                // Configure PNG save options and attach rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
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
 * 1. When you need to display an OTG vector diagram on a web page that only supports raster PNG files, you can rasterize it with a white background using Aspose.Imaging in C#.
 * 2. When generating printable assets from OTG drawings and the printer requires a PNG with a specific background color, this code converts and sets the background automatically.
 * 3. When automating a batch process that extracts OTG files from a repository and stores them as PNG thumbnails for a gallery, the rasterization options ensure the original page size is kept.
 * 4. When integrating OTG support into a C# desktop application that saves user‑edited vector graphics as PNG for sharing, you can use this snippet to preserve layout and apply a uniform background.
 * 5. When creating a migration tool that moves legacy OTG assets to a modern PNG format while maintaining visual fidelity, the code provides a reliable way to rasterize and save each image.
 */
