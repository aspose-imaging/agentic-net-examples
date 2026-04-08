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
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.png";

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
            // Configure rasterization options for WMF -> PNG conversion
            var rasterOptions = new WmfRasterizationOptions
            {
                // Preserve the original size
                PageSize = image.Size,
                // Set transparent background
                BackgroundColor = Aspose.Imaging.Color.Transparent,
                // Automatic render mode (EMF fallback if present)
                RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
            };

            // PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                // Ensure vector data is rasterized using the above options
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as PNG with transparency
            image.Save(outputPath, pngOptions);
        }
    }
}