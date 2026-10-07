// HOW-TO: Compare Sobel Custom Kernel Edge Detection With Emboss3x3 In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPathSobel = "Output/sobel.png";
            string outputPathEmboss = "Output/emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Sobel-like edge detection
            using (RasterImage sobelImage = (RasterImage)Image.Load(inputPath))
            {
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };
                var sobelOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel);
                sobelImage.Filter(sobelImage.Bounds, sobelOptions);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPathSobel));
                sobelImage.Save(outputPathSobel);
            }

            // Emboss3x3 edge detection
            using (RasterImage embossImage = (RasterImage)Image.Load(inputPath))
            {
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                embossImage.Filter(embossImage.Bounds, embossOptions);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPathEmboss));
                embossImage.Save(outputPathEmboss);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to highlight horizontal and vertical edges in a PNG file using a Sobel‑like convolution kernel and compare the result to an emboss filter for visual analysis.
 * 2. When you want to generate side‑by‑side edge‑detected images to decide which filter improves feature extraction for OCR preprocessing.
 * 3. When you are developing a photo‑editing application that lets users toggle between a custom Sobel filter and the built‑in Emboss3x3 filter to preview artistic effects.
 * 4. When you must automate quality‑control by applying two different convolution kernels to the same image and saving both outputs for later comparison.
 * 5. When you are benchmarking the performance of a custom convolution matrix against Aspose.Imaging’s predefined Emboss3x3 filter in a C# workflow.
 */
