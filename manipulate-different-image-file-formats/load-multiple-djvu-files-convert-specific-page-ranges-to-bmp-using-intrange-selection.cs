using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu files
            string[] inputPaths = { "input1.djvu", "input2.djvu" };

            foreach (string inputPath in inputPaths)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Define output BMP file path
                string outputPath = Path.Combine("output", Path.GetFileNameWithoutExtension(inputPath) + ".bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu image from file stream
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Set up BMP save options with page range selection
                    var saveOptions = new BmpOptions();

                    // Example: export pages 1 to 3 (inclusive)
                    var pageRange = new IntRange(1, 3);
                    saveOptions.MultiPageOptions = new DjvuMultiPageOptions(pageRange);

                    // Save selected pages as BMP
                    djvuImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to batch‑convert selected pages of multiple DjVu documents into BMP images for legacy Windows applications that only accept BMP files.
 * 2. When an archival system must extract only the first three pages of each DjVu scan to generate thumbnail previews in BMP format for quick browsing.
 * 3. When a document‑processing pipeline requires converting specific page ranges from DjVu e‑books into BMP to feed an OCR engine that only supports BMP input.
 * 4. When a reporting tool has to programmatically render chosen pages of DjVu manuals as BMP graphics for inclusion in PDF reports generated with .NET.
 * 5. When a migration script must read DjVu files from a folder, select a defined page interval, and save those pages as BMP files to comply with a third‑party vendor’s image format requirements.
 */