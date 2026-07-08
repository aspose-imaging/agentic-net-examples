using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\photo.dng";
            string outputPath = "Output\\photo.jp2";

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
                DngImage dng = (DngImage)image;
                // Ensure demosaicing (use processed data)
                dng.UseRawData = false;

                // Cast to RasterImage for conversion
                RasterImage raster = dng;

                // Create JPEG2000 image from raster
                using (Jpeg2000Image jpeg2000 = new Jpeg2000Image(raster))
                {
                    // Configure lossless JPEG2000 options
                    using (Jpeg2000Options options = new Jpeg2000Options())
                    {
                        options.Irreversible = false; // lossless compression
                        jpeg2000.Save(outputPath, options);
                    }
                }
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
 * 1. When a photography app needs to convert raw DNG files captured by a DSLR into lossless JPEG2000 for archival storage while preserving color fidelity through demosaicing.
 * 2. When a medical imaging system must ingest DNG raw scans, apply demosaic processing, and export them as JPEG2000 to meet DICOM lossless compression requirements.
 * 3. When an e‑commerce platform wants to generate high‑quality, lossless preview images from vendor‑provided DNG product photos for use in zoomable galleries.
 * 4. When a scientific research tool requires batch conversion of raw DNG microscope images to JPEG2000 with lossless compression to enable efficient data sharing without quality loss.
 * 5. When a digital asset management solution needs to ingest raw DNG camera files, perform demosaicing, and store them as JPEG2000 files to reduce storage size while keeping the original image data intact.
 */