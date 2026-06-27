using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\output_sequential.png";
        string referencePath = @"c:\temp\reference.png";

        // Verify input files exist
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }
        if (!File.Exists(referencePath))
        {
            Console.Error.WriteLine($"File not found: {referencePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply filters sequentially
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                raster.Save(outputPath);
            }

            // Load the processed image and the reference image
            using (Image resultImg = Image.Load(outputPath))
            using (Image referenceImg = Image.Load(referencePath))
            {
                RasterImage result = (RasterImage)resultImg;
                RasterImage reference = (RasterImage)referenceImg;

                const double tolerance = 1.0; // acceptable per‑channel difference
                bool withinTolerance = true;

                // Compare each pixel
                for (int y = 0; y < result.Height && withinTolerance; y++)
                {
                    for (int x = 0; x < result.Width && withinTolerance; x++)
                    {
                        var pResult = result.GetPixel(x, y);
                        var pRef = reference.GetPixel(x, y);

                        if (Math.Abs(pResult.R - pRef.R) > tolerance ||
                            Math.Abs(pResult.G - pRef.G) > tolerance ||
                            Math.Abs(pResult.B - pRef.B) > tolerance ||
                            Math.Abs(pResult.A - pRef.A) > tolerance)
                        {
                            withinTolerance = false;
                        }
                    }
                }

                Console.WriteLine(withinTolerance
                    ? "Sequential filters are within tolerance."
                    : "Sequential filters exceed tolerance.");
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
 * 1. When a developer needs to ensure that applying a median filter, Gaussian blur, and sharpen filter to PNG assets for a web‑gallery does not introduce noticeable color drift, they can use this code to compare the result against a reference image within a 1‑unit per‑channel tolerance.
 * 2. When building a medical‑imaging workflow that sequentially denoises, smooths, and sharpens DICOM‑converted PNG scans, the code verifies that cumulative rounding errors stay below the acceptable diagnostic threshold.
 * 3. When creating an automated CI pipeline for a satellite‑image processing service, the code can validate that chaining filters on GeoTIFF‑converted PNG tiles produces output identical to a golden reference, preventing drift over successive releases.
 * 4. When developing a desktop photo‑editing application that lets users apply multiple filters in one operation, this snippet can be used in unit tests to confirm that the sequential filter pipeline preserves pixel fidelity across BMP, JPEG, and PNG formats.
 * 5. When performing batch image preprocessing for machine‑learning training data, the code helps ensure that applying a series of filters does not alter pixel values beyond the defined tolerance, guaranteeing consistent model input quality.
 */