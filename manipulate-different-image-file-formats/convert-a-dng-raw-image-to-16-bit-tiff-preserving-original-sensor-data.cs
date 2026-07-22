using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\input.dng";
            string outputPath = "c:\\temp\\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to enable raw data handling
                if (image is DngImage dngImage)
                {
                    // Preserve original sensor data
                    dngImage.UseRawData = true;
                }

                // Configure TIFF options for 16‑bit per channel
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 16, 16, 16 }, // 16‑bit for R, G, B
                    Compression = TiffCompressions.None,
                    Photometric = TiffPhotometrics.Rgb,
                    ByteOrder = TiffByteOrder.LittleEndian,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save as 16‑bit TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When a photography studio needs to archive raw DNG files as loss‑less 16‑bit TIFFs for long‑term preservation while keeping the original sensor data intact.
 * 2. When a scientific imaging application must ingest raw camera data and convert it to a 16‑bit TIFF format for accurate quantitative analysis in C#.
 * 3. When a print shop receives DNG images from clients and must generate high‑resolution 16‑bit TIFF files without compression for color‑critical large‑format printing.
 * 4. When a machine‑learning pipeline requires raw pixel values from DNG files, and the developer uses this code to produce 16‑bit TIFFs that preserve the sensor’s linear data for training models.
 * 5. When a digital asset management system needs to create searchable, standards‑compliant TIFF previews from DNG raw files while maintaining the full bit depth for downstream editing tools.
 */