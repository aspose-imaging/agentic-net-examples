// HOW-TO: Create Multipage TIFF From Multiple PSD Files In C# (Aspose.Imaging for .NET)
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
            string inputPath1 = "psd1.psd";
            string inputPath2 = "psd2.psd";
            string inputPath3 = "psd3.psd";
            string outputPath = "output/multipage.tif";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            using (Image img1 = Image.Load(inputPath1))
            using (Image img2 = Image.Load(inputPath2))
            using (Image img3 = Image.Load(inputPath3))
            {
                RasterImage raster1 = (RasterImage)img1;
                RasterImage raster2 = (RasterImage)img2;
                RasterImage raster3 = (RasterImage)img3;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, raster1.Width, raster1.Height))
                {
                    tiff.SavePixels(tiff.ActiveFrame.Bounds, raster1.LoadPixels(raster1.Bounds));

                    tiff.AddPage(raster2);
                    tiff.AddPage(raster3);

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    tiff.Save(outputPath);
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
 * 1. When you need to combine several Photoshop PSD files into a single multi‑page TIFF for printing or archival purposes.
 * 2. When a document management system requires a high‑resolution multi‑page TIFF that contains each page sourced from separate PSD assets.
 * 3. When generating a PDF‑like document where each page is designed in Photoshop and must be bundled into a TIFF for compatibility with legacy imaging software.
 * 4. When automating the creation of a multi‑page scan where each scanned image is edited in PSD and then merged into one TIFF for batch processing.
 * 5. When exporting a series of design mockups from PSD to a single TIFF to reduce file‑handling overhead in a C# image‑processing pipeline.
 */
