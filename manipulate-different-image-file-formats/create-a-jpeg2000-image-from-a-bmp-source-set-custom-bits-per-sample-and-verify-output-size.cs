using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\source.bmp";
            string outputPath = @"C:\Temp\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Cast to RasterImage for conversion
                RasterImage raster = bmpImage as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image from BMP.");
                    return;
                }

                // Create JPEG2000 image with custom bits per sample (e.g., 12 bits)
                int bitsPerSample = 12;
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(raster, bitsPerSample))
                {
                    // Save JPEG2000 image
                    jpeg2000Image.Save(outputPath);
                }
            }

            // Verify output file size
            FileInfo info = new FileInfo(outputPath);
            Console.WriteLine($"Output file size: {info.Length} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to archive legacy BMP artwork as high‑precision JPEG2000 files with 12‑bit depth for long‑term preservation while confirming the resulting file size.
 * 2. When a medical imaging application must convert diagnostic BMP scans to JPEG2000 with custom bits per sample to meet DICOM standards and verify the output size for storage budgeting.
 * 3. When a printing workflow requires transforming BMP source graphics into lossless JPEG2000 images with increased bit depth to retain color fidelity before sending files to a high‑resolution press.
 * 4. When a GIS system needs to re‑encode BMP elevation maps to JPEG2000 with 12‑bit samples for efficient tiling and must check the file size to ensure it fits within tile cache limits.
 * 5. When a digital asset management tool batch‑processes BMP assets into JPEG2000 with custom bits per sample and logs the output file size to monitor compression performance.
 */