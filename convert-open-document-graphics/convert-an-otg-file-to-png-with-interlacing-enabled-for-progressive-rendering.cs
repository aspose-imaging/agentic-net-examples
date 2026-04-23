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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options with progressive (interlaced) encoding
            PngOptions pngOptions = new PngOptions
            {
                Progressive = true
            };

            // Configure rasterization options for OTG vector content
            OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };
            pngOptions.VectorRasterizationOptions = otgRaster;

            // Save the image as PNG with interlacing enabled
            image.Save(outputPath, pngOptions);
        }
    }
}