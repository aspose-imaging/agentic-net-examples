using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\multipage.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;
                int pageIndex = 0;

                foreach (var frame in tiffImage.Frames)
                {
                    tiffImage.ActiveFrame = frame;

                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1, 8, -1 },
                        { -1, -1, -1 }
                    };

                    tiffImage.Filter(tiffImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                    string outputPath = $"output\\page_{pageIndex}.png";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions();
                    tiffImage.Save(outputPath, pngOptions);

                    pageIndex++;
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
 * 1. When a developer needs to extract each page from a multi‑page TIFF, apply an edge‑detection convolution filter, and save the results as PNG files for further analysis or display.
 * 2. When preprocessing scanned documents in C# to highlight boundaries before running OCR, using Aspose.Imaging to loop through TIFF frames and apply a custom kernel.
 * 3. When converting a multi‑page medical imaging TIFF series into separate PNG images with enhanced edges for diagnostic review or machine‑learning feature extraction.
 * 4. When building a document‑archiving pipeline that automatically processes each page of a TIFF archive, applies a sharpening filter, and stores the filtered pages in a PNG format for web preview.
 * 5. When creating a batch image‑processing tool that iterates over TIFF frames, performs convolution‑based edge detection, and outputs the filtered pages to a designated folder for quality‑control inspection.
 */