using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\sample.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
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
 * 1. When a developer needs to convert a CorelDRAW CDR design into a lossless TIFF image for archival or printing, using Aspose.Imaging to apply LZW compression.
 * 2. When an automated workflow must batch‑process CDR files from a design repository and generate compressed TIFF files for inclusion in a document management system.
 * 3. When a web application receives user‑uploaded CorelDRAW files and must render them as TIFF images with LZW compression to reduce file size before storing them in cloud storage.
 * 4. When a desktop utility has to export vector graphics from a CDR file to a raster TIFF format while preserving page dimensions and using LZW compression for efficient transmission.
 * 5. When a migration script needs to transform legacy CorelDRAW assets into TIFF files that can be displayed in standard image viewers, ensuring the output uses LZW compression for optimal balance of quality and size.
 */