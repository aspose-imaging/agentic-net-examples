using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer must archive legacy CMX drawings in a multi‑page TIFF for regulatory compliance, they can convert the single‑page CMX and insert blank pages to meet the required page count.
 * 2. When an engineering workflow requires merging a single‑page CMX schematic with placeholder pages for future revisions, the code can generate a multi‑page TIFF that includes those blank pages.
 * 3. When a document management system expects multi‑page TIFF files for batch processing, developers can use the conversion to transform a CMX file and add empty pages to satisfy the system’s format rules.
 * 4. When creating printable portfolios that combine a CMX illustration with reserved spaces for annotations, the code enables conversion to a multi‑page TIFF with blank pages for manual notes.
 * 5. When integrating legacy CAD assets into a digital archiving pipeline that stores images as multi‑page TIFFs, developers can convert each CMX file and pad it with blank pages to align with the archive’s page‑layout standards.
 */