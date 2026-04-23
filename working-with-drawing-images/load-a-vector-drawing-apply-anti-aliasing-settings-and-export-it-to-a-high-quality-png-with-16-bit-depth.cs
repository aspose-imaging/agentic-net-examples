using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/vector.svg";
        string outputPath = "Output/high_quality.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG export options with 16‑bit depth and truecolor with alpha
            PngOptions pngOptions = new PngOptions
            {
                BitDepth = 16,
                ColorType = PngColorType.TruecolorWithAlpha,
                // Configure vector rasterization (anti‑aliasing)
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                }
            };

            // Save the rasterized PNG
            image.Save(outputPath, pngOptions);
        }
    }
}