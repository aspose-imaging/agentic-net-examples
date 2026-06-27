using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output_dithered.gif";

            // Verify input file exists
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
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with a 4‑bit palette (16 colors)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                // Save the processed animation as a new GIF file
                gifImage.Save(outputPath);
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
 * 1. When a developer needs to compress an animated GIF to a 4‑bit (16‑color) palette while maintaining visual fidelity by applying Floyd‑Steinberg dithering in a C# .NET project.
 * 2. When a web application must generate lightweight GIF animations for low‑bandwidth users by dither‑reducing the color count before serving the file.
 * 3. When a desktop utility has to batch‑process user‑uploaded GIFs, converting them to a smaller palette with dithering to meet size constraints for email attachments.
 * 4. When a game developer wants to import legacy GIF sprites and automatically apply dithering to match the limited color palette of retro graphics engines.
 * 5. When an e‑learning platform needs to create optimized GIF tutorials that retain smooth animation after reducing colors with Floyd‑Steinberg dithering using Aspose.Imaging for .NET.
 */