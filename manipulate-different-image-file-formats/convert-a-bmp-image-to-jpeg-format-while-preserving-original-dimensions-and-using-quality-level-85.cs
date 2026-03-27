using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample_converted.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options with desired quality
            JpegOptions saveOptions = new JpegOptions
            {
                Quality = 85,
                BitsPerChannel = 8 // standard 8‑bit per channel
            };

            // Save the image as JPEG preserving original dimensions
            image.Save(outputPath, saveOptions);
        }
    }
}