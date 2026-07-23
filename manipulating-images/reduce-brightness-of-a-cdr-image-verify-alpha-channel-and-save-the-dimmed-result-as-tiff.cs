using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/dimmed.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize CDR to TIFF in memory
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    cdr.Save(ms, tiffOptions);
                    ms.Position = 0;

                    using (TiffImage tiff = (TiffImage)Image.Load(ms))
                    {
                        // Dim the image by reducing brightness
                        tiff.AdjustBrightness(-50);

                        // Verify presence of alpha channel
                        Rectangle bounds = tiff.Bounds;
                        int[] pixels = tiff.LoadArgb32Pixels(bounds);
                        bool hasAlpha = false;
                        foreach (int pixel in pixels)
                        {
                            int alpha = (pixel >> 24) & 0xFF;
                            if (alpha != 255)
                            {
                                hasAlpha = true;
                                break;
                            }
                        }
                        Console.WriteLine(hasAlpha ? "Alpha channel present." : "No alpha channel.");

                        // Save the dimmed image as TIFF
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
 * 1. When a graphic designer needs to batch‑process CorelDRAW (CDR) files to create darker preview thumbnails in TIFF format for a web gallery, this code can rasterize, dim, and verify transparency.
 * 2. When an e‑learning platform must convert CDR illustrations to high‑resolution TIFFs with reduced brightness for print‑friendly handouts while ensuring any alpha channel is preserved, the snippet provides the needed steps.
 * 3. When a document management system imports CDR logos, applies a uniform dimming effect to meet brand guidelines, and checks for semi‑transparent pixels before storing them as TIFF assets, developers can use this example.
 * 4. When a digital archiving solution needs to migrate legacy CDR artwork to TIFF, lower the image brightness to match archival standards, and confirm the presence of an alpha channel for later compositing, this code handles the workflow.
 * 5. When a marketing automation tool generates dimmed TIFF versions of CDR product images for email campaigns and must detect any non‑opaque pixels to avoid rendering issues, the provided C# code performs the required processing.
 */