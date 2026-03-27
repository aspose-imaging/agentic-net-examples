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
        string outputPath = @"C:\Temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document from stream
        using (FileStream stream = File.OpenRead(inputPath))
        {
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                // Optional: force B/W output
                tiffOptions.BitsPerSample = new ushort[] { 1 };

                // Select pages 5‑7 (zero‑based indexes 4,5,6)
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 4, 5, 6 });

                // Save selected pages as a multipage TIFF
                djvuImage.Save(outputPath, tiffOptions);
            }
        }
    }
}