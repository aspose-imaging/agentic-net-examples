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
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Compute new dimensions (e.g., 50% of original size) while preserving aspect ratio
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize the image proportionally
                image.Resize(newWidth, newHeight);

                // Set up SVG rasterization options (page size matches the resized image)
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Save the resized image as SVG
                image.Save(outputPath, new SvgOptions { VectorRasterizationOptions = rasterizationOptions });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}