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
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\output.tif";

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
            // Configure TIFF save options
            TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
            saveOptions.Compression = TiffCompressions.Deflate;
            // Optional: force B/W output
            saveOptions.BitsPerSample = new ushort[] { 1 };

            // Specify pages 5‑7 (zero‑based indexes 4,5,6) for the multipage TIFF
            saveOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 4, 5, 6 });

            // Save the selected pages as a multipage TIFF file
            djvuImage.Save(outputPath, saveOptions);
        }
    }
}