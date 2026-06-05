using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                // Set up vector rasterization options for SVG
                var vectorOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // PNG options that use the vector rasterization options
                var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Rasterize SVG to a memory stream
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Aspose.Imaging.Image rasterImageContainer = Aspose.Imaging.Image.Load(ms))
                    {
                        var rasterImage = (Aspose.Imaging.RasterImage)rasterImageContainer;

                        // Define a 5x5 kernel: surrounding elements = 1, center = 5
                        double[,] kernel = new double[5, 5];
                        for (int y = 0; y < 5; y++)
                        {
                            for (int x = 0; x < 5; x++)
                            {
                                kernel[y, x] = 1.0;
                            }
                        }
                        kernel[2, 2] = 5.0; // central element

                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                        // Apply the custom convolution filter
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered image
                        rasterImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to sharpen the central details of a company logo stored as SVG before converting it to a high‑resolution PNG for marketing materials, they can use this custom 5×5 kernel where the center weight is five times the surrounding weights.
 * 2. When generating thumbnail previews of vector icons for a mobile app, applying the kernel during SVG rasterization enhances the focal point while keeping surrounding edges smooth, resulting in clearer PNG thumbnails.
 * 3. When preparing SVG diagrams for print, a developer can use the code to apply a custom convolution filter that emphasizes the main chart area, ensuring the printed PNG retains visual emphasis on the central data.
 * 4. When creating web‑ready graphics that require a subtle boost in contrast around the core element of an SVG illustration, the custom kernel applied during rasterization provides a controlled sharpening effect in the output PNG.
 * 5. When automating a batch process that converts SVG assets to PNG for a UI theme, incorporating the 5×5 kernel allows developers to consistently enhance central features across all images without manual editing.
 */