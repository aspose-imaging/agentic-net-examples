using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cdr";
        string outputPath = "output.tif";

        try
        {
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
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image raster = Image.Load(ms))
                    {
                        RasterImage rasterImg = (RasterImage)raster;
                        rasterImg.AdjustGamma(0.8f);
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        rasterImg.Save(outputPath, tiffOptions);
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
 * 1. When converting CorelDRAW (CDR) artwork to a high‑resolution TIFF for print production and needing to darken the image by applying a gamma of 0.8 to match the press profile.
 * 2. When an archival system requires rasterizing vector CDR files to lossless TIFF files while adjusting gamma to improve contrast for better visual inspection.
 * 3. When a web service generates preview TIFFs from uploaded CDR designs and must apply gamma correction to ensure consistent brightness across different browsers.
 * 4. When a batch‑processing tool automates the migration of legacy CDR assets to TIFF format and needs to standardize gamma to 0.8 for downstream image‑analysis algorithms.
 * 5. When a digital asset management workflow needs to store CDR graphics as TIFFs with corrected gamma so that color‑critical applications like OCR or medical imaging receive properly calibrated input.
 */