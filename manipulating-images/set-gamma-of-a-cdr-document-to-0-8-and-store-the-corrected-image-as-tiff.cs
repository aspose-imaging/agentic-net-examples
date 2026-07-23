using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\input.cdr";
            string outputPath = "C:\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };

                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (TiffImage tiff = (TiffImage)Image.Load(ms))
                    {
                        tiff.AdjustGamma(0.8f);
                        tiff.Save(outputPath);
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
 * 1. When a printing workflow requires converting CorelDRAW (CDR) artwork to a high‑resolution TIFF while applying a gamma of 0.8 to ensure consistent brightness across different printers.
 * 2. When a digital archiving system needs to preserve vector CDR files as lossless TIFF images with corrected gamma for accurate visual reproduction on archival monitors.
 * 3. When a web service generates preview thumbnails of CDR designs in TIFF format and must adjust gamma to 0.8 to match the website’s color profile.
 * 4. When an automated batch process migrates legacy CDR assets to TIFF for a document management system and applies gamma correction to compensate for faded colors in the original files.
 * 5. When a scientific imaging application imports CDR diagrams, converts them to TIFF, and uses a gamma of 0.8 to improve contrast for downstream analysis.
 */