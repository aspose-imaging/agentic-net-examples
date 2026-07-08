using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Rasterize OTG to BMP using OtgRasterizationOptions
            string tempBmpPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));

            using (Image otgImage = Image.Load(inputPath))
            {
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                otgImage.Save(tempBmpPath, bmpOptions);
            }

            // Load the rasterized BMP, apply Otsu threshold, and save final binary BMP
            using (Image bmpImage = Image.Load(tempBmpPath))
            {
                if (bmpImage is RasterImage rasterImage)
                {
                    rasterImage.BinarizeOtsu();
                    var finalBmpOptions = new BmpOptions();
                    rasterImage.Save(outputPath, finalBmpOptions);
                }
                else
                {
                    Console.Error.WriteLine("Failed to cast loaded image to RasterImage.");
                }
            }

            // Clean up temporary file
            if (File.Exists(tempBmpPath))
            {
                File.Delete(tempBmpPath);
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
 * 1. When a CAD application needs to export vector OTG drawings as BMP thumbnails and automatically apply an Otsu threshold to produce high‑contrast previews.
 * 2. When a document management system must convert OTG schematics to binary BMP images for OCR preprocessing by rasterizing the vector data and binarizing with Otsu.
 * 3. When an industrial inspection tool requires rasterizing OTG floor plans into BMP files and then applying a threshold filter to generate black‑and‑white masks for defect detection.
 * 4. When a GIS platform wants to transform OTG map layers into BMP rasters and use Otsu binarization to create binary overlays for spatial analysis.
 * 5. When a legacy printing workflow needs to turn OTG artwork into high‑contrast BMP files by rasterizing the vector content and applying a threshold filter for monochrome laser printers.
 */