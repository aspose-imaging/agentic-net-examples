using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Calculate new dimensions (example: double the size)
            int newWidth = image.Width * 2;
            int newHeight = image.Height * 2;

            // Resize using bicubic (CubicConvolution) interpolation
            image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

            // Convert the resized image to PDF
            image.Save(outputPath, new PdfOptions());
        }
    }
}