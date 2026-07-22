using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    Graphics graphics = new Graphics(raster);
                    SolidBrush brush = new SolidBrush(Color.Red);
                    graphics.FillRectangle(brush, new Rectangle(10, 10, 100, 100));
                }

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to programmatically add a red highlight rectangle to a scanned TIFF invoice and overwrite the original file for downstream accounting systems.
 * 2. When a medical imaging application must annotate a TIFF X‑ray by drawing a colored region and save the modified image back to disk without creating a duplicate file.
 * 3. When an engineering workflow requires stamping a TIFF blueprint with a warning box using C# graphics and then overwriting the source file for version control.
 * 4. When a document management system wants to batch‑process multi‑page TIFF files, draw a marker on each page, and replace the existing files to conserve storage.
 * 5. When a GIS tool needs to overlay a red rectangle on a TIFF satellite tile and save the updated tile using Aspose.Imaging’s Image.Save with overwrite enabled for immediate map rendering.
 */