using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Read original viewBox attribute
            string originalContent = File.ReadAllText(inputPath);
            string originalViewBox = "";
            int vbStart = originalContent.IndexOf("viewBox=\"");
            if (vbStart >= 0)
            {
                int vbEnd = originalContent.IndexOf("\"", vbStart + 9);
                if (vbEnd > vbStart)
                {
                    originalViewBox = originalContent.Substring(vbStart + 9, vbEnd - (vbStart + 9));
                }
            }

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Rasterize SVG to PNG in memory
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = rasterOptions;
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Apply Emboss3x3 filter
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                        // (Filtered raster is not saved back to SVG; viewBox should remain unchanged)
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save SVG (unchanged)
                svgImage.Save(outputPath);
            }

            // Read saved viewBox attribute
            string savedContent = File.ReadAllText(outputPath);
            string savedViewBox = "";
            int svbStart = savedContent.IndexOf("viewBox=\"");
            if (svbStart >= 0)
            {
                int svbEnd = savedContent.IndexOf("\"", svbStart + 9);
                if (svbEnd > svbStart)
                {
                    savedViewBox = savedContent.Substring(svbStart + 9, svbEnd - (svbStart + 9));
                }
            }

            if (originalViewBox != savedViewBox)
            {
                Console.Error.WriteLine("ViewBox changed after applying Emboss3x3 filter.");
            }
            else
            {
                Console.WriteLine("ViewBox unchanged after applying Emboss3x3 filter.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}