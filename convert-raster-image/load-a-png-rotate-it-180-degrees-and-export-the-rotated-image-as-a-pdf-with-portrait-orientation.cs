using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Rotate the image 180 degrees
            pngImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

            // Export the rotated image as a PDF (portrait orientation is default)
            pngImage.Save(outputPath, new PdfOptions());
        }
    }
}