using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Configure rasterization options for the EMF vector image
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Set PNG save options and attach rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rendered bitmap as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}