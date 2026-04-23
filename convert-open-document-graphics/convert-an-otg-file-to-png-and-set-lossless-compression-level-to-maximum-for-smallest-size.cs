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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options with maximum lossless compression
            var pngOptions = new PngOptions
            {
                CompressionLevel = 9,                     // Highest compression (0‑9)
                // Optional: keep other defaults for lossless output
                // Progressive = false,
                // FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive,
            };

            // Configure rasterization of the vector OTG content
            var otgRasterization = new OtgRasterizationOptions
            {
                PageSize = image.Size                     // Preserve original dimensions
            };
            pngOptions.VectorRasterizationOptions = otgRasterization;

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}