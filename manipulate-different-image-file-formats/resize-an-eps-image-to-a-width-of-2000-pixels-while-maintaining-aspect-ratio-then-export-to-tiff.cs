using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                // Resize width to 2000 pixels while preserving aspect ratio
                image.ResizeWidthProportionally(2000);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the resized image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When a print shop needs to convert high‑resolution EPS artwork to a 2000‑pixel‑wide TIFF for raster‑based pre‑press workflows while preserving the original aspect ratio.
 * 2. When a web application must generate thumbnail‑size TIFF previews of vector EPS logos for archival or catalog display without distorting the image.
 * 3. When an automated document processing pipeline has to downscale EPS diagrams to a fixed width of 2000 pixels before embedding them into PDF reports that only support TIFF images.
 * 4. When a GIS system requires EPS map layers to be resized proportionally and saved as TIFF files for compatibility with raster‑only analysis tools.
 * 5. When a digital asset management system needs to batch‑process incoming EPS files, resizing them to a standard 2000‑pixel width and converting them to TIFF for consistent storage and fast rendering.
 */