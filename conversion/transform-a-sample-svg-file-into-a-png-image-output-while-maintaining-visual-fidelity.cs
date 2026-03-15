using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path and output PNG file path
        string inputPath = Path.Combine("c:", "temp", "sample.svg");
        string outputPath = Path.Combine("c:", "temp", "sample.png");

        // Load the SVG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for SVG to preserve visual fidelity
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Use the original SVG size as the page size
                PageSize = image.Size,
                // Set a white background (optional, depends on SVG content)
                BackgroundColor = Color.White,
                // Enable anti-aliasing for smoother lines and curves
                SmoothingMode = SmoothingMode.AntiAlias,
                // Render text with anti-aliasing
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Configure PNG export options and attach the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}