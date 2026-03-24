using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.odg";
        string outputPath = "processed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG vector image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage (full namespace used to avoid missing using)
            var odgImage = (Aspose.Imaging.FileFormats.OpenDocument.OdgImage)image;

            // Rasterize ODG to a PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                // Save as PNG (raster format)
                var pngOptions = new PngOptions();
                odgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    var rasterImage = (RasterImage)rasterImageContainer;

                    // Apply a deconvolution filter (Gauss-Wiener) to the entire image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

                    // Save the processed raster image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}