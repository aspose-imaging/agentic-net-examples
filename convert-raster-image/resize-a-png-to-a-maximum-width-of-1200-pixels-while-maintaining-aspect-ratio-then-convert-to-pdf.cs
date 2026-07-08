using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                const int maxWidth = 1200;

                // Resize only if the width exceeds the maximum
                if (image.Width > maxWidth)
                {
                    int newWidth = maxWidth;
                    int newHeight = (int)Math.Round((double)image.Height * maxWidth / image.Width);

                    // Resize while maintaining aspect ratio using high‑quality resampling
                    image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);
                }

                // Convert and save as PDF
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate printable PDF reports from user‑uploaded PNG screenshots while ensuring the images do not exceed 1200 px width for faster download.
 * 2. When an e‑commerce platform must batch‑process product PNG assets, downscale them to a maximum width of 1200 pixels to meet layout constraints, and archive the results as PDF catalogs.
 * 3. When a document management system receives high‑resolution PNG scans, it resizes them to a 1200 px width to preserve aspect ratio and then converts them to PDF for consistent viewing across devices.
 * 4. When a marketing automation tool creates PDF newsletters from PNG banners, it uses C# and Aspose.Imaging to limit banner width to 1200 px and maintain visual quality with high‑quality resampling.
 * 5. When a desktop utility needs to compress large PNG illustrations for legal filings, it resizes the images to a maximum width of 1200 pixels and saves them as PDF files using the Aspose.Imaging library.
 */