using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (Image webpImage = Image.Load(inputPath))
        {
            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions
            {
                // Optional: set page size, metadata, etc.
                // PageSize = new SizeF(595, 842) // A4 size in points
            };

            // Save the image as a PDF (single page)
            webpImage.Save(outputPath, pdfOptions);
        }

        // -----------------------------------------------------------------
        // To convert multiple WebP images into a multi‑page PDF, repeat the
        // loading step for each file and add the raster pages to a
        // MultiPageImage. Aspose.Imaging supports creating a new
        // MultiPageImage from the first loaded image and then calling
        // AddPage for subsequent images. Finally, save the combined image
        // with PdfOptions.
        // -----------------------------------------------------------------
        /*
        string[] webpFiles = new[] { @"c:\temp\img1.webp", @"c:\temp\img2.webp", @"c:\temp\img3.webp" };
        string multiPagePdf = @"c:\temp\combined.pdf";

        // Verify all input files exist
        foreach (var path in webpFiles)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(multiPagePdf));

        // Load the first image and treat it as a multi‑page container
        using (Image firstImage = Image.Load(webpFiles[0]))
        {
            // Cast to IMultipageImage to enable adding pages
            var multiPage = firstImage as IMultipageImage;
            if (multiPage == null)
            {
                Console.Error.WriteLine("First image does not support multiple pages.");
                return;
            }

            // Add remaining images as new pages
            for (int i = 1; i < webpFiles.Length; i++)
            {
                using (Image nextImage = Image.Load(webpFiles[i]))
                {
                    // Convert the raster image to a page and add it
                    multiPage.AddPage(nextImage);
                }
            }

            // Save the combined multi‑page image as PDF
            PdfOptions multiPdfOptions = new PdfOptions();
            firstImage.Save(multiPagePdf, multiPdfOptions);
        }
        */
    }
}