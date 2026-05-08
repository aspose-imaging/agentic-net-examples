using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Define a 3×3 sharpening kernel
                double[,] kernel = new double[,]
                {
                    { 0, -1,  0 },
                    { -1, 5, -1 },
                    { 0, -1,  0 }
                };

                // Apply convolution filter using the kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Prepare PNG save options preserving indexed palette
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(raster, 256),
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image
                raster.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}