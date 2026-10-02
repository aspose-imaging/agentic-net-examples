// HOW-TO: Verify Pixel Intensity After Gaussian Blur on SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image svgImage = Image.Load(inputPath))
            {
                SvgImage svg = (SvgImage)svgImage;

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svg.Width,
                        PageHeight = svg.Height,
                        BackgroundColor = Color.White
                    }
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    svg.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions
                        {
                            Radius = 2,
                            Sigma = 1.0
                        };
                        raster.Filter(raster.Bounds, blurOptions);

                        int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                        int maxIntensity = 0;
                        foreach (int argb in pixels)
                        {
                            int r = (argb >> 16) & 0xFF;
                            int g = (argb >> 8) & 0xFF;
                            int b = argb & 0xFF;
                            int intensity = Math.Max(r, Math.Max(g, b));
                            if (intensity > maxIntensity)
                                maxIntensity = intensity;
                        }

                        Console.WriteLine($"Maximum pixel intensity after blur: {maxIntensity}");
                        if (maxIntensity > 255)
                            Console.WriteLine("Intensity exceeds 255!");
                        else
                            Console.WriteLine("Intensity within range.");

                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert an SVG logo to a PNG thumbnail, apply a Gaussian blur, and ensure the resulting pixel values stay within the 0‑255 range to avoid color distortion.
 * 2. When processing vector graphics for web assets, you may rasterize the SVG, blur it for a soft‑edge effect, and validate that no pixel intensity exceeds the maximum allowed value before publishing.
 * 3. When building an automated image pipeline that applies filters to SVG‑derived images, you can use this code to confirm that the Gaussian blur does not cause overflow errors in the final PNG.
 * 4. When creating printable graphics where a blur is required, you must verify that the blurred raster image respects the 8‑bit per channel limit to maintain color fidelity.
 * 5. When integrating Aspose.Imaging into a C# application for dynamic SVG manipulation, this example shows how to rasterize, blur, and programmatically check pixel intensity to prevent runtime exceptions.
 */
