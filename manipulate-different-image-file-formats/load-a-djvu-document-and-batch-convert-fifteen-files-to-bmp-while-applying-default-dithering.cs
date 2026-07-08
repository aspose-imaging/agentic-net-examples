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
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputDjvu";
            string outputFolder = @"C:\OutputBmp";

            // Process fifteen DjVu files named file1.djvu ... file15.djvu
            for (int i = 1; i <= 15; i++)
            {
                string inputPath = Path.Combine(inputFolder, $"file{i}.djvu");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, $"file{i}.bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu document from file stream
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Apply default dithering (Floyd‑Steinberg, 8‑bit palette)
                    djvuImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                    // Save the page as BMP
                    djvuImage.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to migrate a legacy archive of scanned DjVu documents to BMP images for compatibility with Windows applications, they can use this code to batch convert fifteen files with default Floyd‑Steinberg dithering.
 * 2. When an automated nightly job must generate low‑color BMP thumbnails from a set of DjVu pages for a web portal, the snippet provides a C# solution that reads each file via a stream, applies 8‑bit dithering, and saves the output.
 * 3. When a document‑management system requires converting incoming DjVu scans into BMP format for OCR preprocessing, this example shows how to process multiple files in a loop using Aspose.Imaging.
 * 4. When a developer is building a migration tool that moves DjVu assets from a legacy folder to a new BMP‑based repository while preserving visual fidelity through default dithering, the code demonstrates the necessary file‑system checks and image‑saving steps.
 * 5. When a batch‑processing script must ensure that each DjVu file exists before conversion and create the target directory on the fly, this C# program illustrates the proper use of FileStream, DjvuImage, and BmpOptions for reliable conversion.
 */