using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for transparent background
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Aspose.Imaging.Color.Transparent,
                RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
            };

            // Set PNG save options with the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save as PNG preserving alpha channel
            image.Save(outputPath, pngOptions);
        }
    }
}