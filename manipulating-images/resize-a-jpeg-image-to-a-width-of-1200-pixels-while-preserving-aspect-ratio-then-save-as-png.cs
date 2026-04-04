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
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\sample_resized.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image using the JpegImage(string) constructor
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Desired width
            int newWidth = 1200;

            // Calculate height to preserve aspect ratio
            int newHeight = (int)Math.Round((double)jpegImage.Height * newWidth / jpegImage.Width);

            // Resize the image (default NearestNeighbourResample)
            jpegImage.Resize(newWidth, newHeight);

            // Save as PNG using PngOptions
            PngOptions pngOptions = new PngOptions();
            jpegImage.Save(outputPath, pngOptions);
        }
    }
}