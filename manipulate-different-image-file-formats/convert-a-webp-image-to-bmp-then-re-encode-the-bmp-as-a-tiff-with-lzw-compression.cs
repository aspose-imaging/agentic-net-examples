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
        // Hardcoded paths
        string inputWebPPath = "input.webp";
        string outputBmpPath = "output.bmp";
        string outputTiffPath = "output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputWebPPath))
            {
                Console.Error.WriteLine($"File not found: {inputWebPPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // Load WebP image
            using (WebPImage webPImage = new WebPImage(inputWebPPath))
            {
                // Convert to BMP (24‑bpp, RGB compression, 96 DPI)
                using (BmpImage bmpImage = new BmpImage(
                    webPImage,
                    24,
                    BitmapCompression.Rgb,
                    96.0,
                    96.0))
                {
                    // Save BMP file
                    bmpImage.Save(outputBmpPath);

                    // Prepare TIFF options with LZW compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Lzw,
                        BitsPerSample = new ushort[] { 8, 8, 8 },
                        ByteOrder = TiffByteOrder.BigEndian,
                        Photometric = TiffPhotometrics.Rgb,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous
                    };

                    // Save as TIFF using the same image data
                    bmpImage.Save(outputTiffPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}