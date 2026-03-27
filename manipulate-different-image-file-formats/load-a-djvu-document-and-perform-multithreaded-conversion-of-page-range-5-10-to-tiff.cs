using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
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

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the DjVu document
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Define the page range (5‑10 inclusive, zero‑based indices 4‑9)
            int startPage = 5; // 1‑based page number
            int endPage = 10;  // inclusive

            // Convert each page in parallel
            Parallel.For(startPage, endPage + 1, pageNumber =>
            {
                // DjvuPages array is zero‑based, adjust index
                int pageIndex = pageNumber - 1;

                // Guard against out‑of‑range indices
                if (pageIndex < 0 || pageIndex >= djvuImage.DjvuPages.Length)
                    return;

                // Prepare output file path for this page
                string outputPath = Path.Combine(outputDirectory, $"page_{pageNumber}.tif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Deflate,
                    BitsPerSample = new ushort[] { 1 }
                };

                // Save the page as a TIFF image
                djvuImage.DjvuPages[pageIndex].Save(outputPath, tiffOptions);
            });
        }
    }
}