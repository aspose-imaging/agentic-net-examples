using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string tempPngPath = Path.Combine(outputDir ?? string.Empty, "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load ODG vector image and rasterize to PNG
            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = vectorImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                vectorImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG, apply median filter, and save as JPEG
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)rasterImage;
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                var jpegOptions = new JpegOptions();
                raster.Save(outputPath, jpegOptions);
            }

            // Cleanup temporary file
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