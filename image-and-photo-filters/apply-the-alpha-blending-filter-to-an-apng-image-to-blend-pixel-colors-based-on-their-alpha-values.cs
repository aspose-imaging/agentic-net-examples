using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image (APNG or any other format)
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is an APNG, process its frames
            if (image is ApngImage apngImage)
            {
                // Iterate through each frame to access the UseAlphaBlending property
                // (Aspose.Imaging handles the actual blending during save)
                foreach (var page in apngImage.Pages)
                {
                    ApngFrame frame = (ApngFrame)page;
                    bool useAlpha = frame.UseAlphaBlending; // read-only, just for demonstration
                    // No further action required; blending is applied when saving
                }

                // Save the APNG, preserving alpha blending
                ApngOptions saveOptions = new ApngOptions
                {
                    // Default options are sufficient for alpha blending
                };
                apngImage.Save(outputPath, saveOptions);
            }
            else
            {
                // For non‑APNG images, save as PNG with alpha channel support
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                image.Save(outputPath, pngOptions);
            }
        }
    }
}