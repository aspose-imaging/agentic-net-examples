// HOW-TO: Convert DjVu Pages 1‑3 To PNG And Merge Into Multipage TIFF C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/document.djvu";
            string pngOutputDir = "Output/PNGs";
            string tiffOutputPath = "Output/merged.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(pngOutputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(tiffOutputPath));

            // Export pages 1-3 to PNG
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < 3; i++)
                {
                    string pngPath = Path.Combine(pngOutputDir, $"page{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.MultiPageOptions = new DjvuMultiPageOptions(i);
                        djvu.Save(pngPath, pngOptions);
                    }
                }
            }

            // Merge PNGs into a multipage TIFF
            string firstPng = Path.Combine(pngOutputDir, "page1.png");
            using (RasterImage firstImg = (RasterImage)Image.Load(firstPng))
            {
                int width = firstImg.Width;
                int height = firstImg.Height;

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                    {
                        // Add frames for pages 2 and 3
                        for (int i = 1; i < 3; i++)
                        {
                            tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                        }

                        // Copy pixels for each frame
                        for (int i = 0; i < 3; i++)
                        {
                            string pngPath = Path.Combine(pngOutputDir, $"page{i + 1}.png");
                            using (RasterImage src = (RasterImage)Image.Load(pngPath))
                            {
                                tiff.ActiveFrame = tiff.Frames[i];
                                ((RasterImage)tiff.ActiveFrame).SaveArgb32Pixels(tiff.ActiveFrame.Bounds, src.LoadArgb32Pixels(src.Bounds));
                            }
                        }

                        // Save TIFF
                        Directory.CreateDirectory(Path.GetDirectoryName(tiffOutputPath));
                        tiff.Save(tiffOutputPath, tiffOptions);
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
 * 1. When you need to extract specific pages from a DjVu document and save them as high‑quality PNG images for web preview.
 * 2. When you must combine several exported PNG pages into a single multipage TIFF for archival or printing workflows.
 * 3. When an application processes scanned books stored as DjVu and requires individual page images before creating a consolidated TIFF file.
 * 4. When a document management system needs to convert selected DjVu pages to PNG and then bundle them into a TIFF to support legacy TIFF‑only viewers.
 * 5. When automating batch conversion of DjVu chapters into PNG and merging them into a multipage TIFF for easy distribution to clients.
 */
