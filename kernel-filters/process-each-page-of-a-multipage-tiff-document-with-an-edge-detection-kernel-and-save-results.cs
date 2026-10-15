// HOW-TO: Apply Edge Detection to Each Page of a Multipage TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Aspose.Imaging.Image inputImg = Aspose.Imaging.Image.Load(inputPath);
            using (TiffImage inputTiff = (TiffImage)inputImg)
            {
                int firstWidth = inputTiff.Width;
                int firstHeight = inputTiff.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                Aspose.Imaging.Image outputImg = Aspose.Imaging.Image.Create(tiffOptions, firstWidth, firstHeight);
                using (TiffImage outputTiff = (TiffImage)outputImg)
                {
                    int frameIndex = 0;
                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    foreach (TiffFrame frame in inputTiff.Frames)
                    {
                        // Load frame pixels into a raster image
                        using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)frame)
                        {
                            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel));

                            // Prepare a new frame for the output TIFF
                            TiffFrame newFrame = new TiffFrame(tiffOptions, raster.Width, raster.Height);
                            newFrame.SavePixels(newFrame.Bounds, raster.LoadPixels(raster.Bounds));

                            if (frameIndex == 0)
                            {
                                // Replace the initially created frame
                                outputTiff.Frames[0].SavePixels(outputTiff.Frames[0].Bounds, raster.LoadPixels(raster.Bounds));
                            }
                            else
                            {
                                outputTiff.AddFrame(newFrame);
                            }
                        }

                        frameIndex++;
                    }

                    outputTiff.Save(outputPath);
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
 * 1. When you need to highlight outlines in scanned documents stored as a multi‑page TIFF for better visual analysis.
 * 2. When you want to preprocess each frame of a multi‑page TIFF before feeding it into a computer‑vision model that requires edge‑enhanced images.
 * 3. When you must generate a new TIFF where every page shows detected edges for printing or archival purposes.
 * 4. When you are building a C# utility that automatically applies a convolution filter to every page of a TIFF batch for quality‑control inspections.
 * 5. When you need to convert a multi‑page TIFF into an edge‑detected version to compare before‑and‑after effects in a document‑management system.
 */
