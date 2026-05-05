using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputSobPath = "output/output_sobel.png";
            string outputEmbossPath = "output/output_emboss.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputSobPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputEmbossPath));

            // ---------- Sobel-like edge detection ----------
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                var sobelOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel);
                image.Filter(image.Bounds, sobelOptions);

                var pngOptions = new PngOptions();
                image.Save(outputSobPath, pngOptions);
            }

            // ---------- Emboss3x3 kernel ----------
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;

                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                image.Filter(image.Bounds, embossOptions);

                var pngOptions = new PngOptions();
                image.Save(outputEmbossPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}