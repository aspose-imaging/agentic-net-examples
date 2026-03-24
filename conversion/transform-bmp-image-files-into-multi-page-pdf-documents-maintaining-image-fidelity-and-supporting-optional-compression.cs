using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageOptions; // PdfOptions and PdfImageCompressionOptions are here

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input BMP file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\page1.bmp",
            @"C:\Images\page2.bmp",
            @"C:\Images\page3.bmp"
        };

        // Hardcoded output PDF file path
        string outputPath = @"C:\Output\combined.pdf";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP images into a list
        List<Image> sourceImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            Image img = Image.Load(inputPath);
            sourceImages.Add(img);
        }

        // Create a multipage image from the loaded BMPs
        using (Image pdfImage = Image.Create(sourceImages.ToArray()))
        {
            // Configure PDF save options (optional compression)
            PdfOptions pdfOptions = new PdfOptions();
            // Uncomment the following line to set a specific compression option
            // pdfOptions.ImageCompression = PdfImageCompressionOptions.Auto;

            // Save the multipage PDF
            pdfImage.Save(outputPath, pdfOptions);
        }

        // Dispose source images
        foreach (Image img in sourceImages)
        {
            img.Dispose();
        }
    }
}