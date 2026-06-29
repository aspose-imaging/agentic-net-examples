using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output_emboss5x5.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;
                tiffImage.Filter(tiffImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to preprocess noisy TIFF scans of historical documents before running OCR to see if the Emboss5x5 filter improves text recognition accuracy.
 * 2. When a C# application must batch‑process scanned forms stored as multi‑page TIF files, apply a 5×5 emboss convolution, and compare OCR results to the original unfiltered images.
 * 3. When a data‑entry automation pipeline requires measuring the impact of Aspose.Imaging’s Emboss5x5 filter on OCR performance for low‑contrast, speckled scanned receipts.
 * 4. When a machine‑learning team wants to evaluate whether applying the Emboss5x5 convolution to noisy medical image PDFs converted to TIFF reduces OCR error rates in patient records.
 * 5. When an enterprise document‑management system must generate a filtered version of a scanned TIFF and quantify OCR accuracy gains to justify adding the filter step to the workflow.
 */