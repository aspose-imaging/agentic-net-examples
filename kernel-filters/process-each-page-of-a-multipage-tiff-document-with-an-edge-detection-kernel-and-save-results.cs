// HOW-TO: Apply Edge Detection to Each Page of a Multipage TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input TIFF path
            string inputPath = "input.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multipage TIFF image
            using (Image img = Image.Load(inputPath))
            {
                TiffImage tiff = img as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("Input file is not a TIFF image.");
                    return;
                }

                // Edge detection kernel (simple Laplacian)
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Create convolution filter options with the kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Process each frame (page) of the TIFF
                for (int i = 0; i < tiff.PageCount; i++)
                {
                    // Set the current frame as active
                    tiff.ActiveFrame = tiff.Frames[i];

                    // Apply the edge detection filter to the active frame
                    tiff.Filter(tiff.ActiveFrame.Bounds, filterOptions);

                    // Prepare output path for the processed page
                    string outputPath = Path.Combine("output", $"page_{i + 1}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed frame as PNG
                    using (var pngOptions = new PngOptions())
                    {
                        tiff.ActiveFrame.Save(outputPath, pngOptions);
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
 * 1. When you need to highlight outlines in each page of a scanned multipage TIFF before feeding it to an OCR engine.
 * 2. When you want to generate edge‑enhanced PNG previews of every page in a large TIFF archive for quick visual inspection.
 * 3. When processing medical imaging TIFF stacks to emphasize structural boundaries for diagnostic analysis in a C# application.
 * 4. When converting multi‑page engineering drawings stored as TIFF into separate PNG files with edge detection for feature extraction.
 * 5. When automating document digitization pipelines that require per‑page edge sharpening to improve downstream pattern‑recognition accuracy.
 */
