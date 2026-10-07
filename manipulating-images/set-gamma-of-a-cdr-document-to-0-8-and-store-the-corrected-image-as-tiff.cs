// HOW-TO: Adjust Gamma Of Cdr File To 0.8 And Save As Tiff In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/document.cdr";
            string outputPath = "Output/corrected.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdrImage.Width,
                        PageHeight = cdrImage.Height
                    }
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    cdrImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.AdjustGamma(0.8f);
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to correct the brightness of a CorelDRAW (CDR) illustration before archiving it as a high‑resolution TIFF for print production.
 * 2. When a workflow requires converting vector CDR artwork to a raster format, applying gamma correction to match a target display profile, and saving the result as TIFF for downstream processing.
 * 3. When preparing CDR graphics for OCR or image analysis, adjusting gamma ensures consistent contrast before the file is stored in a lossless TIFF container.
 * 4. When integrating Aspose.Imaging into a C# application that must batch‑process CDR files, applying a 0.8 gamma and exporting to TIFF simplifies color‑balance standardization across all assets.
 * 5. When a designer wants to export a CDR design with a specific gamma setting to TIFF for inclusion in a PDF portfolio, ensuring the final document retains the intended visual appearance.
 */
