// HOW-TO: Convert Animated WebP to APNG While Preserving Frame Timing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.webp";
            string outputPath = "output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the animated WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as Animated PNG (APNG) preserving original frame timing
                image.Save(outputPath, new ApngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display animated web graphics on platforms that only support APNG, you can convert WebP animations to APNG with original timing using C#.
 * 2. When optimizing a mobile app’s assets, you may replace WebP animations with APNG to ensure compatibility with iOS while keeping the animation speed unchanged.
 * 3. When building a server‑side image processing pipeline, you might convert user‑uploaded animated WebP files to APNG for downstream tools that require PNG input.
 * 4. When creating marketing emails that only allow PNG images, you can transform animated WebP banners into APNGs without losing the intended frame delays.
 * 5. When migrating a legacy website’s animated assets from WebP to a format supported by older browsers, you can use this code to batch‑convert them while preserving the original animation timing.
 */
