using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\scanned_doc.png";
            string outputPath = @"C:\Images\scanned_doc_clean.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the scanned document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage required by WatermarkRemover
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Unsupported image format for watermark removal.");
                    return;
                }

                // Define a mask that covers the text watermark area.
                // Adjust the rectangle coordinates to match the actual watermark location.
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(100, 100, 400, 50)));
                mask.AddFigure(figure);

                // Use Telea algorithm for watermark removal
                var options = new TeleaWatermarkOptions(mask);

                // Remove the watermark
                RasterImage result = WatermarkRemover.PaintOver(raster, options);

                // Save the cleaned image as a high‑resolution TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                result.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to clean a scanned document saved as PNG by removing a printed text watermark and then archive the result as a high‑resolution TIFF for legal compliance.
 * 2. When an imaging application must automatically strip confidential header text from batch‑scanned invoices (PNG) before storing them in a TIFF‑based document management system.
 * 3. When a medical records system requires removal of patient‑identifying watermark text from scanned X‑ray images and conversion to lossless TIFF for long‑term storage.
 * 4. When a government agency processes digitized forms that contain draft watermarks, using C# and Aspose.Imaging to erase the watermark region and output a high‑resolution TIFF for archival.
 * 5. When a developer builds a desktop tool that lets users select a rectangular area containing a watermark on a scanned document image, removes it with the Telea algorithm, and saves the cleaned image as a TIFF for printing.
 */