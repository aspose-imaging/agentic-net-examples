// HOW-TO: Convert ODG to BMP and Binarize Image with Threshold in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample_binary.bmp";
            string tempPath = "Output\\temp.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height
                    }
                };
                vectorImage.Save(tempPath, bmpOptions);
            }

            using (Image bmpImage = Image.Load(tempPath))
            {
                RasterCachedImage raster = (RasterCachedImage)bmpImage;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }
                raster.BinarizeFixed(128);
                raster.Save(outputPath, new BmpOptions());
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
 * 1. When you need to convert an ODG vector file to a BMP raster and then binarize it with a fixed threshold for OCR preprocessing using Aspose.Imaging for .NET.
 * 2. When a document‑processing workflow requires a high‑contrast binary BMP generated from ODG drawings to improve rendering speed on low‑color devices.
 * 3. When a machine‑vision application only accepts black‑and‑white bitmaps, you can rasterize the ODG and apply a 128‑level threshold to produce the required binary image.
 * 4. When preparing artwork for laser engraving, you may rasterize the ODG to BMP and use a threshold filter to create a printable black‑and‑white bitmap.
 * 5. When building a batch conversion utility that archives ODG diagrams as binary BMP files for space‑efficient storage, this code automates the rasterization and binarization steps.
 */
