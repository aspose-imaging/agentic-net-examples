using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.webp";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply grayscale, and save as JPEG
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Convert to grayscale
            image.Grayscale();

            // Save with JPEG options
            JpegOptions options = new JpegOptions();
            image.Save(outputPath, options);
        }
    }
}