using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization options for high‑resolution rendering
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    // Optional: set background color if needed
                    BackgroundColor = Color.White
                };

                // Configure BMP save options with 300 DPI resolution
                BmpOptions bmpOptions = new BmpOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = vectorOptions
                };

                // Save the rendered bitmap
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}