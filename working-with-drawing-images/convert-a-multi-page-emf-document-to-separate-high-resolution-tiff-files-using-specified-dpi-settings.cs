// HOW-TO: Convert Multi-Page EMF to High-Resolution TIFF Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputDir = "output";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the EMF document
            using (Image image = Image.Load(inputPath))
            {
                // Determine page count (if multipage)
                int pageCount = 1;
                if (image is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    pageCount = multipage.PageCount;
                }

                // Process each page separately
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure TIFF options with high DPI (e.g., 300)
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                    // Set vector rasterization options for high-quality rendering
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    tiffOptions.VectorRasterizationOptions = vectorOptions;

                    // Export only the current page
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                    // Save the page as a separate TIFF file
                    image.Save(outputPath, tiffOptions);
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
 * 1. When you need to split a multi-page vector EMF report into individual high‑DPI TIFF images for printing or archival.
 * 2. When a document-management system requires each page of an EMF diagram to be stored as a separate raster TIFF with 300 dpi resolution.
 * 3. When generating thumbnails or previews of each EMF page for a web gallery and you want lossless TIFF output.
 * 4. When integrating legacy EMF drawings into a workflow that only accepts TIFF files for OCR or image analysis.
 * 5. When automating batch conversion of EMF files to high-quality TIFFs to meet regulatory image-quality standards.
 */
