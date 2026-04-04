using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input CDR files
        string[] inputPaths = new string[]
        {
            @"C:\Images\file1.cdr",
            @"C:\Images\file2.cdr",
            @"C:\Images\file3.cdr"
        };

        // Hard‑coded output multipage TIFF
        string outputPath = @"C:\Images\combined.tif";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // List to hold paths of temporary adjusted TIFF pages
        List<string> adjustedTiffPaths = new List<string>();

        // Process each CDR file: rasterize, save as TIFF, adjust brightness
        foreach (string inputPath in inputPaths)
        {
            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // For simplicity, process only the first page of each CDR file
                var cdrPage = (CdrImagePage)cdrImage.Pages[0];

                // Rasterization options for converting vector page to raster image
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = cdrPage.Width,
                    PageHeight = cdrPage.Height,
                    BackgroundColor = Color.White
                };

                // Save the rasterized page directly to a temporary TIFF file
                string tempTiffPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".tif");
                var tiffSaveOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
                };
                cdrPage.Save(tempTiffPath, tiffSaveOptions);

                // Load the temporary TIFF, adjust brightness, and overwrite it
                using (TiffImage tiffImage = (TiffImage)Image.Load(tempTiffPath))
                {
                    // Brightness value in the range [-255, 255]
                    tiffImage.AdjustBrightness(50);
                    tiffImage.Save(tempTiffPath);
                }

                adjustedTiffPaths.Add(tempTiffPath);
            }
        }

        // Combine all adjusted TIFF pages into a single multipage TIFF
        if (adjustedTiffPaths.Count > 0)
        {
            // Load the first adjusted TIFF as the base image
            using (TiffImage finalTiff = (TiffImage)Image.Load(adjustedTiffPaths[0]))
            {
                // Append remaining pages
                for (int i = 1; i < adjustedTiffPaths.Count; i++)
                {
                    using (TiffImage pageTiff = (TiffImage)Image.Load(adjustedTiffPaths[i]))
                    {
                        // Add the active frame of the page to the final image
                        finalTiff.AddFrame(pageTiff.ActiveFrame);
                    }
                }

                // Save the combined multipage TIFF
                finalTiff.Save(outputPath);
            }
        }

        // Cleanup temporary files
        foreach (string tempPath in adjustedTiffPaths)
        {
            try { File.Delete(tempPath); } catch { /* ignore cleanup errors */ }
        }
    }
}