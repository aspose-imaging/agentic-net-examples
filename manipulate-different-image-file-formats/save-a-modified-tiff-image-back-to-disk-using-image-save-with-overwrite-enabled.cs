using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                if (!tiffImage.IsCached)
                    tiffImage.CacheData();

                Graphics graphics = new Graphics(tiffImage.ActiveFrame);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, tiffImage.ActiveFrame.Bounds);
                }

                tiffImage.Save(outputPath);
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
 * 1. When a medical imaging system needs to annotate a diagnostic TIFF scan with a red overlay and overwrite the original file on the server.
 * 2. When a document management workflow must apply a watermark to multi‑page TIFF invoices and save the updated file back to the same location without creating a duplicate.
 * 3. When a GIS application programmatically highlights a region in a satellite TIFF raster and overwrites the existing file to keep the dataset current.
 * 4. When an archival tool processes scanned TIFF photographs, adds a color‑corrected rectangle, and saves the changes in place to preserve the original file name.
 * 5. When a batch processing script updates TIFF thumbnails in a digital asset library and uses Image.Save with overwrite enabled to replace each original image efficiently.
 */