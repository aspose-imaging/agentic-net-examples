using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image, resize with bicubic interpolation, and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            int newWidth = image.Width * 2;   // Example scaling factor
            int newHeight = image.Height * 2;

            // Resize using bicubic (CubicConvolution) interpolation
            image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

            // Save the high‑quality result to PDF
            image.Save(outputPath, new PdfOptions());
        }
    }
}