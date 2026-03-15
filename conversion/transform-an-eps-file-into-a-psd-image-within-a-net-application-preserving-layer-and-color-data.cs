using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Psd.Enums;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input EPS file path (first argument) and output PSD file path (second argument)
            string inputPath = args.Length > 0 ? args[0] : "input.eps";
            string outputPath = args.Length > 1 ? args[1] : "output.psd";

            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Configure PSD saving options
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    // Use RLE compression for reasonable file size
                    psdOptions.CompressionMethod = CompressionMethod.RLE;

                    // Preserve original colors in RGB mode
                    psdOptions.ColorMode = ColorModes.Rgb;

                    // Set PSD version (6 is common)
                    psdOptions.Version = 6;

                    // Preserve vector layers by rasterizing with vector options
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Export vector data as separate layers in the PSD
                    psdOptions.VectorizationOptions = new PsdVectorizationOptions
                    {
                        VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                    };

                    // Save the EPS content as a PSD file preserving layers and colors
                    epsImage.Save(outputPath, psdOptions);
                }
            }
        }
    }
}