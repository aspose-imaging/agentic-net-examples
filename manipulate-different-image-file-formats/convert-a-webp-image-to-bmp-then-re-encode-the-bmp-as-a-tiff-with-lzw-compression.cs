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
            string inputWebPPath = @"c:\temp\input.webp";
            string intermediateBmpPath = @"c:\temp\intermediate.bmp";
            string outputTiffPath = @"c:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputWebPPath))
            {
                Console.Error.WriteLine($"File not found: {inputWebPPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediateBmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // Load WebP image
            using (WebPImage webPImage = new WebPImage(inputWebPPath))
            {
                // Convert to BMP using the BmpImage constructor that accepts a RasterImage
                using (BmpImage bmpImage = new BmpImage(
                    webPImage,                     // source raster image
                    24,                            // bits per pixel
                    Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb,
                    96.0,                          // horizontal DPI
                    96.0))                         // vertical DPI
                {
                    // Save intermediate BMP file
                    bmpImage.Save(intermediateBmpPath);
                }
            }

            // Load the BMP we just saved
            using (BmpImage bmpLoaded = (BmpImage)Image.Load(intermediateBmpPath))
            {
                // Prepare TIFF options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.BigEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save as TIFF using the configured options
                bmpLoaded.Save(outputTiffPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}