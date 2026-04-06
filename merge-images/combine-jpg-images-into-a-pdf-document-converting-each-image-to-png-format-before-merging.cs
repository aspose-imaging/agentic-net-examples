using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hard‑coded output PDF file
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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // List to hold the PNG images (converted from JPG)
        List<Image> pngImages = new List<Image>();

        // Convert each JPG to PNG (in memory) and store the resulting Image objects
        foreach (string inputPath in inputPaths)
        {
            // Load the original JPG image
            using (Image jpgImage = Image.Load(inputPath))
            {
                // Save the JPG image to a memory stream as PNG
                using (MemoryStream pngStream = new MemoryStream())
                {
                    jpgImage.Save(pngStream, new PngOptions());
                    pngStream.Position = 0; // Reset stream position for reading

                    // Load the PNG image from the memory stream
                    Image pngImage = Image.Load(pngStream);
                    pngImages.Add(pngImage);
                }
            }
        }

        // Create a multipage image (PDF) from the PNG images
        using (Image pdfImage = Image.Create(pngImages.ToArray()))
        {
            // Save the multipage image as a PDF document
            PdfOptions pdfOptions = new PdfOptions();
            pdfImage.Save(outputPath, pdfOptions);
        }

        // Dispose the temporary PNG images
        foreach (Image img in pngImages)
        {
            img.Dispose();
        }
    }
}