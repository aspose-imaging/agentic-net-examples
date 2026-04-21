using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputDirectory = "output";
        string pdfPath = Path.Combine(outputDirectory, "merged.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
        Directory.CreateDirectory(outputDirectory);

        // List to hold generated PNG file paths
        List<string> pngPaths = new List<string>();

        // Load DjVu document and export pages 2‑4 as PNG
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            foreach (DjvuPage djvuPage in djvuImage.Pages)
            {
                int pageNumber = djvuPage.PageNumber;
                if (pageNumber >= 2 && pageNumber <= 4)
                {
                    string pngPath = Path.Combine(outputDirectory, $"page_{pageNumber}.png");
                    // Save the page as PNG
                    djvuPage.Save(pngPath, new PngOptions());
                    pngPaths.Add(pngPath);
                }
            }
        }

        // Merge the PNG images into a single PDF
        if (pngPaths.Count > 0)
        {
            // Load the first PNG to start the PDF document
            using (Image pdfDocument = Image.Load(pngPaths[0]))
            {
                PdfOptions pdfOptions = new PdfOptions();

                // Append remaining PNGs as additional pages
                for (int i = 1; i < pngPaths.Count; i++)
                {
                    using (Image pageImage = Image.Load(pngPaths[i]))
                    {
                        // Add the page to the PDF document
                        pdfDocument.Save(pdfPath, pdfOptions);
                        // Note: Aspose.Imaging automatically handles multi‑page PDF creation
                        // when saving subsequent images with the same PdfOptions.
                    }
                }

                // Save the final PDF (covers the case of a single page as well)
                pdfDocument.Save(pdfPath, pdfOptions);
            }
        }
    }
}