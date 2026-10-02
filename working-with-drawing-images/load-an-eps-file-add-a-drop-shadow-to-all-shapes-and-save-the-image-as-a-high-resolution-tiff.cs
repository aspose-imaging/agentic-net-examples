// HOW-TO: Add Drop Shadow to EPS Shapes and Save as High-Resolution TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = Image.Load(inputPath))
            {
                string tempPng = Path.Combine(Path.GetTempPath(), "temp_eps.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPng));

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = 2000,
                        PageHeight = 2000,
                        BackgroundColor = Color.White
                    }
                };
                epsImage.Save(tempPng, pngOptions);

                using (var raster = (RasterImage)Image.Load(tempPng))
                {
                    int shadowOffset = 10;
                    int canvasWidth = raster.Width + shadowOffset;
                    int canvasHeight = raster.Height + shadowOffset;

                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24,
                        Source = new FileCreateSource(Path.Combine(Path.GetTempPath(), "canvas.bmp"), false)
                    };

                    using (var canvas = (RasterImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
                    {
                        Graphics graphics = new Graphics(canvas);
                        using (var shadowBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0)))
                        {
                            graphics.FillRectangle(shadowBrush, 0, 0, raster.Width, raster.Height);
                        }
                        graphics.DrawImage(raster, shadowOffset, shadowOffset);

                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        canvas.Save(outputPath, tiffOptions);
                    }
                }

                try { File.Delete(tempPng); } catch { }
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
 * 1. When a printing service needs to convert vector EPS artwork into a high‑resolution TIFF with a subtle drop shadow for catalog pages.
 * 2. When a desktop publishing application must render EPS logos, apply a shadow effect, and export them as TIFF files for print‑ready PDFs.
 * 3. When an e‑commerce platform wants to generate product preview images from EPS designs, adding depth with a drop shadow before storing them as TIFFs.
 * 4. When a batch‑processing tool automates the conversion of multiple EPS files to TIFF while enhancing visual appeal with a shadow for marketing materials.
 * 5. When a scientific reporting workflow requires rasterizing EPS diagrams, applying a drop shadow, and saving them as high‑quality TIFF images for inclusion in research papers.
 */
