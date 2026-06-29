using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\input.cdr";
            string outputPath = @"C:\Data\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image (do not resize, use white background)
                image.NormalizeAngle(false, Color.White);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.LittleEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save the deskewed image as TIFF
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
 * 1. When a printing service receives scanned CorelDRAW (CDR) files that are slightly rotated and must be deskewed before converting them to high‑resolution TIFF for archival or print production.
 * 2. When an e‑document management system automatically straightens uploaded CDR drawings and stores them as compressed LZW‑TIFF files for fast retrieval and compatibility with legacy viewers.
 * 3. When a batch‑processing tool processes a folder of CDR artwork, removes scan‑induced skew, and saves each image as an RGB TIFF for downstream OCR or analysis.
 * 4. When a legal or compliance workflow requires CorelDRAW diagrams to be converted to non‑editable TIFF images with a consistent orientation and white background to meet document‑preservation standards.
 * 5. When a cloud‑based API receives user‑submitted CDR files, applies angle normalization using Aspose.Imaging, and returns a TIFF file that can be displayed in browsers or printed without distortion.
 */