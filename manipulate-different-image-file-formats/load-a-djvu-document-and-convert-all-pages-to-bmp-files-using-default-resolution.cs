using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = @"c:\temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the DjVu document
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output BMP file name based on page number
                        string outputPath = $@"c:\temp\sample.{djvuPage.PageNumber}.bmp";

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as BMP using default resolution
                        djvuPage.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract each page of a DjVu document and save them as high‑compatibility BMP files for legacy Windows applications using Aspose.Imaging for .NET.
 * 2. When an archival system must batch‑convert scanned DjVu files into BMP images at the default resolution to preserve visual fidelity before indexing.
 * 3. When a document‑management workflow requires converting multi‑page DjVu manuals into separate BMP images for thumbnail generation or OCR preprocessing.
 * 4. When a C# service processes user‑uploaded DjVu files and needs to store each page as a BMP file on disk for downstream image analysis.
 * 5. When a migration tool moves DjVu assets to a BMP‑based repository, iterating through pages with Aspose.Imaging to ensure each page is saved correctly.
 */