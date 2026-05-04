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
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Prepare SVG save options
                var saveOptions = new SvgOptions();

                // Configure rasterization options with background color
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    // Set background to light gray
                    BackgroundColor = Aspose.Imaging.Color.LightGray,
                    // Use the original image size as page size
                    PageSize = rasterImage.Size
                };

                saveOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save as SVG with background
                rasterImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}