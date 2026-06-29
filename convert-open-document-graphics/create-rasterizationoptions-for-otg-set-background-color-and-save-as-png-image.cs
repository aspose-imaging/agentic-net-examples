using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output.png";

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
                // Prepare rasterization options for OTG
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions();
                otgRasterizationOptions.BackgroundColor = Aspose.Imaging.Color.White; // set background color
                otgRasterizationOptions.PageSize = image.Size; // preserve original size

                // Prepare PNG save options and assign rasterization options
                PngOptions pngOptions = new PngOptions();
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
 * 1. When a developer needs to convert an OpenDocument Graphic (OTG) file to a PNG thumbnail for a web gallery, preserving the original dimensions and applying a white background.
 * 2. When an application must generate PNG previews of vector‑based OTG diagrams for email attachments, ensuring the rasterized image matches the source size and has a consistent background color.
 * 3. When a reporting tool has to embed OTG charts into PDF reports by first rasterizing them to PNG with a solid background to avoid transparency issues.
 * 4. When a batch processing script processes a folder of OTG assets and saves them as PNG files for use in a mobile app that only supports raster images.
 * 5. When a developer integrates Aspose.Imaging into a C# service that receives OTG uploads and returns PNG images with a predefined background for downstream image analysis pipelines.
 */