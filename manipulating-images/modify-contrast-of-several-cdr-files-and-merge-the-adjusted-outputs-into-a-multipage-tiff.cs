using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\Images\file1.cdr",
                @"C:\Images\file2.cdr"
            };

            // Hard‑coded output multipage TIFF
            string outputPath = @"C:\Images\merged_output.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to collect all rasterized TIFF frames
            List<TiffFrame> allFrames = new List<TiffFrame>();

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Iterate through each page of the CDR document
                    foreach (CdrImagePage cdrPage in cdrImage.Pages)
                    {
                        // Prepare rasterization options for the current page
                        var rasterOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdrPage.Width,
                            PageHeight = cdrPage.Height,
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };

                        // TIFF save options that use the rasterization settings
                        var tiffSaveOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Rasterize the page to a memory stream as TIFF
                        using (var ms = new MemoryStream())
                        {
                            cdrImage.Save(ms, tiffSaveOptions);
                            ms.Position = 0;

                            // Load the rasterized TIFF from the stream
                            using (TiffImage tiffImage = (TiffImage)Image.Load(ms))
                            {
                                // Adjust contrast (example value: 50)
                                tiffImage.AdjustContrast(50f);

                                // Clone the active frame and store it
                                TiffFrame frameCopy = new TiffFrame(tiffImage.ActiveFrame);
                                allFrames.Add(frameCopy);
                            }
                        }
                    }
                }
            }

            // If we have at least one frame, create the multipage TIFF
            if (allFrames.Count > 0)
            {
                // Initialize the final TIFF with the first frame
                using (TiffImage finalTiff = new TiffImage(allFrames[0]))
                {
                    // Append remaining frames
                    for (int i = 1; i < allFrames.Count; i++)
                    {
                        finalTiff.AddFrame(allFrames[i]);
                    }

                    // Save the combined multipage TIFF
                    finalTiff.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}