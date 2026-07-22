using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\scanned_document.png";
        string outputPath = @"C:\Images\Processed\scanned_document_clean.tif";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // The watermark remover works on RasterImage instances
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Unsupported image format. Expected a raster image.");
                    return;
                }

                // ------------------------------------------------------------
                // Build a mask that covers the text watermark.
                // In a real scenario you would construct the mask from the
                // exact shape of the watermark (e.g., using OCR or known
                // coordinates). Here we use a simple rectangular mask as an
                // example.
                // ------------------------------------------------------------
                var mask = new GraphicsPath();
                var figure = new Figure();
                // RectangleF(x, y, width, height) – adjust to match the watermark area
                figure.AddShape(new RectangleShape(new RectangleF(100, 100, 400, 50)));
                mask.AddFigure(figure);

                // Choose the Telea algorithm for watermark removal
                var options = new TeleaWatermarkOptions(mask);

                // Perform the removal; the method returns a new RasterImage
                RasterImage cleaned = WatermarkRemover.PaintOver(raster, options);

                // Save the result as a high‑resolution TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                cleaned.Save(outputPath, tiffOptions);
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
 * 1. When a law office must strip confidential text watermarks from scanned contracts and save the cleaned pages as high‑resolution TIFF files for secure archival, this C# Aspose.Imaging code provides a reliable solution.
 * 2. When a medical records department needs to remove patient‑identifying watermark text from scanned forms before converting them to lossless TIFF for compliance with health‑information regulations, the example demonstrates exactly how to do it.
 * 3. When an insurance company processes scanned claim documents that contain branding watermarks and wants to export the cleaned images as high‑quality TIFF for OCR and claims analysis, the code shows the necessary steps.
 * 4. When a publishing house digitizes legacy books that include publisher watermarks on scanned pages and requires TIFF output for print‑ready workflows, this snippet illustrates the watermark subtraction process.
 * 5. When a government agency prepares scanned public records by eliminating classified text watermarks and exporting the results as high‑resolution TIFF for public release, the provided Aspose.Imaging for .NET example handles the task.
 */