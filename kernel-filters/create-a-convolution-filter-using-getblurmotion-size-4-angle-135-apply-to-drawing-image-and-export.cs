using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main()
    {
        try
        {
            string outputPath = Path.Combine("Output", "drawing_filtered.png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawRectangle(new Pen(Color.Blue, 5), new Rectangle(50, 50, 200, 150));
                graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(300, 100, 150, 100));
                graphics.DrawLine(new Pen(Color.Green, 2), new Point(100, 400), new Point(400, 400));

                RasterImage raster = (RasterImage)image;
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(4, 135);
                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}