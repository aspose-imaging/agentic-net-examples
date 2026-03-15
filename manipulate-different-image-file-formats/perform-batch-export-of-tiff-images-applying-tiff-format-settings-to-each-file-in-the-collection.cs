using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class BatchTiffExport
{
    static void Main()
    {
        // Folder that contains source images (any supported format)
        string sourceFolder = @"C:\Images\Source";
        // Folder where the exported TIFF files will be saved
        string outputFolder = @"C:\Images\ExportedTiff";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputFolder);

        // Get all files in the source folder (you can filter by extension if needed)
        string[] files = Directory.GetFiles(sourceFolder);

        foreach (string inputPath in files)
        {
            // Build the output file name with .tif extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".tif");

            // Load the source image using the standard load rule
            using (Image image = Image.Load(inputPath))
            {
                // Create TIFF save options (default format)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Example of applying common TIFF settings
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };                     // 8 bits per color component
                tiffOptions.Compression = TiffCompressions.Lzw;                         // LZW compression
                tiffOptions.Photometric = TiffPhotometrics.Rgb;                         // RGB color model
                tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;        // Single plane
                tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;                    // Little‑endian (default)

                // Save the image as TIFF using the standard save rule
                image.Save(outputPath, tiffOptions);
            }
        }

        Console.WriteLine("Batch export completed.");
    }
}