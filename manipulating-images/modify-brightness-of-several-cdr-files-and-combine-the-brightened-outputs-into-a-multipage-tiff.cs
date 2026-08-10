// HOW-TO: Adjust Brightness of Multiple CDR Files and Save as Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
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
            string input1 = "input1.cdr";
            string input2 = "input2.cdr";
            string input3 = "input3.cdr";

            // Hardcoded output TIFF file
            string outputPath = "output.tif";

            // Validate input files
            if (!File.Exists(input1)) { Console.Error.WriteLine($"File not found: {input1}"); return; }
            if (!File.Exists(input2)) { Console.Error.WriteLine($"File not found: {input2}"); return; }
            if (!File.Exists(input3)) { Console.Error.WriteLine($"File not found: {input3}"); return; }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Load first CDR to obtain canvas size
            using (CdrImage canvasCdr = (CdrImage)Image.Load(input1))
            {
                int width = canvasCdr.Width;
                int height = canvasCdr.Height;

                // Create empty multipage TIFF with the canvas size
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // Remove the initially created blank frame
                    tiffImage.RemoveFrame(0);

                    // Process each CDR file
                    string[] inputs = new[] { input1, input2, input3 };
                    foreach (var input in inputs)
                    {
                        using (CdrImage cdr = (CdrImage)Image.Load(input))
                        {
                            // Rasterize CDR to PNG in memory
                            using (MemoryStream ms = new MemoryStream())
                            {
                                PngOptions pngOptions = new PngOptions();
                                pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                                {
                                    PageWidth = cdr.Width,
                                    PageHeight = cdr.Height
                                };
                                cdr.Save(ms, pngOptions);
                                ms.Position = 0;

                                // Load the rasterized PNG
                                using (PngImage png = (PngImage)Image.Load(ms))
                                {
                                    // Create a TIFF frame from the PNG image
                                    TiffFrame frame = new TiffFrame(png);

                                    // Adjust brightness (example value: +30)
                                    frame.AdjustBrightness(30);

                                    // Add the processed frame to the multipage TIFF
                                    tiffImage.AddFrame(frame);
                                }
                            }
                        }
                    }

                    // Save the final multipage TIFF
                    tiffImage.Save();
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
 * 1. When you need to increase the visual contrast of several CorelDRAW (CDR) drawings before archiving them as a single multipage TIFF document.
 * 2. When an automated batch job must apply a brightness adjustment to multiple CDR files and combine the results for printing or PDF conversion.
 * 3. When a web service receives user‑uploaded CDR artwork, brightens each image, and returns a combined TIFF for easy preview or download.
 * 4. When migrating legacy CDR assets to a TIFF‑based workflow and you want to standardize brightness across all pages in one file.
 * 5. When generating a catalog where each product illustration is stored as a CDR file, and you need a uniformly bright, multipage TIFF for inclusion in the final brochure.
 */
