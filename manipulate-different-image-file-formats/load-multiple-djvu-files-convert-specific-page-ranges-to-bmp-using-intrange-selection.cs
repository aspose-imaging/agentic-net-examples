using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input DjVu files
            string[] inputPaths = {
                @"C:\Images\sample1.djvu",
                @"C:\Images\sample2.djvu"
            };

            // Hard‑coded output directory
            string outputDirectory = @"C:\Images\Converted";

            // Define the page ranges to export (e.g., pages 1‑3 and page 5)
            IntRange[] pageRanges = {
                new IntRange(1, 3),
                new IntRange(5, 5)
            };

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path (one BMP per DjVu file containing the selected pages)
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + "_selected.bmp"
                );

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Open the DjVu file
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure BMP options with the desired page ranges
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions(pageRanges)
                    };

                    // Save the selected pages as a single BMP file
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
 * 1. When a developer needs to extract only certain pages from a multi‑page DjVu document (e.g., pages 1‑3 and 5) and save them as a single BMP image for legacy Windows applications.
 * 2. When an archival system must batch‑process several DjVu files and generate BMP previews of selected pages to display in a web‑based document viewer.
 * 3. When a printing workflow requires converting specific DjVu pages to BMP format before sending them to a raster printer that only accepts BMP files.
 * 4. When a digital forensics tool needs to isolate and export particular pages from scanned DjVu evidence files into BMP for pixel‑level analysis.
 * 5. When a mobile app backend has to create lightweight BMP thumbnails of chosen DjVu pages to reduce bandwidth while preserving image fidelity.
 */