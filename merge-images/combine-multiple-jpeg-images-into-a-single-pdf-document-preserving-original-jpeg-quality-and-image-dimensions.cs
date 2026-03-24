using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPEG file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hard‑coded output PDF file path
        string outputPath = @"C:\Images\Combined.pdf";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load all JPEG images
        List<Image> loadedImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            // Using Aspose.Imaging.Image.Load to read the JPEG
            Image img = Image.Load(inputPath);
            loadedImages.Add(img);
        }

        // Create a multipage image from the loaded JPEGs.
        // The overload with 'disposeImages = true' will dispose the source images after creation.
        using (Image pdfImage = Image.Create(loadedImages.ToArray(), true))
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the multipage image as a PDF document
            pdfImage.Save(outputPath, new PdfOptions());
        }

        // All resources are disposed by the using statements
    }
}