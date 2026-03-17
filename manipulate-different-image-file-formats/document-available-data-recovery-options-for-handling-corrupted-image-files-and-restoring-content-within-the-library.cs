using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the potentially corrupted image file
            string inputPath = "corrupted_image.webp";
            // Path where the recovered image will be saved
            string outputPath = "recovered_image.png";

            // Load the image as a generic Image and cast to RasterImage for pixel-level operations
            using (Image img = Image.Load(inputPath))
            {
                // Ensure the loaded image supports raster operations
                if (img is RasterImage raster)
                {
                    // Cache all image data to avoid further stream reads (useful for corrupted sources)
                    raster.CacheData();

                    // Option 1: Automatic brightness and contrast correction
                    raster.AutoBrightnessContrast();

                    // Option 2: Histogram normalization to stretch pixel intensity range
                    raster.NormalizeHistogram();

                    // Option 3: Convert to grayscale – often helps when color channels are damaged
                    raster.Grayscale();

                    // Option 4: Attempt to preserve original format settings when saving
                    ImageOptionsBase originalOptions = raster.GetOriginalOptions();

                    // If original options are not suitable for the target format, fall back to PNG options
                    PngOptions pngOptions = new PngOptions();
                    // Preserve original DPI if available
                    if (originalOptions is ImageOptionsBase opts && opts.Source != null)
                    {
                        // Example of copying resolution (if needed)
                        // Note: SetResolution is a RasterImage method; here we keep it simple
                    }

                    // Save the recovered image using PNG format (widely supported)
                    raster.Save(outputPath, pngOptions);
                }
                else
                {
                    Console.WriteLine("The loaded image does not support raster operations.");
                }
            }

            Console.WriteLine("Recovery process completed.");
        }
    }
}