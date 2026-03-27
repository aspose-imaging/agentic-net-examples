using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample.grayscale.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options to produce a grayscale image
            JpegOptions saveOptions = new JpegOptions
            {
                ColorType = JpegCompressionColorMode.Grayscale
                // Other options (quality, resolution, etc.) can be set here if needed
            };

            // Save the image using the configured options
            image.Save(outputPath, saveOptions);
        }
    }
}