using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load each JPG image into a list
        List<Image> loadedImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            // Load the image using Aspose.Imaging.Image.Load
            Image img = Image.Load(inputPath);
            loadedImages.Add(img);
        }

        // Create a multipage image from the loaded JPGs
        using (Image multipageImage = Image.Create(loadedImages.ToArray()))
        {
            // Set PDF export options (high resolution can be controlled via VectorRasterizationOptions if needed)
            PdfOptions pdfOptions = new PdfOptions
            {
                // Example: keep original resolution
                UseOriginalImageResolution = true
            };

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPath, pdfOptions);
        }

        // Dispose loaded individual images (if not already disposed by the multipage image)
        foreach (Image img in loadedImages)
        {
            img.Dispose();
        }
    }
}