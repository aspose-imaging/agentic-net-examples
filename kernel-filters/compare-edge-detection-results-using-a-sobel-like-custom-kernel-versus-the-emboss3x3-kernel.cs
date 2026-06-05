using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputSobPath = "output\\sobel.png";
            string outputEmbossPath = "output\\emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputSobPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputEmbossPath));

            // Sobel-like custom kernel (horizontal edge detection)
            double[,] sobelKernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            // Apply Sobel kernel
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(sobelKernel));
                raster.Save(outputSobPath);
            }

            // Apply Emboss3x3 kernel
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                raster.Save(outputEmbossPath);
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
 * 1. When building a C# desktop application that preprocesses PNG scans of engineering drawings, a developer can use this code to compare Sobel horizontal edge detection with the Emboss3x3 filter to highlight structural lines before vectorization.
 * 2. When creating an automated quality‑control pipeline for printed circuit board (PCB) images, the code helps evaluate which convolution kernel—Sobel‑like or Emboss3x3—produces clearer trace edges for defect detection.
 * 3. When developing a medical imaging tool that extracts tissue boundaries from grayscale scans, a developer can run both filters with Aspose.Imaging to decide which kernel yields more accurate edge contrast for diagnosis.
 * 4. When implementing a photo‑editing web service that offers an “edge‑enhance” option, the code allows the backend to generate side‑by‑side Sobel and emboss results so users can choose their preferred visual style.
 * 5. When training a machine‑learning model on handwritten digit images, a data scientist can apply both filters to the PNG dataset to compare how each convolution kernel affects feature extraction for improved model accuracy.
 */