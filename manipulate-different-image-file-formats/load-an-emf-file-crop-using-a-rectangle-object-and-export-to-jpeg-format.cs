// HOW-TO: Crop EMF File and Convert to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "Output\\output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_image.png");

            using (Image emfImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = emfImage.Width,
                        PageHeight = emfImage.Height
                    }
                };
                emfImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                if (!raster.IsCached) raster.CacheData();

                Rectangle cropRect = new Rectangle(0, 0, raster.Width / 2, raster.Height / 2);
                raster.Crop(cropRect);

                var jpegOptions = new JpegOptions();
                raster.Save(outputPath, jpegOptions);
            }

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
 * 1. When you need to display a portion of a vector EMF logo on a web page that only supports JPEG images.
 * 2. When generating thumbnail previews of EMF diagrams for a document management system that stores images as JPEG.
 * 3. When extracting the top‑left quadrant of a large EMF chart to embed in a PDF report that requires raster images.
 * 4. When converting legacy EMF assets to JPEG for use in mobile applications that cannot render vector formats.
 * 5. When automating a batch process that crops and compresses EMF drawings into JPEG files for email attachments.
 */
