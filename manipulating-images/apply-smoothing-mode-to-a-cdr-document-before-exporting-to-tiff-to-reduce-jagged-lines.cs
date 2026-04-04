using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.tiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR document
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options with smoothing
            var rasterOptions = new CdrRasterizationOptions
            {
                SmoothingMode = SmoothingMode.AntiAlias,
                BackgroundColor = Color.White
            };

            // Set up TIFF save options and attach rasterization options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Export to TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}