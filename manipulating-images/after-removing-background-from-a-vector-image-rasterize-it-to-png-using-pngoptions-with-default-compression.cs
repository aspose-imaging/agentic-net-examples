using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to VectorImage and remove background if possible
                var vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                // Configure PNG options with default compression
                var pngOptions = new PngOptions();

                // Set up rasterization options for vector to raster conversion
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent, // Preserve transparency
                    PageSize = image.Size                 // Keep original dimensions
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}