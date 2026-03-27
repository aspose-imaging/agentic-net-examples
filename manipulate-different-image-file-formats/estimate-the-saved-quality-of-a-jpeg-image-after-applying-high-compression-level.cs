using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_high_compression.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure JPEG save options for high compression (low quality)
        JpegOptions jpegOptions = new JpegOptions
        {
            // Low quality value (1-100) results in higher compression
            Quality = 10,
            // Optional: use progressive compression mode
            CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
            // Keep other defaults (e.g., BitsPerChannel = 8)
        };

        // Load the source image, apply any processing if needed, and save with the options
        using (Image image = Image.Load(inputPath))
        {
            // No additional processing in this example
            image.Save(outputPath, jpegOptions);
        }

        // Inform the user about the applied compression level
        Console.WriteLine($"Image saved with high compression (Quality={jpegOptions.Quality}) to: {outputPath}");
    }
}