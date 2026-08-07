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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\sample.bmp";
            string outputPath = @"C:\Temp\output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options with Grayscale color mode
                PsdOptions psdOptions = new PsdOptions
                {
                    ColorMode = ColorModes.Grayscale
                };

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
 * 1. When converting a high‑resolution BMP scan of a printed photograph to a Photoshop PSD for further editing, and the final artwork must be monochrome, a developer can set PsdOptions.ColorMode to Grayscale before saving.
 * 2. When generating printable proof files from a batch of color images in a C# application and the printer only accepts grayscale PSDs, the code ensures the output uses the Grayscale color mode.
 * 3. When creating a web service that receives user‑uploaded BMP images and returns a PSD version optimized for black‑and‑white magazine layouts, the developer uses this snippet to enforce grayscale conversion.
 * 4. When automating the archival of legacy bitmap assets into Photoshop PSD format while reducing file size by removing color data, setting ColorMode to Grayscale before saving achieves the desired result.
 * 5. When building a desktop utility that converts scanned documents to PSD files for designers who need a non‑color layer structure, the code guarantees the PSD is saved in Grayscale mode for consistent monochrome editing.
 */