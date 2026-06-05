using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
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

            // Prepare list to hold TIFF frames
            List<TiffFrame> frames = new List<TiffFrame>();
            string[] cdrPaths = { cdrPath1, cdrPath2, cdrPath3 };

            foreach (var cdrPath in cdrPaths)
            {
                // Load CDR vector image
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Set up PNG options with vector rasterization
                    var pngOptions = new PngOptions
                    {
                        Source = new StreamSource(new MemoryStream()),
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };

                    // Rasterize CDR to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load raster image
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Apply Gaussian blur
                            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.0));

                            // Create TIFF frame from blurred raster
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create multipage TIFF from frames
            using (TiffImage tiff = new TiffImage(frames.ToArray()))
            {
                tiff.Save(outputPath);
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
 * 1. When a designer needs to create a quick‑look preview of several CorelDRAW (CDR) illustrations with a soft focus effect for a client presentation, a developer can use this code to blur each CDR, rasterize it to PNG, and combine the results into a single multipage TIFF.
 * 2. When an archival system must store vector artwork as a searchable, page‑by‑page raster document while protecting the original designs with a subtle blur, this snippet automates loading the CDR files, applying a Gaussian blur, and merging them into a TIFF stack.
 * 3. When a print‑shop workflow requires generating proof sheets that show blurred versions of multiple CDR pages to hide sensitive details before final approval, the code provides a C# solution to process each file and output a combined TIFF file.
 * 4. When a digital asset management tool needs to batch‑process a collection of CorelDRAW files into a single compressed TIFF for easy preview and thumbnail generation, developers can employ this example to apply Gaussian blur and assemble the pages.
 * 5. When a web‑based catalog must display a multi‑page preview of vector drawings with a soft‑edge effect for aesthetic reasons, this program lets developers convert each CDR to a blurred raster image and bundle them into one multipage TIFF for fast loading.
 */