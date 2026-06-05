using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.dng";
            string outputPath = @"C:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access raw data
                DngImage dngImage = (DngImage)image;

                // Prepare TIFF options for 16‑bit per channel output
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 16, 16, 16 }, // 16 bits for R, G, B
                    Photometric = TiffPhotometrics.Rgb,
                    Compression = TiffCompressions.None,
                    ByteOrder = TiffByteOrder.LittleEndian,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save as TIFF preserving raw sensor data
                dngImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# developer must archive camera‑raw DNG files as lossless 16‑bit per channel TIFF images using Aspose.Imaging to preserve the original sensor data for future editing.
 * 2. When a scientific imaging application needs to convert raw DNG captures to uncompressed 16‑bit TIFFs in order to perform precise pixel‑level analysis without losing any sensor information.
 * 3. When a digital asset management system requires batch processing of DNG photos into TIFF format with exact color depth and metadata retention, leveraging Aspose.Imaging’s Image.Load and TiffOptions in .NET.
 * 4. When a printing workflow demands high‑resolution 16‑bit TIFF files generated from raw DNG sources to ensure maximum tonal range and color fidelity before raster image processing.
 * 5. When a developer builds a cross‑platform C# tool that extracts raw sensor data from DNG files and saves it as a contiguous, uncompressed 16‑bit TIFF for archival or downstream image‑processing pipelines.
 */