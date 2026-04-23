using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input EMF file paths
            string[] inputPaths = new string[]
            {
                "input1.emf",
                "input2.emf",
                "input3.emf"
            };

            // Validate each input file
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Hardcoded output PDF path
            string outputPath = "merged.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load each EMF image
            List<Image> loadedImages = new List<Image>();
            foreach (string inputPath in inputPaths)
            {
                Image img = Image.Load(inputPath);
                loadedImages.Add(img);
            }

            // Create a multipage image from the loaded EMF images
            using (Image multipage = Image.Create(loadedImages.ToArray(), true))
            {
                // Save the multipage image as a PDF
                PdfOptions pdfOptions = new PdfOptions();
                multipage.Save(outputPath, pdfOptions);
            }

            // Dispose loaded images
            foreach (Image img in loadedImages)
            {
                img.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}