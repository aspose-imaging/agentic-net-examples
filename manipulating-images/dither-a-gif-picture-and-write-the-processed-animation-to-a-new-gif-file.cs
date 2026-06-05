using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output_dithered.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific members
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Save the processed animation as a new GIF file
                gifImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce the file size of an animated GIF while preserving visual quality by applying Floyd‑Steinberg dithering with an 8‑bit palette before saving it as a new GIF.
 * 2. When a C# application must convert a high‑color GIF animation to a web‑friendly 256‑color version for faster page loads using Aspose.Imaging’s Dither method.
 * 3. When a software tool needs to preprocess user‑uploaded GIFs to ensure consistent color depth across all frames, enabling reliable display on legacy browsers.
 * 4. When an image‑processing pipeline requires automated validation, dithering, and re‑encoding of GIF animations to meet a specific color‑palette constraint for printing or archival purposes.
 * 5. When a developer wants to programmatically load a GIF, apply error‑diffusion dithering, and write the result to a new file without manual image editing tools.
 */