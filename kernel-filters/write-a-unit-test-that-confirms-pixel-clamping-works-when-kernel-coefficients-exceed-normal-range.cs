using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string outputPath = "TestOutput\\clamped.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int width = 3;
        int height = 3;
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(new BmpOptions(), width, height))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    raster.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(255, 100, 100, 100));
                }
            }

            double[,] kernel = new double[,]
            {
                { 10, 10, 10 },
                { 10, 10, 10 },
                { 10, 10, 10 }
            };
            var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 3);
            raster.Filter(raster.Bounds, options);
            raster.Save(outputPath, new BmpOptions());

            Aspose.Imaging.Color result = raster.GetPixel(1, 1);
            bool clamped = result.R == 255 && result.G == 255 && result.B == 255;
            Console.WriteLine(clamped ? "Test Passed: Pixels are clamped to 255." : "Test Failed: Pixels are not clamped.");
        }
    }
}