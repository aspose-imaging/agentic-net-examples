using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Input CDR files (hardcoded)
        string[] inputPaths = new string[]
        {
            "Input/file1.cdr",
            "Input/file2.cdr",
            "Input/file3.cdr"
        };

        // Validate each input file
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Output PDF file (hardcoded)
        string outputPath = "Output/Combined.pdf";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect page sizes from all CDR documents
        List<(int Width, int Height)> pageSizes = new List<(int, int)>();

        foreach (string cdrPath in inputPaths)
        {
            using (CdrImage cdrImage = (CdrImage)Image.Load(cdrPath))
            {
                // Cache all pages
                cdrImage.CacheData();
                foreach (CdrImagePage page in cdrImage.Pages)
                {
                    page.CacheData();
                    pageSizes.Add((page.Width, page.Height));
                }
            }
        }

        // Prepare PDF options with per‑page rasterization settings
        PdfOptions pdfOptions = new PdfOptions();

        VectorRasterizationOptions[] rasterOptions = new VectorRasterizationOptions[pageSizes.Count];
        for (int i = 0; i < pageSizes.Count; i++)
        {
            rasterOptions[i] = new CdrRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = pageSizes[i].Width,
                PageHeight = pageSizes[i].Height,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None
            };
        }

        pdfOptions.MultiPageOptions = new MultiPageOptions
        {
            PageRasterizationOptions = rasterOptions
        };

        // Use the first CDR image as a dummy source for saving
        using (Image dummy = Image.Load(inputPaths[0]))
        {
            dummy.Save(outputPath, pdfOptions);
        }
    }
}