using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.djvu";
            string outputDirectory = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through pages and process pages 10 to 15 inclusive
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        if (djvuPage.PageNumber >= 10 && djvuPage.PageNumber <= 15)
                        {
                            // Build output file path
                            string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.png");

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            djvuPage.Save(outputPath, new PngOptions());
                        }
                    }
                }
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
 * 1. When a developer needs to extract pages 10‑15 from a multi‑page DjVu file and generate PNG thumbnails for an online document viewer, they can use this code.
 * 2. When a legal firm wants to convert specific pages of scanned case files stored as DjVu into high‑resolution PNGs for inclusion in a PDF report, this snippet provides the needed C# solution.
 * 3. When an e‑learning platform must batch‑process selected chapters of DjVu textbooks into PNG images for mobile app consumption, the code demonstrates how to load the DjVu document and save the chosen page range.
 * 4. When a digital archiving system requires automated conversion of a DjVu archive’s pages 10‑15 into PNG format for OCR preprocessing, the example shows the necessary Aspose.Imaging operations.
 * 5. When a developer is building a Windows service that monitors a folder for new DjVu uploads and needs to convert a defined page interval to PNG files for downstream image analysis, this code illustrates the required steps.
 */