// HOW-TO: Apply Dithering to Multiple CDR Files and Create Multipage TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
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
        try
        {
            // Hardcoded input CDR file paths
            string cdrPath1 = "input1.cdr";
            string cdrPath2 = "input2.cdr";
            string cdrPath3 = "input3.cdr";

            // Hardcoded output TIFF path
            string outputPath = "output.tif";

            // Validate input files
            if (!File.Exists(cdrPath1))
            {
                Console.Error.WriteLine($"File not found: {cdrPath1}");
                return;
            }
            if (!File.Exists(cdrPath2))
            {
                Console.Error.WriteLine($"File not found: {cdrPath2}");
                return;
            }
            if (!File.Exists(cdrPath3))
            {
                Console.Error.WriteLine($"File not found: {cdrPath3}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // List to hold processed raster images
            List<RasterImage> processedRasters = new List<RasterImage>();

            // Process each CDR file
            foreach (string cdrPath in new[] { cdrPath1, cdrPath2, cdrPath3 })
            {
                using (Image cdrImage = Image.Load(cdrPath))
                {
                    CdrImage cdr = (CdrImage)cdrImage;

                    // Rasterize CDR to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        pngOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        };
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load raster image from memory (do not dispose here)
                        RasterImage raster = (RasterImage)Image.Load(ms);

                        // Simple dithering: convert to black & white based on luminance
                        Color[] pixels = raster.LoadPixels(raster.Bounds);
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            Color c = pixels[i];
                            int gray = (int)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
                            pixels[i] = gray > 127 ? Color.White : Color.Black;
                        }
                        raster.SavePixels(raster.Bounds, pixels);

                        processedRasters.Add(raster);
                    }
                }
            }

            if (processedRasters.Count == 0)
            {
                Console.Error.WriteLine("No raster images were processed.");
                return;
            }

            // Create multipage TIFF
            int width = processedRasters[0].Width;
            int height = processedRasters[0].Height;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Set pixels for the first frame
                TiffFrame firstFrame = tiffImage.ActiveFrame;
                firstFrame.SavePixels(firstFrame.Bounds, processedRasters[0].LoadPixels(processedRasters[0].Bounds));

                // Add remaining frames
                for (int i = 1; i < processedRasters.Count; i++)
                {
                    TiffFrame frame = new TiffFrame(processedRasters[i]);
                    tiffImage.AddFrame(frame);
                }

                // Save the multipage TIFF
                tiffImage.Save();
            }

            // Dispose raster images
            foreach (var raster in processedRasters)
            {
                raster.Dispose();
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
 * 1. When a designer needs to batch convert several CorelDRAW (CDR) illustrations into a single multi‑page TIFF with dithering for consistent grayscale output.
 * 2. When an application must rasterize vector CDR files, apply dithering to reduce banding, and store the results in a compact multipage TIFF for archival or printing.
 * 3. When a workflow requires generating low‑color‑depth previews of multiple CDR assets and packaging them into one TIFF file for quick review.
 * 4. When a developer wants to automate the creation of a multipage TIFF document from a set of CDR pages to later convert it to PDF or send it to a document management system.
 * 5. When an e‑ink or legacy printer only accepts TIFF images, and the code must convert several CDR files with dithering to preserve detail before sending the combined file to the device.
 */
