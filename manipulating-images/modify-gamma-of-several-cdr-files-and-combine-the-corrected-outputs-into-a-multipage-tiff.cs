// HOW-TO: Apply Gamma Correction to Multiple CDR Files and Create Multipage TIFF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input CDR files
            string[] inputPaths = {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF path
            string outputPath = "output.tif";

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect frames after gamma correction
            List<TiffFrame> frames = new List<TiffFrame>();

            foreach (var cdrPath in inputPaths)
            {
                // Load CDR vector image
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Rasterize CDR to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        };
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load rasterized image
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Apply gamma correction (example gamma value 0.8)
                            raster.AdjustGamma(0.8f);

                            // Create a TIFF frame from the raster image
                            TiffFrame frame = new TiffFrame(raster);
                            frames.Add(frame);
                        }
                    }
                }
            }

            if (frames.Count == 0)
            {
                Console.Error.WriteLine("No frames were created.");
                return;
            }

            // Prepare TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create a TIFF image canvas with the size of the first frame
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, frames[0].Width, frames[0].Height))
            {
                // Remove the initially created empty frame
                tiff.RemoveFrame(0);

                // Add all processed frames
                foreach (var frame in frames)
                {
                    tiff.AddFrame(frame);
                }

                // Save the multipage TIFF
                tiff.Save(outputPath, tiffOptions);
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
 * 1. When you need to batch‑process several CorelDRAW (CDR) drawings, adjust their gamma for consistent brightness, and save them as a single multipage TIFF for printing or archival.
 * 2. When an application must convert vector CDR files to raster images, apply color‑correction, and combine the results into one TIFF document for easy distribution to clients.
 * 3. When a workflow requires automated preparation of CDR assets for a document management system, ensuring each page has uniform gamma before merging them into a multipage TIFF.
 * 4. When you are building a C# service that normalizes the visual appearance of multiple CDR illustrations and packages them into a TIFF stack for use in PDF generation or e‑publishing.
 * 5. When you need to programmatically rasterize, gamma‑adjust, and concatenate several CDR files into a single TIFF file for batch scanning or OCR processing.
 */
