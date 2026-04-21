using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // Configure PNG export options with desired DPI
            PngOptions pngOptions = new PngOptions
            {
                // Set DPI (horizontal and vertical)
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            // Set up rasterization options for the EMF source
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size
            };

            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as PNG with the specified DPI
            emfImage.Save(outputPath, pngOptions);
        }
    }
}