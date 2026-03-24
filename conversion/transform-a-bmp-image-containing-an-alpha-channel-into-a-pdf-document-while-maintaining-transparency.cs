using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image (which may contain an alpha channel)
        using (Image image = Image.Load(inputPath))
        {
            // Save the image as a PDF while preserving transparency.
            // PdfOptions uses the default settings which keep the alpha channel.
            image.Save(outputPath, new PdfOptions());
        }
    }
}