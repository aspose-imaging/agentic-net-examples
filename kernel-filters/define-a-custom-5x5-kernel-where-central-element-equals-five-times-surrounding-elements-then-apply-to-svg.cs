using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary rasterized PNG path
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_raster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Rasterize SVG to PNG
            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG and apply custom convolution filter
            using (Image img = Image.Load(tempPngPath))
            {
                var rasterImage = (RasterImage)img;

                // Define 5x5 kernel: surrounding elements = 1, center = 5
                double[,] kernel = new double[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        kernel[i, j] = 1.0;
                    }
                }
                kernel[2, 2] = 5.0;

                // Apply convolution filter
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the filtered image
                var saveOptions = new PngOptions();
                rasterImage.Save(outputPath, saveOptions);
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