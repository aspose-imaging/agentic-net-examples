using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.odg");
        string outputPath = Path.Combine("Output", "sample_filtered.bmp");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG vector image and rasterize it to BMP
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var odgImage = (Aspose.Imaging.FileFormats.OpenDocument.OdgImage)image;

            var bmpOptions = new BmpOptions();
            var rasterOptions = new Aspose.Imaging.ImageOptions.OdgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = odgImage.Size
            };
            bmpOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rasterized BMP (temporary)
            odgImage.Save(outputPath, bmpOptions);
        }

        // Load the rasterized BMP, apply median filter, and save the final result
        using (Aspose.Imaging.Image bmpImage = Aspose.Imaging.Image.Load(outputPath))
        {
            var raster = (Aspose.Imaging.RasterImage)bmpImage;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
            raster.Save(outputPath);
        }
    }
}