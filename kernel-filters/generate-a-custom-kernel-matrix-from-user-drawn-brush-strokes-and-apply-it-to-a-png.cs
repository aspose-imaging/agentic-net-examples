using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage inputRaster = (RasterImage)Image.Load(inputPath))
            {
                using (PngImage kernelImage = new PngImage(3, 3))
                {
                    Graphics graphics = new Graphics(kernelImage);
                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.White))
                    {
                        graphics.FillRectangle(brush, new Rectangle(1, 1, 1, 1));
                    }

                    RasterImage kernelRaster = (RasterImage)kernelImage;
                    int[] argbPixels = kernelRaster.LoadArgb32Pixels(kernelRaster.Bounds);

                    double[,] customKernel = new double[3, 3];
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            int index = y * 3 + x;
                            int argb = argbPixels[index];
                            int red = (argb >> 16) & 0xFF;
                            customKernel[y, x] = red / 255.0;
                        }
                    }

                    var convolutionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                    inputRaster.Filter(inputRaster.Bounds, convolutionOptions);
                }

                PngOptions saveOptions = new PngOptions();
                saveOptions.Source = new FileCreateSource(outputPath, false);
                inputRaster.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}