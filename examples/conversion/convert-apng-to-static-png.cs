using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source APNG file
        string sourcePath = "input.apng";

        // Path for the resulting static PNG file
        string outputPath = "output.png";

        // Load the APNG image (multi‑frame) using the provided load rule
        using (Image apngImage = Image.Load(sourcePath))
        {
            // Save the first (default) frame as a static PNG.
            // PNG is a single‑frame format, so only the active frame is written.
            apngImage.Save(outputPath, new PngOptions());
        }

        Console.WriteLine("Conversion completed.");
    }
}