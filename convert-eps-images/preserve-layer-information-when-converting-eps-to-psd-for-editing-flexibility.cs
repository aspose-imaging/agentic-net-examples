using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Prepare PSD save options
            PsdOptions psdOptions = new PsdOptions
            {
                // Use lossless compression
                CompressionMethod = CompressionMethod.RLE,
                // Preserve original color mode (assume RGB)
                ColorMode = ColorModes.Rgb,
                // Set vector rasterization options to retain vector data
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                },
                // Preserve layers by separating vector data into layers
                VectorizationOptions = new PsdVectorizationOptions
                {
                    VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                }
            };

            // Save as PSD preserving layers
            epsImage.Save(outputPath, psdOptions);
        }
    }
}