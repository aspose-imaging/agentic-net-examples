using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input SVG file path
            string inputPath = @"C:\Temp\input.svg";

            // Desired output format: "png", "jpeg", or "bmp"
            string outputFormat = "png";

            // Determine output file path based on format
            string outputPath = Path.ChangeExtension(inputPath, outputFormat);

            // Load the SVG image using unified Image.Load method
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage for vector-specific properties
                SvgImage svgImage = (SvgImage)image;

                // Configure rasterization options to preserve visual fidelity
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Use the original SVG size as the page size
                    PageSize = svgImage.Size,
                    // Set a white background (default is white)
                    BackgroundColor = Color.White,
                    // Enable anti-aliasing for smoother edges
                    SmoothingMode = SmoothingMode.AntiAlias,
                    // Render text with anti-aliasing
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Choose the appropriate raster format options
                if (outputFormat.Equals("png", StringComparison.OrdinalIgnoreCase))
                {
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.VectorRasterizationOptions = rasterOptions;
                        svgImage.Save(outputPath, pngOptions);
                    }
                }
                else if (outputFormat.Equals("jpeg", StringComparison.OrdinalIgnoreCase) ||
                         outputFormat.Equals("jpg", StringComparison.OrdinalIgnoreCase))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.VectorRasterizationOptions = rasterOptions;
                        // Optional: set quality (0-100)
                        jpegOptions.Quality = 90;
                        svgImage.Save(outputPath, jpegOptions);
                    }
                }
                else if (outputFormat.Equals("bmp", StringComparison.OrdinalIgnoreCase))
                {
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        bmpOptions.VectorRasterizationOptions = rasterOptions;
                        svgImage.Save(outputPath, bmpOptions);
                    }
                }
                else
                {
                    // Fallback to PNG if an unsupported format is requested
                    using (PngOptions fallbackOptions = new PngOptions())
                    {
                        fallbackOptions.VectorRasterizationOptions = rasterOptions;
                        svgImage.Save(outputPath, fallbackOptions);
                    }
                }
            }
        }
    }
}