using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input PSD file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\page1.psd",
            @"C:\Images\page2.psd",
            @"C:\Images\page3.psd"
        };

        // Hardcoded output PDF file path
        string outputPath = @"C:\Images\CombinedDocument.pdf";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load each PSD image
        List<Image> loadedImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            // Load the PSD image
            Image img = Image.Load(inputPath);
            loadedImages.Add(img);
        }

        // Create a multipage image from the loaded PSD images.
        // The overload with disposeImages = true will dispose the source images after creation.
        using (Image multipageImage = Image.Create(loadedImages.ToArray(), true))
        {
            // Prepare PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPath, pdfOptions);
        }
    }
}