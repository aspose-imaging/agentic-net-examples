// HOW-TO: Apply Vertical Sobel Edge Detection to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.jpg";
        string outputPath = "output/output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] verticalSobel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(verticalSobel);
                image.Filter(image.Bounds, filterOptions);
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
 * 1. When you need to highlight vertical edges in a photo for computer‑vision preprocessing, you can use this code to apply a Sobel filter to a JPEG image in C#.
 * 2. When building a document‑scanning pipeline that extracts text lines, the vertical Sobel filter helps emphasize column boundaries before OCR.
 * 3. When creating a custom thumbnail generator that shows edge outlines of product images, the convolution filter can process PNG or JPEG files on the server.
 * 4. When developing a medical‑imaging analysis tool that requires detecting vessel edges in grayscale scans, the code demonstrates how to run a Sobel convolution with Aspose.Imaging.
 * 5. When automating quality‑control checks for printed circuit board photos, applying a vertical Sobel filter isolates trace edges for defect detection.
 */
