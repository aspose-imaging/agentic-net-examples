using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace MetafileProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input EMF file path
            string inputPath = Path.Combine("C:", "Metafiles", "sample.emf");
            // Output PNG file path
            string outputPath = Path.Combine("C:", "Metafiles", "sample_converted.png");

            // Load EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization options
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Set PNG options with vector rasterization
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = vectorOptions;
                    // Save as PNG
                    image.Save(outputPath, pngOptions);
                }
            }
        }
    }
}