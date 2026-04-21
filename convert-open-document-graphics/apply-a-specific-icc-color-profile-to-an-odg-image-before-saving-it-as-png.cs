using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.png";

        // Validate input image existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage (vector format)
            var odgImage = image as OdgImage;
            if (odgImage == null)
            {
                Console.Error.WriteLine("Failed to load ODG image.");
                return;
            }

            // Configure PNG save options
            var pngOptions = new PngOptions();

            // Set rasterization options for vector to raster conversion
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = odgImage.Size
            };
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save as PNG
            odgImage.Save(outputPath, pngOptions);
        }
    }
}