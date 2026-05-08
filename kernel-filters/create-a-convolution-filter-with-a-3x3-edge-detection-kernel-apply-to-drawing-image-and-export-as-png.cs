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
            string outputPath = "output/output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG creation options with a file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a blank PNG image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Draw on the image
                Pen pen = new Pen(Color.Black, 2);
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawRectangle(pen, new Rectangle(100, 100, 300, 200));

                // Apply a 3x3 edge detection convolution filter
                RasterImage raster = (RasterImage)image;
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the image (output is already bound via pngOptions)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}