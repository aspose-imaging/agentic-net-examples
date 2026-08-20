// HOW-TO: Apply Gaussian Blur to Multiple CDR Files and Merge into Multipage TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            string inputPath1 = "input1.cdr";
            string inputPath2 = "input2.cdr";
            string inputPath3 = "input3.cdr";

            // Hardcoded output TIFF path
            string outputPath = "merged_output.tif";

            // Verify input files exist
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

            // Prepare list to hold TIFF frames
            List<TiffFrame> frames = new List<TiffFrame>();

            // Process each CDR file
            string[] inputs = { inputPath1, inputPath2, inputPath3 };
            foreach (string inputPath in inputs)
            {
                // Load CDR vector image
                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    // Rasterize CDR to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        cdr.Save(ms, new PngOptions());
                        ms.Position = 0;

                        // Load rasterized image
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Apply Gaussian blur
                            var blurOptions = new GaussianBlurFilterOptions { Radius = 5 };
                            raster.Filter(raster.Bounds, blurOptions);

                            // Create TIFF frame from blurred raster
                            TiffFrame frame = new TiffFrame(raster);
                            frames.Add(frame);
                        }
                    }
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create TIFF options for the multipage TIFF
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Compression = TiffCompressions.Lzw;

            // Build multipage TIFF
            using (TiffImage tiffImage = new TiffImage(frames[0]))
            {
                for (int i = 1; i < frames.Count; i++)
                {
                    tiffImage.AddFrame(frames[i]);
                }

                // Save the multipage TIFF
                tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When a designer needs to batch‑process CorelDRAW (CDR) artwork, apply a soft blur effect, and combine the results into a single multi‑page TIFF for printing or archiving.
 * 2. When an application must convert vector CDR drawings to raster images, apply a Gaussian filter for visual smoothing, and store them as pages of a TIFF document for PDF generation.
 * 3. When a workflow requires automatically generating blurred previews of several CDR files and packaging them into one TIFF file for quick review in document management systems.
 * 4. When a developer wants to create a multi‑page TIFF slideshow where each slide is a blurred version of a different CDR illustration, without writing intermediate files to disk.
 * 5. When a server‑side service needs to rasterize multiple CDR assets, apply image‑processing effects, and deliver the combined TIFF to clients for further analysis or printing.
 */
