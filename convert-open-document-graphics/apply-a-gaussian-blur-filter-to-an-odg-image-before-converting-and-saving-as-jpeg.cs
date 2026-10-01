// HOW-TO: Apply Gaussian Blur to ODG and Convert to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/result.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height
                    }
                };
                vectorImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                raster.Filter(raster.Bounds, blurOptions);
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to soften the edges of an ODG diagram before delivering it as a high‑quality JPEG for web publishing.
 * 2. When an application must convert vector‑based ODG files to raster JPEGs while applying a blur effect for watermarking or aesthetic purposes.
 * 3. When you want to generate preview thumbnails of ODG drawings with a Gaussian blur to hide sensitive details before saving them as JPEG.
 * 4. When automating a workflow that rasterizes ODG graphics to PNG, applies a blur filter, and outputs compressed JPEGs for email attachments.
 * 5. When integrating Aspose.Imaging in a C# service to process ODG artwork, apply Gaussian blur, and store the result as a JPEG with specific quality settings.
 */
