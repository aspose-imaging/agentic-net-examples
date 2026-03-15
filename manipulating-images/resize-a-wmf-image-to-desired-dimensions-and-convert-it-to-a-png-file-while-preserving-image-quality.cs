using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";

        // Desired output PNG file path
        string outputPath = "output.png";

        // Desired dimensions
        int newWidth = 800;
        int newHeight = 600;

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Resize using high‑quality Lanczos resampling
            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Prepare PNG save options
            var pngOptions = new PngOptions
            {
                // Optional: specify the source for the output file
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the resized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}