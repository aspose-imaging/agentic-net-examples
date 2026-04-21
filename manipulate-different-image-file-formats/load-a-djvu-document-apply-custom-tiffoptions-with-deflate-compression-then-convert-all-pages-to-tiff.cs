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
        string inputPath = "sample.djvu";
        string outputPath = "sample.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load the DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        {
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options with Deflate compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;

                // Set MultiPageOptions to include all pages
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save all pages of the DjVu document as a multi‑page TIFF file
                djvuImage.Save(outputPath, tiffOptions);
            }
        }
    }
}