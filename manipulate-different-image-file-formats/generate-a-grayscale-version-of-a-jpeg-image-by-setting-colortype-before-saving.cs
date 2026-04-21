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
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output_grayscale.jpg";

        // Verify that the input file exists; report and exit if it does not
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options to force grayscale output
            JpegOptions saveOptions = new JpegOptions
            {
                // Set the color mode to Grayscale
                ColorType = JpegCompressionColorMode.Grayscale,

                // Optional: preserve quality (1‑100). Here we keep maximum quality.
                Quality = 100
            };

            // Save the image using the configured options
            image.Save(outputPath, saveOptions);
        }
    }
}