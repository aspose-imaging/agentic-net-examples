using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Define input CDR file and output PSD file paths
        string inputPath = "input.cdr";
        string outputPath = "output.psd";

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD saving options
            using (PsdOptions psdOptions = new PsdOptions())
            {
                // Set desired compression and color mode
                psdOptions.CompressionMethod = CompressionMethod.RLE;
                psdOptions.ColorMode = ColorModes.Rgb;

                // Obtain vector rasterization options for the source vector image
                psdOptions.VectorRasterizationOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                    new object[] { Color.White, image.Width, image.Height });

                // Optimize rendering settings
                psdOptions.VectorRasterizationOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                psdOptions.VectorRasterizationOptions.SmoothingMode = SmoothingMode.None;

                // Save the image as PSD
                image.Save(outputPath, psdOptions);
            }
        }
    }
}