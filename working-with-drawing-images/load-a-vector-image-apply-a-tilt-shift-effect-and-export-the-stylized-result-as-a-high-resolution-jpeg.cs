using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Configure rasterization options for high resolution
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias,
                ScaleX = 2.0f, // increase resolution
                ScaleY = 2.0f
            };

            // PNG options to rasterize the SVG into a memory stream
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to PNG in memory
            using (var pngStream = new MemoryStream())
            {
                svgImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImageBase = Image.Load(pngStream))
                {
                    var rasterImage = (RasterImage)rasterImageBase;

                    // Create a blurred copy of the raster image
                    using (var blurredStream = new MemoryStream())
                    {
                        // Save original raster to a new stream for cloning
                        rasterImage.Save(blurredStream, pngOptions);
                        blurredStream.Position = 0;

                        using (Image blurredBase = Image.Load(blurredStream))
                        {
                            var blurredRaster = (RasterImage)blurredBase;

                            // Apply Gaussian blur to the copy (simulating tilt‑shift)
                            blurredRaster.Filter(
                                blurredRaster.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(15, 5.0));

                            // Blend the original (sharp) image over the blurred one
                            // 128 = 50% opacity for the blurred layer
                            rasterImage.Blend(new Point(0, 0), blurredRaster, 128);
                        }
                    }

                    // Prepare high‑quality JPEG options
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 95,
                        VectorRasterizationOptions = rasterOptions // retain high‑res rasterization
                    };

                    // Save the final image as JPEG
                    rasterImage.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}