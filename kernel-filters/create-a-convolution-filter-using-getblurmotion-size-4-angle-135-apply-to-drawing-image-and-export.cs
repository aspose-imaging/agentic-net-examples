using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG image with bound output file
            var pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;

            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Draw a simple rectangle
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);
                var pen = new Pen(Color.Blue, 5);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 300, 200));

                // Apply motion blur convolution filter (size 4, angle 135)
                var raster = (RasterImage)image;
                double[,] kernel = ConvolutionFilter.GetBlurMotion(4, 135);
                var convOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                // Save the image (file is already bound to outputPath)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}