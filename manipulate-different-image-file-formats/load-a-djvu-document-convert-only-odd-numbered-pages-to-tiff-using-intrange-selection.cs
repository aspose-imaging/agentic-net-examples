using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Prepare TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = Aspose.Imaging.FileFormats.Tiff.Enums.TiffCompressions.Deflate;
            // Example: set bits per sample to 1 (B/W) if needed
            tiffOptions.BitsPerSample = new ushort[] { 1 };

            // Select only odd‑numbered pages (1‑based) using an IntRange.
            // DjVu pages are zero‑based, so start at 0 and step by 2.
            var oddPagesRange = new IntRange(0, djvuImage.PageCount - 1, 2);
            var multiPageOptions = new DjvuMultiPageOptions(oddPagesRange);

            // Assign the multi‑page options to the TIFF options
            tiffOptions.MultiPageOptions = multiPageOptions;

            // Save the selected pages as a multi‑frame TIFF file
            djvuImage.Save(outputPath, tiffOptions);
        }
    }
}