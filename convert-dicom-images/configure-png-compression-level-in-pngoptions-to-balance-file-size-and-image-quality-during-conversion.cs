using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\source.jpg";
        string outputPath = @"C:\Images\converted.png";

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
            // Configure PNG save options with a balanced compression level (e.g., 6)
            var pngOptions = new PngOptions
            {
                // Progressive PNG loading (optional)
                Progressive = true,

                // Use truecolor with alpha for full colour fidelity
                ColorType = PngColorType.TruecolorWithAlpha,

                // Set compression level: 0 (none) – 9 (max). 6 offers a good trade‑off.
                CompressionLevel = 6
            };

            // Save the image as PNG using the configured options
            image.Save(outputPath, pngOptions);
        }
    }
}