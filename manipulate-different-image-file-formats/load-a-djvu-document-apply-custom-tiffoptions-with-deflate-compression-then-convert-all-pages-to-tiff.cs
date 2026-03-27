using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = Path.Combine("Input", "sample.djvu");
        string outputPath = Path.Combine("Output", "sample.tif");

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load DjVu document
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Configure TIFF options with Deflate compression
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                tiffOptions.Compression = TiffCompressions.Deflate;
                // Export all pages
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save all pages to a multi-page TIFF file
                djvuImage.Save(outputPath, tiffOptions);
            }
        }
    }
}