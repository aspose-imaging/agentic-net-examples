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
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR vector image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG options to preserve alpha channel
            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.ColorType = PngColorType.TruecolorWithAlpha;
                pngOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    BackgroundColor = Color.Transparent
                };

                // Save as PNG with the configured options
                image.Save(outputPath, pngOptions);
            }
        }
    }
}