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
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputPath = @"C:\Temp\sample.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Configure TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Compression = TiffCompressions.Deflate
            };

            // Specify pages 2‑5 (zero‑based indexes 1‑4)
            DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(new int[] { 1, 2, 3, 4 });
            tiffOptions.MultiPageOptions = multiPageOptions;

            // Save as a multipage TIFF file
            djvuImage.Save(outputPath, tiffOptions);
        }
    }
}