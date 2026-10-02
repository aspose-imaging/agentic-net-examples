// HOW-TO: Load TIFF From Memory Stream And Append PNG And JPG Frames In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
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
            string inputTiffPath = "input.tif";
            string outputTiffPath = "output\\merged.tif";
            string framePath1 = "frame1.png";
            string framePath2 = "frame2.jpg";

            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }
            if (!File.Exists(framePath1))
            {
                Console.Error.WriteLine($"File not found: {framePath1}");
                return;
            }
            if (!File.Exists(framePath2))
            {
                Console.Error.WriteLine($"File not found: {framePath2}");
                return;
            }

            byte[] tiffBytes = File.ReadAllBytes(inputTiffPath);
            using (var ms = new MemoryStream(tiffBytes))
            {
                using (TiffImage tiffImage = (TiffImage)Image.Load(ms))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                    using (Image additionalImage1 = Image.Load(framePath1))
                    {
                        int width1 = additionalImage1.Width;
                        int height1 = additionalImage1.Height;
                        tiffImage.AddFrame(new TiffFrame(tiffOptions, width1, height1));
                        TiffFrame newFrame1 = tiffImage.Frames[tiffImage.Frames.Count() - 1];
                        newFrame1.SavePixels(newFrame1.Bounds, ((RasterImage)additionalImage1).LoadPixels(additionalImage1.Bounds));
                    }

                    using (Image additionalImage2 = Image.Load(framePath2))
                    {
                        int width2 = additionalImage2.Width;
                        int height2 = additionalImage2.Height;
                        tiffImage.AddFrame(new TiffFrame(tiffOptions, width2, height2));
                        TiffFrame newFrame2 = tiffImage.Frames[tiffImage.Frames.Count() - 1];
                        newFrame2.SavePixels(newFrame2.Bounds, ((RasterImage)additionalImage2).LoadPixels(additionalImage2.Bounds));
                    }

                    Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));
                    tiffImage.Save(outputTiffPath);
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
 * 1. When you need to combine separate images such as a scanned document and additional graphics into a single multi‑page TIFF without writing the original file to disk first.
 * 2. When a web service receives a TIFF as a byte array and you must add extra pages from user‑uploaded PNG or JPEG files before saving or returning it.
 * 3. When generating a multi‑page report where the base TIFF is created elsewhere and you programmatically insert charts or photos as new frames.
 * 4. When processing large TIFF files in memory to avoid I/O overhead while merging additional image layers for archival or printing purposes.
 * 5. When building a document conversion pipeline that reads a TIFF from a database BLOB, adds supplemental pages, and stores the merged TIFF back to storage.
 */
