using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                    raster.CacheData();

                raster.Resize(500, 500);

                double[,] kernel = ConvolutionFilter.GetGaussian(5, 1.0);
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a web application needs to generate a printable PDF thumbnail from user‑uploaded PNG avatars, resizing them to 500 × 500 pixels and applying a Gaussian blur for a soft‑focus effect.
 * 2. When an e‑commerce platform wants to create catalog pages that embed blurred product images, converting high‑resolution PNGs to 500 × 500 PDF assets using Aspose.Imaging in C#.
 * 3. When a document‑automation script must batch‑process marketing banners, scaling each PNG to a fixed 500 × 500 size, smoothing edges with a Gaussian filter, and exporting the result as a PDF for distribution.
 * 4. When a desktop utility needs to prepare confidential screenshots by resizing them, applying a Gaussian blur to obscure details, and saving them as PDF files for secure archiving.
 * 5. When a reporting tool generates PDF reports that include resized and softly blurred PNG charts, using Aspose.Imaging’s image filters and PDF options in a .NET environment.
 */