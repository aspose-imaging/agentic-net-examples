using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                foreach (TiffFrame frame in tiff.Frames)
                {
                    tiff.ActiveFrame = frame;
                    tiff.Filter(frame.Bounds, new ConvolutionFilterOptions(kernel));
                }

                tiff.Save(outputPath);
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
 * 1. When a developer needs to extract and highlight edges from each page of a multi‑page TIFF scan (e.g., architectural drawings) using C# and Aspose.Imaging’s convolution filter.
 * 2. When an application must automatically process every frame of a TIFF document to detect borders for quality‑control checks in a document‑management system.
 * 3. When a medical‑imaging workflow requires applying a Sobel‑like edge detection kernel to each slice of a multi‑frame TIFF to enhance tissue boundaries before analysis.
 * 4. When a GIS tool has to preprocess satellite imagery stored as a multi‑page TIFF by sharpening edges on each layer for better feature extraction.
 * 5. When a batch‑conversion utility needs to read a TIFF, apply an edge detection filter to all pages, and save the result as a new TIFF for downstream computer‑vision tasks.
 */