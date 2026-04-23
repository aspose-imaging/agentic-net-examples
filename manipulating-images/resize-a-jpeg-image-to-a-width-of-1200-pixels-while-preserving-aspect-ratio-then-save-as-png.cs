using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image using the constructor that accepts a file path
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Desired width
                int targetWidth = 1200;

                // Compute height to preserve aspect ratio
                int targetHeight = (int)(jpegImage.Height * (targetWidth / (double)jpegImage.Width));

                // Resize the image (default nearest‑neighbour resample)
                jpegImage.Resize(targetWidth, targetHeight);

                // Save the resized image as PNG
                jpegImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}