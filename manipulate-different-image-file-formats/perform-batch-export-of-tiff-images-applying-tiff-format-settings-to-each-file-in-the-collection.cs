using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class BatchTiffExport
{
    static void Main()
    {
        // Define input image files (any supported format) and output directory
        string[] inputFiles = new string[]
        {
            @"C:\Images\sample1.jpg",
            @"C:\Images\sample2.png",
            @"C:\Images\sample3.bmp"
        };

        string outputDirectory = @"C:\Images\ExportedTiff\";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Prepare common TIFF export options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            // Example settings – adjust as needed
            BitsPerSample = new ushort[] { 8, 8, 8 },                     // 8 bits per color component
            ByteOrder = TiffByteOrder.LittleEndian,                     // Little‑endian (Intel)
            Compression = TiffCompressions.Lzw,                         // LZW compression
            Photometric = TiffPhotometrics.Rgb,                         // RGB color model
            PlanarConfiguration = TiffPlanarConfigs.Contiguous,        // Single plane storage
            Predictor = TiffPredictor.Horizontal                        // Predictor for LZW
        };

        foreach (string inputPath in inputFiles)
        {
            // Derive output file name with .tif extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as TIFF using the predefined options
                image.Save(outputPath, tiffOptions);
            }
        }

        Console.WriteLine("Batch TIFF export completed.");
    }
}