using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // -------------------------------------------------
            // Background removal placeholder:
            // Implement pixel‑wise processing here to make
            // the undesired background transparent.
            // Example (pseudo):
            //   foreach pixel where color == targetBackgroundColor
            //       set pixel.A = 0;
            // -------------------------------------------------

            // Save the processed image as an animated PNG (APNG)
            var apngOptions = new ApngOptions
            {
                // Default frame duration in milliseconds (optional)
                DefaultFrameTime = 100
            };

            image.Save(outputPath, apngOptions);
        }
    }
}