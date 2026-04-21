using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream svgStream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(svgStream))
            {
                // Set up rasterization options for SVG to PNG conversion
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream pngStream = new MemoryStream())
                {
                    // Rasterize SVG into PNG stored in memory
                    svgImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    using (Image pngImage = Image.Load(pngStream))
                    {
                        RasterImage raster = (RasterImage)pngImage;

                        // Custom diagonal edge‑detection kernel
                        double[,] kernel = new double[,]
                        {
                            { -2, -1, 0 },
                            { -1,  0, 1 },
                            {  0,  1, 2 }
                        };
                        var convOptions = new ConvolutionFilterOptions(kernel);

                        // Apply the convolution filter to the entire image
                        raster.Filter(raster.Bounds, convOptions);

                        // Save the filtered image
                        raster.Save(outputPath);
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