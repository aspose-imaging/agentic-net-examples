using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample_resolved.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to PngImage to access PNG‑specific members
            PngImage pngImage = (PngImage)image;

            // Set the desired horizontal and vertical DPI
            double dpiX = 300.0;
            double dpiY = 300.0;
            pngImage.SetResolution(dpiX, dpiY);

            // Save the image with the new resolution
            pngImage.Save(outputPath);
        }
    }
}