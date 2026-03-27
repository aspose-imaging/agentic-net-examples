using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dxf";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DXF vector image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG export options
            var pngOptions = new PngOptions
            {
                // Set resolution to 72 DPI
                ResolutionSettings = new ResolutionSetting(72, 72),

                // Configure vector rasterization (background and page size)
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                }
            };

            // Save as PNG with the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}