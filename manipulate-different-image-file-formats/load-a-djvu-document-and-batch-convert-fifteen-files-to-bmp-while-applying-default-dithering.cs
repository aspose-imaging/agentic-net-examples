// HOW-TO: Batch Convert DjVu Files to BMP with Default Dithering in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input directory and file names (15 DjVu files)
            string inputDirectory = @"C:\Input";
            string[] inputFiles = new string[]
            {
                "file1.djvu", "file2.djvu", "file3.djvu", "file4.djvu", "file5.djvu",
                "file6.djvu", "file7.djvu", "file8.djvu", "file9.djvu", "file10.djvu",
                "file11.djvu", "file12.djvu", "file13.djvu", "file14.djvu", "file15.djvu"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Output";

            foreach (string fileName in inputFiles)
            {
                string inputPath = Path.Combine(inputDirectory, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load DjVu document from file stream
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                {
                    // Apply default dithering (Floyd‑Steinberg, 8‑bit palette)
                    djvuImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                    // Save each page as a BMP file
                    for (int i = 0; i < djvuImage.Pages.Length; i++)
                    {
                        var page = djvuImage.Pages[i];
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_page{i}.bmp";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as BMP
                        page.Save(outputPath, new BmpOptions());
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
 * 1. When you need to extract each page of multiple DjVu documents and save them as BMP images for legacy Windows applications that only support BMP.
 * 2. When a document management system must archive scanned DjVu files as lossless BMPs with consistent Floyd‑Steinberg dithering to preserve visual quality.
 * 3. When an automated pipeline processes a batch of fifteen DjVu files and converts them to BMP for further pixel‑level analysis or OCR preprocessing.
 * 4. When you want to ensure all output BMP files use an 8‑bit palette and default dithering to reduce file size while maintaining acceptable grayscale rendering.
 * 5. When integrating Aspose.Imaging into a C# service that monitors a folder, loads DjVu streams, applies default dithering, and writes each page as a separate BMP for downstream image processing tools.
 */
