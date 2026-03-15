using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file
        string inputPngPath = "input.png";

        // Output paths
        string croppedResizedPngPath = "output_cropped_resized.png";
        string convertedJpegPath = "output_converted.jpg";
        string convertedTiffPath = "output_converted.tif";

        // -----------------------------------------------------------------
        // 1. Load PNG, crop, resize, and save as PNG (lossless)
        // -----------------------------------------------------------------
        using (RasterImage pngImage = (RasterImage)Image.Load(inputPngPath))
        {
            // Ensure image data is cached for better performance
            if (!pngImage.IsCached)
                pngImage.CacheData();

            // Define crop rectangle (example values)
            Rectangle cropRect = new Rectangle(50, 50, 200, 200);
            pngImage.Crop(cropRect);

            // Resize to desired dimensions
            pngImage.Resize(100, 100); // Uses default NearestNeighbourResample

            // Save with PNG options (compression level set to maximum)
            PngOptions pngSaveOptions = new PngOptions
            {
                CompressionLevel = 9 // 0 (fastest) to 9 (smallest size)
            };
            pngImage.Save(croppedResizedPngPath, pngSaveOptions);
        }

        // -----------------------------------------------------------------
        // 2. Convert original PNG to JPEG (high quality) and TIFF
        // -----------------------------------------------------------------
        using (Image originalImage = Image.Load(inputPngPath))
        {
            // JPEG conversion with maximum quality (lossless as far as JPEG allows)
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 100
            };
            originalImage.Save(convertedJpegPath, jpegOptions);

            // TIFF conversion (TIFF is lossless by default)
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            originalImage.Save(convertedTiffPath, tiffOptions);
        }
    }
}