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
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\output.tif";

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
            // Prepare TIFF saving options (common for all pages)
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Compression = TiffCompressions.Lzw,
                Photometric = TiffPhotometrics.Rgb,
                PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                ByteOrder = TiffByteOrder.LittleEndian
            };

            // Save each DjVu page as an individual TIFF file
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Build a distinct file name for each page
                string pageOutput = Path.Combine(
                    Path.GetDirectoryName(outputPath),
                    $"{Path.GetFileNameWithoutExtension(outputPath)}_page{page.PageNumber}.tif");

                // Save the page using the prepared TIFF options
                page.Save(pageOutput, tiffOptions);
            }
        }
    }
}