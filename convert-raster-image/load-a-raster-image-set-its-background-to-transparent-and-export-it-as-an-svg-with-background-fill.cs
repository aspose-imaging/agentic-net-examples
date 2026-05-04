using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                SvgOptions saveOptions = new SvgOptions();

                // Configure rasterization options with transparent background
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Set background to transparent
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    // Use the original image size as page size
                    PageSize = image.Size
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}