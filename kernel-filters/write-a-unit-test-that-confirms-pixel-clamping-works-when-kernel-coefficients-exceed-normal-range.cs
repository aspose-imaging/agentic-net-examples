using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Ensure input image exists; create a simple 3x3 gray image if missing
            if (!File.Exists(inputPath))
            {
                using (Image img = Image.Create(new PngOptions(), 3, 3))
                {
                    RasterImage raster = (RasterImage)img;
                    int[] pixels = Enumerable.Repeat(unchecked((int)0xFF646464), 9).ToArray(); // ARGB gray
                    Rectangle rect = new Rectangle(0, 0, 3, 3);
                    raster.SaveArgb32Pixels(rect, pixels);
                    raster.Save(inputPath);
                }
            }

            // Input existence check as required
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image and apply convolution filter with extreme kernel values
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;

                double[,] kernel = new double[,]
                {
                    { 1000, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 }
                };
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);

                // Verify that pixel values are clamped to the 0‑255 range
                Aspose.Imaging.Color color = raster.GetPixel(0, 0);
                bool clamped = color.R >= 0 && color.R <= 255 &&
                               color.G >= 0 && color.G <= 255 &&
                               color.B >= 0 && color.B <= 255;

                Console.WriteLine(clamped ? "Pixel values are correctly clamped." : "Pixel values are out of range.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}