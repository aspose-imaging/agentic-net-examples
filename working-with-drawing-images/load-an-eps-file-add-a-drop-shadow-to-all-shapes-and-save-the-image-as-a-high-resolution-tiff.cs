// HOW-TO: Add Drop Shadow to EPS and Save as High‑Resolution TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var eps = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = eps.Width * 4,
                    PageHeight = eps.Height * 4
                };

                using (var ms = new MemoryStream())
                {
                    eps.Save(ms, new PngOptions { VectorRasterizationOptions = rasterOptions });
                    ms.Position = 0;

                    using (var raster = (RasterImage)Image.Load(ms))
                    {
                        int offsetX = 10;
                        int offsetY = 10;
                        int canvasWidth = raster.Width + offsetX;
                        int canvasHeight = raster.Height + offsetY;

                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        tiffOptions.Source = new FileCreateSource(outputPath, false);

                        using (var canvas = Image.Create(tiffOptions, canvasWidth, canvasHeight))
                        {
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Color.White);
                            graphics.DrawImage(raster, offsetX, offsetY); // shadow
                            graphics.DrawImage(raster, 0, 0); // original
                            canvas.Save();
                        }
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
 * 1. When you need to convert vector EPS artwork into a printable high‑resolution TIFF while adding a drop shadow for visual depth.
 * 2. When a publishing workflow requires embedding EPS logos into TIFF pages with a consistent offset shadow to match page layout guidelines.
 * 3. When generating product catalogs that combine vector graphics with raster images, and you must output a TIFF file with enhanced shadow effects for better presentation.
 * 4. When automating batch processing of EPS files to create TIFF assets for archival, and you want each image to include a subtle shadow without manual editing.
 * 5. When integrating Aspose.Imaging into a C# application to rasterize EPS files at 4× resolution, add a shadow, and save the result as a TIFF for downstream printing or imaging systems.
 */
