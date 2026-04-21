using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_high_compression.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure JPEG save options for high compression (low quality)
        JpegOptions saveOptions = new JpegOptions
        {
            // Quality range is 1-100; lower values increase compression
            Quality = 10,
            // Use progressive compression as an example
            CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
            BitsPerChannel = 8,
            // Optional: set resolution (not required for quality estimation)
            ResolutionSettings = new ResolutionSetting(96.0, 96.0),
            ResolutionUnit = ResolutionUnit.Inch
        };

        // Load the source image, apply options, and save
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, saveOptions);
        }

        // Output the estimated quality used for compression
        Console.WriteLine($"Image saved with high compression. Quality set to {saveOptions.Quality} (1 = lowest, 100 = highest).");
    }
}