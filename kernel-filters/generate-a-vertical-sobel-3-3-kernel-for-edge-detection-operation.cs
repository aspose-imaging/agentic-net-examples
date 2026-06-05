using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, -2, -1 },
                    { 0, 0, 0 },
                    { 1, 2, 1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1, 0);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When a developer needs to extract vertical edges from scanned PNG documents to improve OCR accuracy, they can use this Aspose.Imaging C# code to apply a Sobel filter.
 * 2. When building a medical imaging application that highlights bone structures in X‑ray images, the vertical Sobel kernel can be applied with Aspose.Imaging to emphasize vertical gradients.
 * 3. When creating a real‑time video processing pipeline that detects lane markings on road images, the code can be used to preprocess each frame by detecting vertical edges before further analysis.
 * 4. When developing a photo‑editing tool that offers users an “edge‑enhance vertical” filter, the convolution filter options in Aspense.Imaging allow developers to implement the effect on PNG or JPEG files.
 * 5. When automating quality inspection for printed circuit boards, the vertical Sobel filter can help identify misaligned traces by highlighting vertical edges in the captured images.
 */