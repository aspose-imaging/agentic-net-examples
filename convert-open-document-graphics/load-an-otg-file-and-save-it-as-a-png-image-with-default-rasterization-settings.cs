using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output\sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with default OTG rasterization settings
                PngOptions pngOptions = new PngOptions();

                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Use the source image size as the page size
                    PageSize = image.Size
                };

                // Assign rasterization options to the PNG options
                pngOptions.VectorRasterizationOptions = otgRasterizationOptions;

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
 * 1. When a developer needs to convert a vector OTG drawing into a raster PNG for web preview using Aspose.Imaging in C#.
 * 2. When a developer wants to generate a PNG thumbnail from an OTG file to display in a file‑manager UI.
 * 3. When a developer must export an OTG diagram as a PNG image to embed in PDF or Word reports.
 * 4. When a developer automates batch conversion of multiple OTG assets to PNG files for use in a mobile application.
 * 5. When a developer saves an OTG map overlay as a PNG to integrate with GIS or mapping software.
 */