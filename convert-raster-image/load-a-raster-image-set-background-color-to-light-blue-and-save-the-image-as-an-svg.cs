using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for SVG output
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Set the background color to light blue
                    BackgroundColor = Aspose.Imaging.Color.LightBlue,
                    // Use the original image size as the page size
                    PageSize = image.Size
                };

                // Create SVG save options and attach the rasterization options
                var saveOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as SVG
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}