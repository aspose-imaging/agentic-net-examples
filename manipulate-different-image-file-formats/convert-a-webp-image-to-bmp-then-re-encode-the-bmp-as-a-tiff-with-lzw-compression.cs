// HOW-TO: Convert WebP Image to BMP and Then to LZW‑Compressed TIFF in C# (Aspose.Imaging for .NET)
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
            string inputWebP = @"C:\temp\input.webp";
            string bmpPath   = @"C:\temp\intermediate.bmp";
            string tiffPath  = @"C:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputWebP))
            {
                Console.Error.WriteLine($"File not found: {inputWebP}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tiffPath));

            // Load WebP image
            using (WebPImage webP = new WebPImage(inputWebP))
            {
                // Convert to BMP (24‑bpp, RGB compression)
                using (BmpImage bmp = new BmpImage(webP, 24, BitmapCompression.Rgb, 96.0, 96.0))
                {
                    // Save intermediate BMP file
                    bmp.Save(bmpPath);
                }
            }

            // Load the BMP we just saved
            using (Image bmpLoaded = Image.Load(bmpPath))
            {
                // Prepare TIFF options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save as TIFF
                bmpLoaded.Save(tiffPath, tiffOptions);
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
 * 1. When you need to archive web‑optimized WebP photos in a lossless TIFF format for long‑term storage or compliance, this code converts them through BMP and applies LZW compression.
 * 2. When a printing workflow only accepts BMP or TIFF files, you can use this snippet to transform incoming WebP assets into a BMP intermediate and finally into a printer‑ready LZW‑compressed TIFF.
 * 3. When migrating a legacy system that stores images as BMP but now requires compact TIFF files, the example shows how to read a WebP, save a BMP, and re‑encode it as a smaller TIFF with LZW.
 * 4. When creating a document‑generation pipeline that embeds high‑quality images, you can convert WebP graphics to BMP for pixel‑perfect handling and then to TIFF to embed with lossless compression.
 * 5. When developing a cross‑platform image‑processing service that receives WebP uploads and must deliver TIFF files compatible with GIS or medical imaging tools, this code provides the necessary conversion steps.
 */
