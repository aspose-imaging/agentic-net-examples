using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempPngPath = "temp.png";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = vectorImage.Width,
                    PageHeight = vectorImage.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                vectorImage.Save(tempPngPath, pngOptions);
            }

            using (Image rasterImageContainer = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = (RasterImage)rasterImageContainer;

                var jpegOptions = new JpegOptions
                {
                    Quality = 95
                };

                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert an SVG logo into a high‑quality JPEG for email newsletters or web pages that only support raster image formats.
 * 2. When an application must generate JPEG previews of user‑uploaded vector graphics while preserving the original dimensions and a white background.
 * 3. When a batch‑processing tool has to transform a collection of SVG icons into JPEG thumbnails with 95 % quality for a product catalog.
 * 4. When a reporting system requires embedding vector diagrams as JPEG images in PDF reports, ensuring consistent color and resolution across platforms.
 * 5. When a legacy system only accepts JPEG files, a developer can rasterize SVG assets to PNG first and then save them as high‑quality JPEGs for compatibility.
 */