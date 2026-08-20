// HOW-TO: Sharpen EPS Image and Export as High‑Resolution JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string tempPngPath = "temp.png";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS and rasterize to a high‑resolution PNG
            using (Image epsImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = 2000,
                        PageHeight = 2000
                    }
                };
                epsImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG, apply sharpening, and save as high‑quality JPEG
            using (Image pngImage = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)pngImage;
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                var jpegOptions = new JpegOptions
                {
                    Quality = 100
                };
                raster.Save(outputPath, jpegOptions);
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When a designer needs to convert a vector EPS logo to a crisp, sharpened JPEG for web or print catalogs.
 * 2. When an e‑commerce platform must generate high‑resolution product thumbnails from EPS artwork with enhanced edge definition.
 * 3. When a publishing workflow requires rasterizing EPS illustrations, applying a sharpening filter, and saving them as lossless‑quality JPEGs for print‑ready PDFs.
 * 4. When an automated batch process must transform legacy EPS files into sharpened JPEGs for archival or SEO‑friendly image assets.
 * 5. When a mobile app backend needs to serve sharpened, high‑quality JPEG previews of EPS drawings without storing intermediate PNG files.
 */
