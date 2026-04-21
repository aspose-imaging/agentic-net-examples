using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputDir = @"C:\Temp\TiffPages";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional)
        Directory.CreateDirectory(outputDir);

        // Load DjVu document from file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Define page range (5‑10) using 1‑based page numbers
            int startPage = 5; // inclusive
            int endPage = 10;  // inclusive

            // Parallel processing of each page in the range
            Parallel.For(startPage, endPage + 1, pageNumber =>
            {
                // DjvuPage collection is zero‑based, adjust index
                int index = pageNumber - 1;
                if (index < 0 || index >= djvuImage.DjvuPages.Length)
                {
                    // Skip invalid page numbers silently
                    return;
                }

                DjvuPage djvuPage = djvuImage.DjvuPages[index];

                // Prepare output file path for this page
                string outputPath = Path.Combine(outputDir, $"page_{pageNumber}.tif");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Deflate,
                    BitsPerSample = new ushort[] { 1 } // B/W conversion if needed
                };

                // Save the individual page as a TIFF file
                djvuPage.Save(outputPath, tiffOptions);
            });
        }
    }
}