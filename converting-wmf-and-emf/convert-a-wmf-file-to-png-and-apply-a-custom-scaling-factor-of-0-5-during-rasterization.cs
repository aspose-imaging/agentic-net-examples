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

        // Load WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WmfImage for vector rasterization options
            var wmfImage = (WmfImage)image;

            // Create rasterization options with 0.5 scaling factor
            var rasterOptions = new WmfRasterizationOptions
            {
                // Scale page size to 50%
                PageSize = new SizeF(wmfImage.Width * 0.5f, wmfImage.Height * 0.5f),
                BackgroundColor = Color.White
            };

            // Set PNG save options with the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized PNG
            wmfImage.Save(outputPath, pngOptions);
        }
    }
}