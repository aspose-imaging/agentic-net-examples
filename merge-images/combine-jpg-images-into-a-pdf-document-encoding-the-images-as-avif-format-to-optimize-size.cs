using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hardcoded output PDF file
        string outputPath = @"C:\Images\CombinedOutput.pdf";

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

        // Load each JPG image
        List<Image> loadedImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            Image img = Image.Load(inputPath);
            loadedImages.Add(img);
        }

        // Create a multipage image (PDF) from the loaded images
        using (Image pdfImage = Image.Create(loadedImages.ToArray()))
        {
            // Save the multipage image as PDF
            pdfImage.Save(outputPath, new PdfOptions());
        }

        // Dispose loaded JPG images
        foreach (Image img in loadedImages)
        {
            img.Dispose();
        }
    }
}