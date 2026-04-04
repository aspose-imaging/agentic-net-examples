using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.psd";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options with high‑quality smoothing
            var pngOptions = new PngOptions();

            var rasterOptions = new VectorRasterizationOptions
            {
                // Enable anti‑aliasing for smoother edges
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                // Optional: set a background color (white) and page size matching the source image
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = image.Size
            };

            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as PNG using the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}