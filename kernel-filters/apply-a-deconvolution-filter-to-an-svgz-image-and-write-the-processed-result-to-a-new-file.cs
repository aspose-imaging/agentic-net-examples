using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.svgz";
        string outputPath = @"C:\Images\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        string tempRasterPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            vectorImage.Save(tempRasterPath, pngOptions);
        }

        using (Image rasterImageContainer = Image.Load(tempRasterPath))
        {
            var rasterImage = (RasterImage)rasterImageContainer;

            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            rasterImage.Filter(rasterImage.Bounds, new DeconvolutionFilterOptions(kernel));

            var finalOptions = new PngOptions();
            rasterImage.Save(outputPath, finalOptions);
        }

        if (File.Exists(tempRasterPath))
        {
            try
            {
                File.Delete(tempRasterPath);
            }
            catch
            {
                // Ignore cleanup errors
            }
        }
    }
}