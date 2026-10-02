// HOW-TO: Batch Convert Vector Drawings to High‑Resolution TIFF with LZW Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".tif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb))
                {
                    image.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive a large set of SVG or AI files as lossless, high‑resolution TIFFs for printing while keeping file size low with LZW compression.
 * 2. When a document management system must automatically convert incoming vector artwork into TIFF images for consistent viewing across platforms.
 * 3. When a GIS application requires batch transformation of vector map layers into tiled TIFF files for raster analysis.
 * 4. When a medical imaging workflow converts vector diagrams into TIFF format to embed them in DICOM reports with efficient storage.
 * 5. When a web service generates printable TIFF previews of user‑uploaded vector designs and wants to store them compactly on the server.
 */
