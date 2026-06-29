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
            string inputPath = "input.eps";
            string tempPngPath = "temp.png";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS and rasterize to PNG
            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
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

            // Load the rasterized PNG, apply sharpening filter, and save as high‑resolution JPEG
            using (Image img = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)img;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                var jpegOptions = new JpegOptions
                {
                    Quality = 100,
                    ResolutionSettings = new ResolutionSetting(300, 300)
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
 * 1. When a designer must generate a web‑ready high‑resolution JPEG preview of an EPS logo and wants to sharpen the rasterized image for clearer edges using Aspose.Imaging in C#.
 * 2. When a publishing workflow requires converting EPS illustrations to PNG, applying a sharpening filter, and then saving them as 300 dpi JPEGs for print‑quality proofs.
 * 3. When an e‑commerce platform needs to transform product EPS vector files into sharpened, high‑resolution JPEG thumbnails for faster page loading.
 * 4. When a marketing automation script must batch‑process EPS banners, enhance detail with a SharpenFilterOptions, and output JPEGs at maximum quality for email campaigns.
 * 5. When a desktop application needs to load an EPS file, rasterize it to a temporary PNG, apply image sharpening, and export a 300 dpi JPEG for archival storage.
 */