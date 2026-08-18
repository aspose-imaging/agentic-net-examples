// HOW-TO: Convert BMP to PSD with 8‑Bit Indexed Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.psd";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD save options
                PsdOptions psdOptions = new PsdOptions();

                // Set 8‑bit indexed color mode
                psdOptions.ColorMode = ColorModes.Indexed;          // Indexed palette mode
                psdOptions.ChannelBitsCount = 8;                    // 8 bits per channel

                // Create a custom palette (example: red, green, blue)
                Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Green,
                    Aspose.Imaging.Color.Blue
                };
                IColorPalette customPalette = new ColorPalette(paletteColors);
                psdOptions.Palette = customPalette;

                // Save the image as PSD using the configured options
                image.Save(outputPath, psdOptions);
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
 * 1. When you need to import legacy BMP graphics into Photoshop while preserving a limited color set, you can convert them to PSD with an 8‑bit indexed palette using C#.
 * 2. When generating assets for a game that requires PSD files with a specific palette for layer masks, this code creates the required PSD from a BMP source.
 * 3. When automating a batch workflow that standardizes image colors for printing, you can load BMP files and save them as PSD with a custom red‑green‑blue palette.
 * 4. When integrating a .NET application with a design pipeline that only accepts indexed‑color PSD files, this snippet converts incoming BMP images accordingly.
 * 5. When you want to reduce file size by limiting colors before editing in Photoshop, the code converts BMP to an 8‑bit indexed PSD with a custom palette in C#.
 */
