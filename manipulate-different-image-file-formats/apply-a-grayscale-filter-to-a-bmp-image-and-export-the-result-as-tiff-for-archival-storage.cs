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
        // Hardcoded paths
        string inputPath = @"C:\temp\input.bmp";
        string tempTiffPath = @"C:\temp\temp.tif";
        string outputPath = @"C:\temp\output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempTiffPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image bmpImage = Image.Load(inputPath))
            {
                // Save BMP as temporary TIFF
                var tiffSaveOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    Photometric = TiffPhotometrics.Rgb,
                    Compression = TiffCompressions.Lzw,
                    Predictor = TiffPredictor.Horizontal,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                    ByteOrder = TiffByteOrder.LittleEndian
                };

                bmpImage.Save(tempTiffPath, tiffSaveOptions);
            }

            // Load the temporary TIFF, apply grayscale, and save final TIFF
            using (Image tiffBase = Image.Load(tempTiffPath))
            {
                var tiffImage = (TiffImage)tiffBase;
                tiffImage.Grayscale();
                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to convert legacy BMP scans of engineering drawings into LZW‑compressed grayscale TIFF files for long‑term archival in a document management system.
 * 2. When an application must ingest user‑uploaded BMP photos, apply a grayscale filter, and store them as TIFFs to meet regulatory requirements for medical imaging records.
 * 3. When a batch‑processing service has to transform color BMP assets from a legacy database into grayscale TIFFs for inclusion in a searchable digital library that only supports TIFF format.
 * 4. When a developer is building a backup utility that preserves original BMP graphics by converting them to lossless grayscale TIFFs with LZW compression to save disk space while maintaining image fidelity.
 * 5. When a workflow automates the preparation of BMP‑based product labels for printing, applying a grayscale conversion and exporting to TIFF to ensure consistent rendering across different printing pipelines.
 */