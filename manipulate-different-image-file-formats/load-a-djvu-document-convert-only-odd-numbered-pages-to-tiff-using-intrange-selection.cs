using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.djvu";
        string outputPath = @"c:\temp\odd_pages.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document from a file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Determine odd‑numbered pages (page numbers start at 1, so indexes 0,2,4,...)
            int pageCount = djvuImage.PageCount;
            List<int> oddPageIndexes = new List<int>();
            for (int i = 0; i < pageCount; i++)
            {
                if (i % 2 == 0) // even index => odd page number
                {
                    oddPageIndexes.Add(i);
                }
            }

            // Configure TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = TiffCompressions.Deflate;
            // Example: set 1‑bit per sample for B/W output (optional)
            tiffOptions.BitsPerSample = new ushort[] { 1 };

            // Specify the pages to export using DjvuMultiPageOptions
            tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(oddPageIndexes.ToArray());

            // Save selected pages to a multi‑page TIFF file
            djvuImage.Save(outputPath, tiffOptions);
        }
    }
}