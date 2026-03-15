using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input multipage image (e.g., TIFF, GIF, WebP, etc.)
        string inputPath = "input.tif";

        // Output path for the converted multipage format (APNG in this example)
        string outputPath = "output.apng";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Export all pages/frames to APNG while preserving fidelity
            image.Save(outputPath, new ApngOptions());
        }
    }
}