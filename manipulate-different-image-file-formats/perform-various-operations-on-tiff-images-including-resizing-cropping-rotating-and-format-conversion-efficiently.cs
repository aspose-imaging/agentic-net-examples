using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.tif";
            string outputTiffPath = "output_resized_cropped_rotated.tif";
            string outputJpegPath = "output_converted.jpg";

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage for TIFF‑specific operations
                TiffImage tiff = (TiffImage)image;

                // Cache data for better performance
                if (!tiff.IsCached)
                    tiff.CacheData();

                // Resize to 800x600 pixels
                tiff.Resize(800, 600);

                // Crop a rectangle (x=100, y=100, width=400, height=300)
                var cropRect = new Rectangle(100, 100, 400, 300);
                tiff.Crop(cropRect);

                // Rotate 90 degrees clockwise
                tiff.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the processed image as TIFF with LZW compression
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Compression = TiffCompressions.Lzw;
                    tiffOptions.Photometric = TiffPhotometrics.Rgb;
                    tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                    tiff.Save(outputTiffPath, tiffOptions);
                }

                // Convert and save the same image as JPEG with quality 90
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Quality = 90;
                    tiff.Save(outputJpegPath, jpegOptions);
                }
            }
        }
    }
}