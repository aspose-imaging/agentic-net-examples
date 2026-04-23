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
        string outputPath = @"C:\Images\sample_output.tif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with smoothing
                var rasterOptions = new CdrRasterizationOptions
                {
                    // Apply antialiasing to reduce jagged lines
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                };

                // Prepare TIFF save options and attach rasterization settings
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as TIFF
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}