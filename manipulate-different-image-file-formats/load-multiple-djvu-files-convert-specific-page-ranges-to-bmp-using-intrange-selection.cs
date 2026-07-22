using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input DjVu files and corresponding output BMP files
            string[] inputPaths = new string[]
            {
                @"C:\Images\doc1.djvu",
                @"C:\Images\doc2.djvu"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Converted\doc1_pages_1_3.bmp",
                @"C:\Converted\doc2_pages_2_5.bmp"
            };

            // Define page ranges for each file (start and end inclusive)
            int[,] pageRanges = new int[,]
            {
                { 1, 3 }, // pages 1 to 3 for doc1.djvu
                { 2, 5 }  // pages 2 to 5 for doc2.djvu
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load DjVu image from file stream
                using (Stream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Prepare BMP save options with page range selection
                    BmpOptions bmpOptions = new BmpOptions();

                    int startPage = pageRanges[i, 0];
                    int endPage = pageRanges[i, 1];
                    // IntRange constructor expects start and end page indexes (zero‑based)
                    // Convert to zero‑based indexes
                    IntRange range = new IntRange(startPage - 1, endPage - 1);
                    bmpOptions.MultiPageOptions = new DjvuMultiPageOptions(range);

                    // Save selected pages as BMP
                    djvuImage.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to extract the first three pages of a multi‑page DjVu document and save them as BMP images for legacy Windows applications.
 * 2. When an archival system must batch‑process several DjVu files, converting only selected page intervals to BMP to reduce storage size while preserving visual fidelity.
 * 3. When a printing workflow requires converting specific pages (e.g., pages 2‑5) of scanned DjVu manuals into BMP format for compatibility with a raster‑based printer driver.
 * 4. When a document‑management tool automates the generation of thumbnail previews by loading DjVu files and exporting a defined page range as BMP files for quick viewing.
 * 5. When a software integration needs to read DjVu files from a file stream, apply an IntRange page selection, and output the chosen pages as BMP images for further image‑processing pipelines.
 */