// HOW-TO: How to Dither a GIF Animation with Floyd Steinberg in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.gif";
            string outputPath = @"C:\Images\output_dithered.gif";

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
                // Cast to GifImage to access GIF‑specific functionality
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with a 4‑bit palette (16 colors)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                // Save the dithered animation to a new GIF file
                gifImage.Save(outputPath, new GifOptions());
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
 * 1. When you need to reduce a GIF animation to a 16‑color palette while preserving visual detail for display on devices that only support low‑color displays.
 * 2. When you want to apply Floyd‑Steinberg dithering to an existing GIF to give it a retro pixel‑art look before embedding it in a web page.
 * 3. When you are processing user‑uploaded GIFs and must ensure the file size stays small by limiting the palette to 4‑bit colors without losing important gradients.
 * 4. When you are creating animated email signatures and need to convert high‑color GIFs to a limited palette that complies with email client restrictions.
 * 5. When you are building a batch tool that automatically dither‑processes multiple GIF animations for use in a game engine that only accepts 16‑color sprite sheets.
 */
