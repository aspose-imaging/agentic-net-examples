using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.eps";
        string outputPath = @"C:\Images\output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Adjust line join style to round.
            // Note: Aspose.Imaging does not expose a direct property to modify EPS line join style.
            // If such functionality exists, it would be applied here.
            // Example (hypothetical):
            // image.LineJoin = PenLineJoin.Round;

            // Prepare PNG export options with rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                }
            };

            // Save the modified image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}