using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Single‑page CMX to TIFF conversion
            string inputSingle = "Input\\sample_single.cmx";
            string outputSingle = "Output\\sample_single.tif";

            if (!File.Exists(inputSingle))
            {
                Console.Error.WriteLine($"File not found: {inputSingle}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputSingle));

            using (Image image = Image.Load(inputSingle))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputSingle, tiffOptions);
            }

            if (File.Exists(outputSingle))
                Console.WriteLine("Single‑page conversion succeeded.");
            else
                Console.Error.WriteLine("Single‑page conversion failed.");

            // Multi‑page CMX to TIFF conversion (export first two pages)
            string inputMulti = "Input\\sample_multi.cmx";
            string outputMulti = "Output\\sample_multi.tif";

            if (!File.Exists(inputMulti))
            {
                Console.Error.WriteLine($"File not found: {inputMulti}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputMulti));

            using (Image image = Image.Load(inputMulti))
            {
                var exportOptions = new TiffOptions(TiffExpectedFormat.Default);
                exportOptions.MultiPageOptions = null;

                IMultipageImage multipage = image as IMultipageImage;
                if (multipage != null && multipage.PageCount > 2)
                {
                    exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 2));
                }

                if (image is VectorImage)
                {
                    exportOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                }

                image.Save(outputMulti, exportOptions);
            }

            if (File.Exists(outputMulti))
                Console.WriteLine("Multi‑page conversion succeeded.");
            else
                Console.Error.WriteLine("Multi‑page conversion failed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy CorelDRAW CMX artwork into a single‑page TIFF for archival in a document management system.
 * 2. When an automated batch process must transform multiple CMX files into multi‑page TIFFs so that each page can be indexed by an OCR engine.
 * 3. When a web service receives uploaded CMX drawings and must return a TIFF preview for browser display without requiring the client to install CorelDRAW.
 * 4. When a print‑preparation workflow requires extracting the first two pages of a multi‑page CMX file and saving them as a multi‑page TIFF for downstream RIP processing.
 * 5. When unit tests are needed to verify that Aspose.Imaging correctly loads CMX files, applies TiffOptions, and creates valid TIFF files for both single‑page and multi‑page scenarios.
 */