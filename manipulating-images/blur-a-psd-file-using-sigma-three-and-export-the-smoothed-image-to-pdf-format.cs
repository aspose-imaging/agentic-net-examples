using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/blurred.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                // Apply Gaussian blur with radius 5 and sigma 3.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 3.0));

                PdfOptions pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When a designer wants to automatically soften the details of a Photoshop PSD file before generating a printable PDF brochure, they can use this C# code with Aspose.Imaging to apply a Gaussian blur (sigma 3) and export the result to PDF.
 * 2. When a web service needs to create preview PDFs of high‑resolution PSD assets with a subtle blur to protect copyrighted content, the code demonstrates how to load the PSD, blur it, and save as PDF in .NET.
 * 3. When an automation script must batch‑process Photoshop files to reduce file size by smoothing edges before archiving them as PDF documents, this example shows the required C# operations with Aspose.Imaging.
 * 4. When a desktop application requires converting a layered PSD into a flattened PDF while applying a Gaussian blur for a soft‑focus effect, the snippet provides the exact steps using RasterImage and PdfOptions.
 * 5. When a digital publishing workflow needs to generate PDF proofs from PSD source files with a consistent blur (sigma 3) for visual consistency across pages, the code illustrates the end‑to‑end process in C#.
 */