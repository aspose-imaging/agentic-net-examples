using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\source.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (any supported format)
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with a balanced compression level (0‑9)
                var pngOptions = new PngOptions
                {
                    // Progressive loading can improve perceived loading speed
                    Progressive = true,
                    // Use truecolor with alpha for full colour fidelity
                    ColorType = PngColorType.TruecolorWithAlpha,
                    // Set a moderate compression level (e.g., 6) to balance size and quality
                    CompressionLevel = 6
                };

                // Save the image as PNG using the configured options
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}