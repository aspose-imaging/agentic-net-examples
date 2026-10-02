// HOW-TO: Apply Horizontal Sobel Edge Detection to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] sobelKernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var options = new ConvolutionFilterOptions(sobelKernel);
                image.Filter(image.Bounds, options);
                image.Save(outputPath);
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
 * 1. When you need to highlight horizontal edges in a photo for computer‑vision preprocessing.
 * 2. When converting scanned documents to emphasize text lines before OCR.
 * 3. When creating artistic edge‑enhanced thumbnails for a web gallery.
 * 4. When detecting lane markings in road images for an autonomous‑driving prototype.
 * 5. When preparing medical X‑ray images to accentuate bone structures for analysis.
 */
