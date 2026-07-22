using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.tif";
        string outputPath = @"C:\Images\compressed.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for JPEG compression with 80% quality
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Jpeg,
                    CompressedQuality = 80,
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Save the image with the specified options
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
 * 1. When a medical imaging system needs to archive high‑resolution scans as TIFF files while reducing storage costs, a developer can use this code to apply JPEG compression at 80 % quality.
 * 2. When a publishing workflow must generate web‑ready preview images from large TIFF master files, the code enables conversion to a smaller TIFF with JPEG compression to speed up page loads.
 * 3. When an e‑commerce platform stores product photographs in TIFF for lossless editing but wants to send compressed versions to a CDN, the developer can compress the TIFF to 80 % JPEG quality before upload.
 * 4. When a document management solution imports scanned documents as TIFF and must keep file size under a limit for email attachment, this code provides a way to compress each image while preserving RGB color.
 * 5. When a GIS application exports satellite imagery as TIFF and needs to balance visual fidelity with disk usage, the developer can use the snippet to apply JPEG compression with a configurable quality factor of 80 %.
 */