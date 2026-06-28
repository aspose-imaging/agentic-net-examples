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
            int dpiX = 300;
            int dpiY = 300;

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
                // Determine page count (default to 1 if not multipage)
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare TIFF save options
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);

                    // Rasterize vector content if applicable
                    if (image is VectorImage)
                    {
                        VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };
                        tiffOptions.VectorRasterizationOptions = vectorOptions;
                    }

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
 * 1. When a CAD application needs to export each page of a multi‑page EMF drawing to high‑resolution TIFF files for printing or archiving.
 * 2. When a document management system must convert vector‑based EMF reports into separate 300 dpi TIFF images for compatibility with legacy scanners.
 * 3. When a GIS workflow requires rasterizing multi‑page EMF maps into individual TIFF tiles at a specific DPI for use in raster‑based analysis tools.
 * 4. When an e‑learning platform wants to generate high‑quality TIFF slides from a multi‑page EMF presentation for offline viewing on devices that only support TIFF.
 * 5. When a legal firm needs to preserve each page of an EMF‑generated contract as a separate, DPI‑controlled TIFF file for court‑approved electronic evidence.
 */