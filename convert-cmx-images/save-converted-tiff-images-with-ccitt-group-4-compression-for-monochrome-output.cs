using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for CCITT Group 4 compression (monochrome)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    // 1 bit per pixel
                    BitsPerSample = new ushort[] { 1 },

                    // Black is 0, white is 1
                    Photometric = TiffPhotometrics.MinIsBlack,

                    // CCITT Group 4 compression
                    Compression = TiffCompressions.CcittFax4
                };

                // Save the image as a monochrome TIFF with the specified options
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
 * 1. When a developer needs to convert scanned PNG documents to monochrome TIFF files with CCITT Group 4 compression for long‑term legal archiving using C# and Aspose.Imaging.
 * 2. When a medical imaging application must export X‑ray images as 1‑bit per pixel TIFFs to meet DICOM storage requirements while minimizing file size.
 * 3. When a document management system requires batch conversion of color PNGs to black‑and‑white TIFFs with MinIsBlack photometric settings for OCR preprocessing.
 * 4. When a printing workflow needs to generate high‑resolution, low‑bandwidth TIFF files for fax transmission by applying CCITT Fax 4 compression in a .NET service.
 * 5. When a GIS tool must store raster map overlays as compact monochrome TIFF layers, using Aspose.Imaging to set BitsPerSample = 1 and ensure compatibility with legacy GIS software.
 */