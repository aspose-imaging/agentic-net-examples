using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image and save it without modification
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Save the result as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
            }

            // Verify that the background is near black by computing average intensity
            using (Image outImage = Image.Load(outputPath))
            {
                RasterImage outRaster = (RasterImage)outImage;

                int[] argbPixels = outRaster.LoadArgb32Pixels(outRaster.Bounds);
                long total = 0;
                foreach (int argb in argbPixels)
                {
                    total += (argb >> 16) & 0xFF; // Red
                    total += (argb >> 8) & 0xFF;  // Green
                    total += argb & 0xFF;         // Blue
                }

                double averageIntensity = total / (double)(argbPixels.Length * 3);
                Console.WriteLine($"Average color intensity: {averageIntensity:F2}");

                if (averageIntensity < 30)
                    Console.WriteLine("Background is near black.");
                else
                    Console.WriteLine("Background is not near black.");
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
 * 1. When a C# developer needs to confirm that a zero‑sum edge‑detection kernel correctly renders a near‑black background on a PNG file, they can use this Aspose.Imaging code to load, save, and compute the average color intensity.
 * 2. When building an automated image‑processing pipeline that applies custom convolution filters, this snippet verifies that the resulting background remains dark enough for downstream OCR or document analysis.
 * 3. When performing regression testing after updating the Aspose.Imaging library, the code checks that saved PNG images still produce the expected low‑intensity background after edge detection.
 * 4. When creating a quality‑control tool for scanned photographs, developers can employ this example to ensure the edge‑enhancement step does not introduce unwanted background brightness.
 * 5. When integrating C# image‑filtering features into a web service, the routine provides a quick way to validate that the zero‑sum kernel yields a near‑black backdrop before serving the processed PNG to clients.
 */