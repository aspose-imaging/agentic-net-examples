using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");

        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions();
            VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height,
                BackgroundColor = Color.White
            };
            pngOptions.VectorRasterizationOptions = rasterOptions;
            epsImage.Save(tempPath, pngOptions);
        }

        using (RasterImage raster = (RasterImage)Image.Load(tempPath))
        {
            int width = raster.Width;
            int height = raster.Height;

            Graphics graphics = new Graphics(raster);

            LinearGradientBrush topBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, height / 2),
                Color.Transparent,
                Color.Black);
            graphics.FillRectangle(topBrush, new Rectangle(0, 0, width, height / 2));

            LinearGradientBrush bottomBrush = new LinearGradientBrush(
                new Point(0, height),
                new Point(0, height / 2),
                Color.Transparent,
                Color.Black);
            graphics.FillRectangle(bottomBrush, new Rectangle(0, height / 2, width, height / 2));

            LinearGradientBrush leftBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(width / 2, 0),
                Color.Transparent,
                Color.Black);
            graphics.FillRectangle(leftBrush, new Rectangle(0, 0, width / 2, height));

            LinearGradientBrush rightBrush = new LinearGradientBrush(
                new Point(width, 0),
                new Point(width / 2, 0),
                Color.Transparent,
                Color.Black);
            graphics.FillRectangle(rightBrush, new Rectangle(width / 2, 0, width / 2, height));

            PngOptions finalOptions = new PngOptions();
            raster.Save(outputPath, finalOptions);
        }

        if (File.Exists(tempPath))
        {
            File.Delete(tempPath);
        }
    }
}