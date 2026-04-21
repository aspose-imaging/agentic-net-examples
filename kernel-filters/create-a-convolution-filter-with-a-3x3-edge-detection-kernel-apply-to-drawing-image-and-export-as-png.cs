using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string outputPath = "output.png";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a bound output file
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 PNG image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Draw some primitive shapes
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, new Rectangle(50, 50, 200, 150));
                }

                graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(300, 200, 150, 100));
                graphics.DrawLine(new Pen(Color.Green, 2), new Point(0, 0), new Point(499, 499));

                // Apply a 3x3 edge detection convolution filter
                RasterImage raster = (RasterImage)image;
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(edgeKernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the image (output is already bound to the file)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}