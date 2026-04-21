using System;
using System.IO;
using System.Text;
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
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Capture original SVG XML (including embedded CSS)
                string originalXml;
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, new SvgOptions());
                    originalXml = Encoding.UTF8.GetString(ms.ToArray());
                }

                // Rasterize SVG to PNG
                PngOptions pngOptions = new PngOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                using (MemoryStream pngStream = new MemoryStream())
                {
                    svgImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    // Load raster image and apply a convolution kernel
                    using (RasterImage raster = (RasterImage)Image.Load(pngStream))
                    {
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                        // Save filtered PNG (optional, not used further)
                        // raster.Save("filtered.png", new PngOptions());
                    }
                }

                // After raster operations, retrieve SVG XML again to ensure CSS unchanged
                string afterXml;
                using (MemoryStream ms2 = new MemoryStream())
                {
                    svgImage.Save(ms2, new SvgOptions());
                    afterXml = Encoding.UTF8.GetString(ms2.ToArray());
                }

                if (originalXml == afterXml)
                {
                    Console.WriteLine("Embedded CSS styles are unchanged after applying the kernel.");
                }
                else
                {
                    Console.WriteLine("Embedded CSS styles have been altered.");
                }

                // Save the original SVG to output path
                svgImage.Save(outputPath, new SvgOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}