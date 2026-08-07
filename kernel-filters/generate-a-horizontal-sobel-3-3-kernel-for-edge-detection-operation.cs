using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)image)
                {
                    double[,] kernel = new double[,]
                    {
                        { -1, 0, 1 },
                        { -2, 0, 2 },
                        { -1, 0, 1 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);
                    raster.Filter(raster.Bounds, filterOptions);

                    var pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
                }
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
 * 1. When a developer needs to highlight horizontal edges in a PNG photograph for a computer‑vision preprocessing step, they can apply this Sobel 3×3 convolution filter in C# using Aspose.Imaging.
 * 2. When building an automated quality‑control system that flags defects on printed circuit boards, the code can detect horizontal line anomalies by processing raster images with the Sobel kernel.
 * 3. When creating a medical imaging tool that emphasizes bone structures in X‑ray scans saved as PNG, the developer can use this filter to extract horizontal edge details.
 * 4. When developing a document‑scanning application that extracts table rows from scanned pages, the Sobel filter helps isolate horizontal lines before OCR processing.
 * 5. When generating stylized edge‑enhanced thumbnails for a web gallery, the code provides a fast C# way to compute horizontal edges on PNG images using Aspose.Imaging.
 */