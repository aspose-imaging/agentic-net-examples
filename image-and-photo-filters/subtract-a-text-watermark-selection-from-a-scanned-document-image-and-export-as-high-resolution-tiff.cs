// HOW-TO: Remove Text Watermark from Scanned Image and Save as High‑Resolution TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the scanned document image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define the watermark mask (example ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 50)));
                mask.AddFigure(figure);

                // Configure Telea watermark removal options
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Remove the watermark
                using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    // Set high‑resolution TIFF options
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Lzw,
                        Photometric = TiffPhotometrics.Rgb
                    };

                    // Save the cleaned image as TIFF
                    result.Save(outputPath, tiffOptions);
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
 * 1. When you need to clean scanned paper documents that contain a printed watermark before archiving them as lossless TIFF files.
 * 2. When a batch‑processing tool must automatically erase logo or text overlays from JPEG scans and store the results with LZW compression for long‑term storage.
 * 3. When a document management system requires high‑resolution TIFF output after removing confidential watermarks to meet compliance standards.
 * 4. When you want to programmatically apply a custom shape mask (e.g., ellipse) to target a specific watermark region in a scanned image using C#.
 * 5. When integrating Aspose.Imaging into a workflow that converts watermarked JPEG scans into searchable TIFFs for OCR processing.
 */
