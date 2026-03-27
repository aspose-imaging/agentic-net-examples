using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output\\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for ODG to PNG conversion
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Set PNG save options and attach rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}