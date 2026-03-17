using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string inputPath = @"C:\Images\input.jpg";

        // Desired output PSD file path
        string outputPath = @"C:\Images\output.psd";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD saving options to preserve fidelity
            PsdOptions psdOptions = new PsdOptions
            {
                // Use RAW compression (no compression) to keep original pixel data
                CompressionMethod = CompressionMethod.Raw,

                // Preserve the original color mode when possible; default to RGB
                ColorMode = ColorModes.Rgb,

                // Standard 8 bits per channel
                ChannelBitsCount = 8,

                // Set channel count based on presence of alpha channel
                ChannelsCount = (short)((image is RasterImage raster && raster.HasAlpha) ? 4 : 3),

                // Keep original metadata (EXIF, XMP, etc.)
                KeepMetadata = true
            };

            // Save the image as a PSD file using the configured options
            image.Save(outputPath, psdOptions);
        }
    }
}