// HOW-TO: Convert Single Page CMX to Multi Page TIFF with Blank Pages in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
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
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (guard against null)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Rasterize CMX to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new StreamSource(ms)
                    };
                    cmx.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int width = raster.Width;
                        int height = raster.Height;

                        // Create first TIFF frame from rasterized CMX page
                        TiffFrame firstFrame = new TiffFrame(raster);

                        // Initialize TIFF image with the first frame
                        using (TiffImage tiffImage = new TiffImage(firstFrame))
                        {
                            // Options for blank frames and final save
                            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                            // Add two blank pages
                            for (int i = 0; i < 2; i++)
                            {
                                TiffFrame blankFrame = new TiffFrame(tiffOptions, width, height);
                                tiffImage.AddFrame(blankFrame);
                            }

                            // Save the multi‑page TIFF
                            tiffImage.Save(outputPath, tiffOptions);
                        }
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as searchable multi‑page TIFF files for document management systems.
 * 2. When a printing workflow requires converting a single CMX page into a multi‑page TIFF that includes placeholder pages for later insertion.
 * 3. When you must integrate CMX artwork into a TIFF‑based report and need to add blank pages to match a predefined page count.
 * 4. When automating batch conversion of CMX files to TIFF for compliance, and the TIFF must contain extra blank pages for signature or annotation sections.
 * 5. When building a C# application that transforms vector CMX graphics into raster TIFF images while programmatically inserting empty pages for layout consistency.
 */
