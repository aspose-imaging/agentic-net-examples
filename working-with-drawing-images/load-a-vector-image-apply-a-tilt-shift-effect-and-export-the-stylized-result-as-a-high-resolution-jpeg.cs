using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                // Set up rasterization options for high‑resolution output
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Rasterize SVG to PNG in memory
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        int width = raster.Width;
                        int height = raster.Height;
                        int blurHeight = height / 5; // 20% of image height

                        // Apply Gaussian blur to top region
                        Rectangle topRect = new Rectangle(0, 0, width, blurHeight);
                        raster.Filter(topRect, new GaussianBlurFilterOptions(5, 4.0));

                        // Apply Gaussian blur to bottom region
                        Rectangle bottomRect = new Rectangle(0, height - blurHeight, width, blurHeight);
                        raster.Filter(bottomRect, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the result as high‑quality JPEG
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 95
                        };

                        raster.Save(outputPath, jpegOptions);
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