// HOW-TO: Increase Contrast Of Cdr File And Save As Tiff In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
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

            foreach (string file in files)
            {
                if (Path.GetExtension(file).Equals(".cdr", StringComparison.OrdinalIgnoreCase))
                {
                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        return;
                    }

                    using (CdrImage cdr = (CdrImage)Image.Load(file))
                    {
                        using (var pngOptions = new PngOptions())
                        {
                            pngOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height,
                                BackgroundColor = Color.White
                            };

                            using (var ms = new MemoryStream())
                            {
                                cdr.Save(ms, pngOptions);
                                ms.Position = 0;

                                using (RasterImage raster = (RasterImage)Image.Load(ms))
                                {
                                    if (!raster.IsCached) raster.CacheData();
                                    raster.AdjustContrast(50);

                                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".tiff");
                                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                                    using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                                    {
                                        raster.Save(outputPath, tiffOptions);
                                    }
                                }
                            }
                        }
                    }
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
 * 1. When you need to improve the visual clarity of legacy CorelDRAW (.cdr) drawings before archiving them as high‑resolution TIFF files.
 * 2. When a batch job must automatically adjust the contrast of multiple CDR pages and output them in a lossless TIFF format for printing.
 * 3. When integrating Aspose.Imaging into a C# application to convert vector CDR artwork into raster TIFF images with enhanced contrast for document management systems.
 * 4. When preparing CDR graphics for OCR or image analysis pipelines that require TIFF input with consistent contrast levels.
 * 5. When a developer wants to programmatically process user‑uploaded CDR files, boost their contrast, and store the results as TIFFs for downstream web or desktop viewers.
 */
