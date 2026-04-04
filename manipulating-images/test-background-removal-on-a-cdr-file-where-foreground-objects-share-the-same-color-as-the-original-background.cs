using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the vector image (CDR)
        using (var image = Image.Load(inputPath))
        {
            // Configure PNG options with transparency and vector rasterization settings
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                }
            };

            // Cast to VectorImage and remove background if possible
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            // Save the result as PNG with transparent background
            image.Save(outputPath, pngOptions);
        }
    }
}