// HOW-TO: Merge Multiple TIFF Files into a Single Multi‑Frame TIFF in C# (Aspose.Imaging for .NET)
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
            string inputPath1 = "input1.tif";
            string inputPath2 = "input2.tif";
            string inputPath3 = "input3.tif";
            string outputPath = "output\\merged.tif";

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage srcImage1 = (TiffImage)Image.Load(inputPath1))
            using (TiffImage srcImage2 = (TiffImage)Image.Load(inputPath2))
            using (TiffImage srcImage3 = (TiffImage)Image.Load(inputPath3))
            {
                // Determine canvas size from the first frame of the first image
                int canvasWidth = srcImage1.ActiveFrame.Width;
                int canvasHeight = srcImage1.ActiveFrame.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage outputImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    int frameIndex = 0;

                    // Helper local function to copy frames from a source image
                    void CopyFrames(TiffImage source)
                    {
                        foreach (TiffFrame srcFrame in source.Frames)
                        {
                            if (frameIndex == 0)
                            {
                                // Replace pixels of the initially created blank frame
                                var srcPixels = ((RasterImage)source).LoadPixels(srcFrame.Bounds);
                                outputImage.Frames[0].SavePixels(srcFrame.Bounds, srcPixels);
                            }
                            else
                            {
                                // Add a new blank frame and copy pixels into it
                                outputImage.AddFrame(new TiffFrame(tiffOptions, srcFrame.Width, srcFrame.Height));
                                var srcPixels = ((RasterImage)source).LoadPixels(srcFrame.Bounds);
                                outputImage.Frames[frameIndex].SavePixels(srcFrame.Bounds, srcPixels);
                            }
                            frameIndex++;
                        }
                    }

                    CopyFrames(srcImage1);
                    CopyFrames(srcImage2);
                    CopyFrames(srcImage3);

                    outputImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to combine scanned pages stored as separate TIFF files into one multi‑frame TIFF for easier distribution or printing.
 * 2. When a document management system requires a single TIFF document that contains all pages of a multi‑page report generated from separate image sources.
 * 3. When you want to create a compact archival file by merging individual TIFF images from a camera or scanner into one file without losing metadata.
 * 4. When a web service must accept multiple TIFF uploads and return a single combined TIFF for downstream processing or OCR.
 * 5. When you are building a batch‑processing tool that consolidates daily generated TIFF charts into one multi‑frame image for automated analysis.
 */
