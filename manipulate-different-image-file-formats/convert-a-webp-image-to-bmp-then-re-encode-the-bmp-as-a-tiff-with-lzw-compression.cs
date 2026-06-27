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
            // Hardcoded paths
            string inputWebP = @"c:\temp\input.webp";
            string bmpPath = @"c:\temp\intermediate.bmp";
            string tiffPath = @"c:\temp\output.tif";

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
            using (WebPImage webPImage = new WebPImage(inputWebP))
            {
                // Convert to BMP using BmpImage constructor (raster image, 24‑bpp, RGB compression, 96 DPI)
                using (BmpImage bmpImage = new BmpImage(
                    (RasterImage)webPImage,
                    24,
                    Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb,
                    96.0,
                    96.0))
                {
                    // Save BMP to intermediate file
                    bmpImage.Save(bmpPath);
                }
            }

            // Load the BMP we just saved
            using (BmpImage bmpImage = (BmpImage)Image.Load(bmpPath))
            {
                // Prepare TIFF save options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.BigEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save as TIFF with LZW compression
                bmpImage.Save(tiffPath, tiffOptions);
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
 * 1. When a developer needs to archive web‑optimized images in a lossless, widely supported format for long‑term storage, they can convert WebP to BMP and then to LZW‑compressed TIFF using Aspose.Imaging for .NET.
 * 2. When integrating a legacy printing system that only accepts BMP or TIFF files, a developer can use this code to transform incoming WebP assets into BMP and finally into a TIFF with LZW compression for efficient print rendering.
 * 3. When preparing high‑resolution product photos for an e‑commerce catalog that requires TIFF files with lossless compression, developers can convert the original WebP images to BMP and then re‑encode them as LZW‑compressed TIFFs.
 * 4. When migrating a digital asset management repository that stores images as TIFF for compliance, developers can automate the conversion of stored WebP files to BMP and then to LZW‑compressed TIFF to meet the repository’s format standards.
 * 5. When building a medical imaging workflow that demands lossless TIFF files for diagnostic analysis, a developer can use this code to turn WebP scans into BMP and subsequently into LZW‑compressed TIFFs for accurate image preservation.
 */