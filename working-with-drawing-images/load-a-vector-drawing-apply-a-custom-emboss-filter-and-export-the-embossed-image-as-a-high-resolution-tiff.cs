// HOW-TO: Apply Custom Emboss Filter to SVG and Save as High‑Resolution TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output\\embossed.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(tiffOptions, width, height))
                {
                    raster.SetResolution(300, 300);

                    var graphics = new Aspose.Imaging.Graphics(raster);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(vectorImage, new Aspose.Imaging.Rectangle(0, 0, width, height));

                    double[,] customKernel = new double[,]
                    {
                        { -2, -1, 0 },
                        { -1, 1, 1 },
                        { 0, 1, 2 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert an SVG logo into a printable 300 dpi TIFF with an embossed effect for marketing brochures.
 * 2. When a desktop application must render vector diagrams as high‑resolution raster images for archival in TIFF format while applying a custom convolution filter.
 * 3. When generating embossed product labels from vector artwork for inclusion in a PDF catalog that requires TIFF images at 300 dpi.
 * 4. When automating the preparation of engineering drawings by adding depth via an emboss filter before saving them as lossless TIFF files for CAD documentation.
 * 5. When a web service processes user‑uploaded SVG files, applies a stylized emboss effect, and returns a high‑quality TIFF for downstream image‑processing pipelines.
 */
