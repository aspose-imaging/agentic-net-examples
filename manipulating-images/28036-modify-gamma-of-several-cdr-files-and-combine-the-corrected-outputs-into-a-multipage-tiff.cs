using System;
using System.IO;
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

            // Validate input files
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output TIFF path (ensure it contains a directory)
            string outputPath = "output\\combined.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Process the first CDR to obtain canvas size and create the TIFF canvas
            using (CdrImage firstCdr = (CdrImage)Image.Load(inputPaths[0]))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOpts = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = firstCdr.Width,
                            PageHeight = firstCdr.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        }
                    };
                    firstCdr.Save(ms, pngOpts);
                    ms.Position = 0;

                    using (RasterImage firstRaster = (RasterImage)Image.Load(ms))
                    {
                        // Apply gamma correction
                        firstRaster.AdjustGamma(2.2f);

                        int width = firstRaster.Width;
                        int height = firstRaster.Height;

                        // Create TIFF canvas bound to the output file
                        var tiffOpts = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
                        using (Image tiffImage = Image.Create(tiffOpts, width, height))
                        {
                            var tiff = (TiffImage)tiffImage;

                            // Add the first corrected page
                            tiff.AddPage(firstRaster);

                            // Process remaining CDR files
                            for (int i = 1; i < inputPaths.Length; i++)
                            {
                                using (CdrImage cdr = (CdrImage)Image.Load(inputPaths[i]))
                                {
                                    using (MemoryStream msInner = new MemoryStream())
                                    {
                                        var pngOptsInner = new PngOptions
                                        {
                                            VectorRasterizationOptions = new VectorRasterizationOptions
                                            {
                                                PageWidth = cdr.Width,
                                                PageHeight = cdr.Height,
                                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                                SmoothingMode = SmoothingMode.None
                                            }
                                        };
                                        cdr.Save(msInner, pngOptsInner);
                                        msInner.Position = 0;

                                        using (RasterImage raster = (RasterImage)Image.Load(msInner))
                                        {
                                            raster.AdjustGamma(2.2f);
                                            tiff.AddPage(raster);
                                        }
                                    }
                                }
                            }

                            // Remove the initial blank page created by Image.Create
                            tiff.RemoveFrame(0);

                            // Save the multipage TIFF
                            tiff.Save();
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
 * 1. When a publishing workflow requires batch gamma correction of multiple CorelDRAW (CDR) illustrations and the final product must be a single multipage TIFF for high‑resolution printing, this code automates the entire process.
 * 2. When an archival system needs to normalize the brightness of several CDR design files and store them as a consolidated multipage TIFF for long‑term preservation and easy retrieval, developers can use this example.
 * 3. When a marketing team wants to apply consistent gamma adjustments to a series of CDR assets before combining them into one TIFF document for inclusion in a product catalog, the code provides a repeatable solution.
 * 4. When a document‑management application must convert a collection of vector CDR pages, correct their gamma levels, and generate a single multipage TIFF for downstream OCR or PDF generation, this snippet handles the conversion pipeline.
 * 5. When an e‑learning platform needs to preprocess multiple CorelDRAW slide files with gamma correction and merge them into a multipage TIFF for seamless streaming to learners, the code delivers the required image processing workflow.
 */