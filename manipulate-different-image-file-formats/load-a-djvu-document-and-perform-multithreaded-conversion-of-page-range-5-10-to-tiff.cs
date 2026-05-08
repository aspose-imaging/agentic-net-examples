using System;
using System.IO;
using System.Threading.Tasks;
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
            string inputPath = @"C:\Temp\sample.djvu";
            string outputDir = @"C:\Temp\Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Zero‑based page indexes for pages 5‑10
                int[] pageIndexes = new int[] { 4, 5, 6, 7, 8, 9 };

                // Common TIFF save options
                TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                tiffOptions.Compression = Aspose.Imaging.FileFormats.Tiff.Enums.TiffCompressions.Deflate;
                tiffOptions.BitsPerSample = new ushort[] { 1 };

                // Convert each page in parallel
                Parallel.ForEach(pageIndexes, pageIndex =>
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex + 1}.tif");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // DjvuImage is not guaranteed to be thread‑safe; synchronize access
                    lock (djvuImage)
                    {
                        var djvuPage = djvuImage.DjvuPages[pageIndex];
                        djvuPage.Save(outputPath, tiffOptions);
                    }
                });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}