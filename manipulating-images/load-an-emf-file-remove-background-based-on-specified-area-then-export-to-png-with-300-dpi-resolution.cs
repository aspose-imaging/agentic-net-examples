using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
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

        // Load EMF image
        using (EmfImage emf = (EmfImage)Image.Load(inputPath))
        {
            // Remove background (global removal)
            emf.RemoveBackground();

            // Configure PNG export with 300 DPI resolution
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                ResolutionSettings = new ResolutionSetting(300, 300),
                Source = new FileCreateSource(outputPath, false),
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageSize = emf.Size,
                    BackgroundColor = Color.Transparent
                }
            };

            // Save as PNG
            emf.Save(outputPath, pngOptions);
        }
    }
}