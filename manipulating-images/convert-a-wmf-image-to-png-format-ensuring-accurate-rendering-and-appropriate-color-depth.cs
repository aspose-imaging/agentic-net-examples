using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ConvertWmfToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input WMF file path (default if not provided)
            string inputPath = args.Length > 0 ? args[0] : "input.wmf";
            // Output PNG file path (default if not provided)
            string outputPath = args.Length > 1 ? args[1] : "output.png";

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for WMF rendering
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Configure PNG export options, including color depth
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    BitDepth = 8 // 8 bits per channel (24‑bit color)
                };

                // Save the rendered image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
    }
}