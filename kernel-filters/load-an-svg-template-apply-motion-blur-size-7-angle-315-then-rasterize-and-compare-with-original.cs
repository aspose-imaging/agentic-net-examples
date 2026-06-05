using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputSvgPath = "input.svg";
            string originalPngPath = "original.png";
            string blurredPngPath = "blurred.png";

            // Verify input file exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(blurredPngPath));

            // Load SVG image and rasterize to original PNG
            using (Image image = Image.Load(inputSvgPath))
            {
                SvgImage svgImage = (SvgImage)image;

                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(originalPngPath, pngOptions);
            }

            // Load the rasterized original PNG as RasterImage and apply motion blur
            using (Image img = Image.Load(originalPngPath))
            {
                RasterImage rasterImage = (RasterImage)img;

                double[,] kernel = ConvolutionFilter.GetBlurMotion(7, 315.0);
                var motionBlurOptions = new ConvolutionFilterOptions(kernel);

                rasterImage.Filter(rasterImage.Bounds, motionBlurOptions);
                rasterImage.Save(blurredPngPath);
            }

            // Compare original and blurred images (pixel difference count)
            using (Image origImg = Image.Load(originalPngPath))
            using (Image blurImg = Image.Load(blurredPngPath))
            {
                RasterImage origRaster = (RasterImage)origImg;
                RasterImage blurRaster = (RasterImage)blurImg;

                if (origRaster.Width != blurRaster.Width || origRaster.Height != blurRaster.Height)
                {
                    Console.WriteLine("Images have different dimensions.");
                }
                else
                {
                    int diffCount = 0;
                    for (int y = 0; y < origRaster.Height; y++)
                    {
                        for (int x = 0; x < origRaster.Width; x++)
                        {
                            Color origPixel = origRaster.GetPixel(x, y);
                            Color blurPixel = blurRaster.GetPixel(x, y);
                            if (!origPixel.Equals(blurPixel))
                                diffCount++;
                        }
                    }
                    Console.WriteLine($"Pixel differences between original and blurred: {diffCount}");
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
 * 1. When a developer needs to generate a blurred preview of a vector logo for a web thumbnail, they can load the SVG template, rasterize it to PNG, apply a motion blur of size 7 at 315°, and compare the result with the original PNG.
 * 2. When an e‑commerce platform wants to create a dynamic “sale” effect on product illustrations, the code can convert the SVG artwork to a raster image, add a motion blur filter, and verify visual fidelity against the unblurred PNG.
 * 3. When a reporting tool must embed a stylized, motion‑blurred version of a chart exported as SVG into a PDF, the snippet rasterizes the SVG, applies the blur, and checks that the blurred PNG matches the original dimensions.
 * 4. When a game developer wants to pre‑process SVG assets into motion‑blurred sprites for a fast‑moving background, they can use this routine to rasterize the SVG, apply a 7‑pixel blur at a 315° angle, and compare the output PNG to the source for quality control.
 * 5. When an automated testing suite validates that an SVG‑to‑PNG conversion pipeline preserves image size while allowing optional blur effects, the code loads the SVG, rasterizes it, applies the motion blur, and programmatically compares the blurred PNG with the original rasterized PNG.
 */