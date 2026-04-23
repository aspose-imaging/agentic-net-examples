using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options with transparent background
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new OdgRasterizationOptions
                {
                    // Preserve transparency
                    BackgroundColor = Color.Transparent
                }
            };

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}