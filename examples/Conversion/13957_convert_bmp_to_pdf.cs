using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect input BMP path as first argument and output PDF path as second argument.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <exe> <input.bmp> <output.pdf>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the BMP image.
        using (Image image = Image.Load(inputPath))
        {
            // Save the image as PDF using default options.
            image.Save(outputPath, new PdfOptions());
        }

        Console.WriteLine($"Converted '{inputPath}' to PDF at '{outputPath}'.");
    }
}