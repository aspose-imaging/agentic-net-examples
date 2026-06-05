using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded paths
            string inputPath = @"c:\temp\input.webp";
            string bmpPath = @"c:\temp\intermediate.bmp";
            string tiffPath = @"c:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tiffPath));

            // Load WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Convert to BMP using BmpImage constructor (24‑bpp, RGB compression, 96 DPI)
                using (BmpImage bmpImage = new BmpImage(
                    webPImage,
                    24,
                    BitmapCompression.Rgb,
                    96.0,
                    96.0))
                {
                    // Save intermediate BMP file
                    bmpImage.Save(bmpPath);

                    // Prepare TIFF options with LZW compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Lzw,
                        BitsPerSample = new ushort[] { 8, 8, 8 },
                        ByteOrder = TiffByteOrder.BigEndian,
                        Photometric = TiffPhotometrics.Rgb,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous
                    };

                    // Save as TIFF using the same BMP image instance
                    bmpImage.Save(tiffPath, tiffOptions);
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
 * 1. When a developer needs to archive web‑optimized WebP graphics in a lossless, LZW‑compressed TIFF format for long‑term storage while preserving original colors, they can use this code to convert WebP to BMP and then to TIFF.
 * 2. When an application must generate print‑ready high‑resolution TIFF files from WebP assets for a publishing workflow, the code provides the C# conversion and LZW compression needed for print compatibility.
 * 3. When a GIS system requires raster layers originally supplied as WebP to be imported as BMP before being saved as LZW‑compressed TIFF for compatibility with legacy mapping software, this snippet handles the format chain.
 * 4. When a medical‑imaging platform needs to transform WebP scans into BMP for pixel‑accurate manipulation and then store them as LZW‑compressed TIFF to meet archival standards, the code performs the necessary steps.
 * 5. When a cloud‑based image‑processing service must accept WebP uploads, convert them to an intermediate BMP to normalize bit depth, and finally deliver LZW‑compressed TIFF files to clients who request non‑lossy formats, this C# example provides the solution.
 */