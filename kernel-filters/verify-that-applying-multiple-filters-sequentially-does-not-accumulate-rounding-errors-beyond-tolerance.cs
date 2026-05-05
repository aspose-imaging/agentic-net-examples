using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Path safety rules
        string inputPath = @"C:\temp\sample.png";
        string outputPath1 = @"C:\temp\output_sequential1.png";
        string outputPath2 = @"C:\temp\output_sequential2.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath1));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

        try
        {
            // Load the same image twice for two different filter orders
            using (Image imgA = Image.Load(inputPath))
            using (Image imgB = Image.Load(inputPath))
            {
                RasterImage rasterA = (RasterImage)imgA;
                RasterImage rasterB = (RasterImage)imgB;

                // Apply Sharpen then Gaussian Blur on rasterA
                rasterA.Filter(rasterA.Bounds, new SharpenFilterOptions(5, 4.0));
                rasterA.Filter(rasterA.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply Gaussian Blur then Sharpen on rasterB
                rasterB.Filter(rasterB.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                rasterB.Filter(rasterB.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed images
                rasterA.Save(outputPath1);
                rasterB.Save(outputPath2);

                // Verify that the sequential application does not accumulate rounding errors beyond tolerance
                const double tolerance = 1.0; // per channel tolerance
                bool withinTolerance = true;
                double maxDiff = 0.0;

                for (int y = 0; y < rasterA.Height; y++)
                {
                    for (int x = 0; x < rasterA.Width; x++)
                    {
                        // Get pixel colors from both images
                        Color colorA = rasterA.GetPixel(x, y);
                        Color colorB = rasterB.GetPixel(x, y);

                        // Compute absolute differences per channel
                        double diffR = Math.Abs(colorA.R - colorB.R);
                        double diffG = Math.Abs(colorA.G - colorB.G);
                        double diffB = Math.Abs(colorA.B - colorB.B);
                        double diffA = Math.Abs(colorA.A - colorB.A);

                        double pixelMax = Math.Max(Math.Max(diffR, diffG), Math.Max(diffB, diffA));
                        if (pixelMax > maxDiff) maxDiff = pixelMax;

                        if (pixelMax > tolerance)
                        {
                            withinTolerance = false;
                            // Break early if desired
                        }
                    }
                }

                if (withinTolerance)
                {
                    Console.WriteLine($"Success: Max channel difference {maxDiff} is within tolerance {tolerance}.");
                }
                else
                {
                    Console.WriteLine($"Failure: Max channel difference {maxDiff} exceeds tolerance {tolerance}.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}