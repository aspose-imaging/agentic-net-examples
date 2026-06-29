using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

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
 * 1. When a developer needs to convert an SVG logo into a high‑resolution TIFF for print‑ready artwork while preserving vector quality.
 * 2. When an e‑commerce platform must generate printable product labels from scalable SVG templates and store them as TIFF files for downstream workflows.
 * 3. When a GIS application requires rasterizing vector map layers (SVG) into TIFF images for integration with legacy raster‑based analysis tools.
 * 4. When a document management system automates the archival of vector diagrams by converting them to lossless TIFF files that can be indexed and searched.
 * 5. When a medical imaging solution needs to transform SVG‑based anatomical illustrations into high‑resolution TIFFs for inclusion in radiology reports.
 */