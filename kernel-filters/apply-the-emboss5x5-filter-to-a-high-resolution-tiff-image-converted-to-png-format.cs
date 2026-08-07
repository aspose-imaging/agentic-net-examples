using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;
                tiffImage.Filter(tiffImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to add a stylized emboss effect to a high‑resolution TIFF scan of a blueprint and then deliver the result as a lightweight PNG for web viewing.
 * 2. When an imaging pipeline must convert archival TIFF photographs to PNG while applying a 5×5 emboss convolution to enhance texture for a digital museum exhibit.
 * 3. When a document management system processes large TIFF invoices, applies an emboss filter to highlight watermarks, and saves the output as PNG for quick preview thumbnails.
 * 4. When a GIS application requires transforming detailed TIFF satellite imagery into PNG tiles with an emboss filter to accentuate terrain relief for visual analysis.
 * 5. When a batch job automates the conversion of TIFF medical scans to PNG format and uses the Emboss5x5 filter to improve edge definition for diagnostic reporting.
 */