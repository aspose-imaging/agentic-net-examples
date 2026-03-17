using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class TiffLosslessCompression
{
    static void Main()
    {
        // Input TIFF file path
        string inputPath = @"C:\Images\input.tif";

        // Output TIFF file path (compressed)
        string outputPath = @"C:\Images\output_compressed.tif";

        // Load the TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve the original saving options to preserve original settings (bit depth, etc.)
            TiffOptions saveOptions = (TiffOptions)tiffImage.GetOriginalOptions();

            // Set a lossless compression method (LZW)
            saveOptions.Compression = TiffCompressions.Lzw;

            // Optionally, enable a predictor for better LZW compression on continuous-tone images
            saveOptions.Predictor = TiffPredictor.Horizontal;

            // Save the image with the new compression while keeping the TIFF format
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}