using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;   // Example for TIFF, replace with appropriate namespace for other formats

class ImageProcessor
{
    /// <summary>
    /// Adjusts brightness, contrast and gamma of an image and saves the result.
    /// </summary>
    /// <param name="inputPath">Path to the source image file.</param>
    /// <param name="outputPath">Path where the processed image will be saved.</param>
    /// <param name="brightness">Brightness offset (int). Positive values increase brightness, negative decrease.</param>
    /// <param name="contrast">Contrast factor (float). 1.0f leaves contrast unchanged.</param>
    /// <param name="gamma">Gamma correction factor (float). 1.0f leaves gamma unchanged.</param>
    public static void AdjustImage(string inputPath, string outputPath, int brightness, float contrast, float gamma)
    {
        // Load the image from file. Aspose.Imaging supports many formats; the returned object derives from RasterImage.
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access adjustment methods.
            // All raster image types (e.g., TiffImage, GifImage, DicomImage, etc.) inherit these methods.
            var raster = (RasterImage)image;

            // Adjust brightness.
            // AdjustBrightness expects an integer value; typical range is -255 to +255.
            raster.AdjustBrightness(brightness);

            // Adjust contrast.
            // AdjustContrast expects a floating‑point multiplier; 1.0f means no change.
            raster.AdjustContrast(contrast);

            // Adjust gamma.
            // AdjustGamma expects a floating‑point gamma value; 1.0f means no change.
            raster.AdjustGamma(gamma);

            // Save the modified image to the desired location.
            // The overload Save(string) automatically determines the format from the file extension.
            raster.Save(outputPath);
        }
    }

    // Example usage.
    static void Main()
    {
        string sourceFile = @"C:\Images\sample.tif";
        string destinationFile = @"C:\Images\sample_adjusted.tif";

        int brightness = 30;          // increase brightness
        float contrast = 1.2f;        // increase contrast by 20%
        float gamma = 0.9f;           // slightly darken via gamma correction

        AdjustImage(sourceFile, destinationFile, brightness, contrast, gamma);

        Console.WriteLine("Image processing completed.");
    }
}