using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\page1.jpg",
            @"C:\Images\page2.jpg",
            @"C:\Images\page3.jpg"
        };

        // Hard‑coded output PDF file
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

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
            outputDir = "."; // fallback to current directory
        Directory.CreateDirectory(outputDir);

        // Load each JPG into an Image instance
        List<Image> loadedImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            // Load rule
            Image img = Image.Load(inputPath);
            loadedImages.Add(img);
        }

        // Create a multipage image from the loaded JPGs (create rule)
        using (Image multipageImage = Image.Create(loadedImages.ToArray()))
        {
            // Prepare PDF export options (high‑resolution output can be controlled via VectorRasterizationOptions if needed)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a single PDF document (save rule)
            multipageImage.Save(outputPath, pdfOptions);
        }

        // Dispose the individual images (they are not disposed by the multipage image when disposeImages = false)
        foreach (Image img in loadedImages)
        {
            img.Dispose();
        }
    }
}