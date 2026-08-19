// HOW-TO: Write Unit Tests for CMX to TIFF Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Single‑page CMX to TIFF conversion
            string singleInput = Path.Combine("Input", "single_page.cmx");
            string singleOutput = Path.Combine("Output", "single_page.tif");

            if (!File.Exists(singleInput))
            {
                Console.Error.WriteLine($"File not found: {singleInput}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(singleOutput));

            using (Image image = Image.Load(singleInput))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                image.Save(singleOutput, tiffOptions);
            }

            Console.WriteLine($"Single‑page conversion succeeded: {singleOutput}");

            // Multi‑page CMX to TIFF conversion (export first two pages)
            string multiInput = Path.Combine("Input", "multi_page.cmx");
            string multiOutput = Path.Combine("Output", "multi_page.tif");

            if (!File.Exists(multiInput))
            {
                Console.Error.WriteLine($"File not found: {multiInput}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(multiOutput));

            using (Image image = Image.Load(multiInput))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                if (image is IMultipageImage multipage && multipage.PageCount > 2)
                {
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 2));
                }

                tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                image.Save(multiOutput, tiffOptions);
            }

            Console.WriteLine($"Multi‑page conversion succeeded: {multiOutput}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a CAD application needs to generate raster TIFF previews of CMX drawings for printing or archiving.
 * 2. When an automated build pipeline must verify that single‑page CMX files are correctly converted to TIFF without data loss.
 * 3. When a document management system has to batch‑process multi‑page CMX files and store each page as separate TIFF frames.
 * 4. When a web service provides on‑the‑fly conversion of uploaded CMX files to TIFF for browser display.
 * 5. When a quality‑assurance suite requires unit tests that confirm both single‑page and multi‑page CMX to TIFF conversions work as expected.
 */
