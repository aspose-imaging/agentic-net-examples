using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputPath = @"C:\Temp\sample.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu image from file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Configure TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Deflate,
                // Example: convert to 1-bit B/W if needed
                BitsPerSample = new ushort[] { 1 }
            };

            // Specify page range 2‑5 (zero‑based indexes 1‑4)
            tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 1, 2, 3, 4 });

            // Optional: set page titles
            tiffOptions.MultiPageOptions.PageTitles = new string[]
            {
                "Page 2", "Page 3", "Page 4", "Page 5"
            };

            // Save as multipage TIFF
            djvuImage.Save(outputPath, tiffOptions);
        }
    }
}