using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Output file path (hardcoded)
        string outputPath = @"C:\Temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options with a file source bound to the output path
        var pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        int width = 300;
        int height = 200;

        // Create a new PNG image bound to the output file
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, width, height))
        {
            // Drawing operations
            var graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);
            graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), new Aspose.Imaging.Rectangle(50, 50, 200, 150));

            using (var brush = new SolidBrush(Aspose.Imaging.Color.Blue))
            {
                graphics.DrawString(
                    "Edge Detection",
                    new Aspose.Imaging.Font("Arial", 24),
                    brush,
                    new Aspose.Imaging.PointF(60, 40));
            }

            // Apply a 3x3 edge detection convolution filter
            var raster = (Aspose.Imaging.RasterImage)image;
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
            raster.Filter(raster.Bounds, filterOptions);

            // Save the image (output path already bound via FileCreateSource)
            image.Save();
        }
    }
}