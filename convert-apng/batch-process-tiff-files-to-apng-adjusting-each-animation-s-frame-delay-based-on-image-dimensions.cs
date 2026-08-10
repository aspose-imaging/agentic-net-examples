// HOW-TO: Batch Convert TIFF to APNG with Dimension Based Frame Delay in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputTiffs";
        string outputFolder = @"C:\OutputApngs";

        try
        {
            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Compute frame delay based on image dimensions (average of width and height)
                    uint frameDelay = (uint)((image.Width + image.Height) / 2);

                    // Save as APNG with the calculated default frame time
                    ApngOptions apngOptions = new ApngOptions
                    {
                        DefaultFrameTime = frameDelay
                    };

                    image.Save(outputPath, apngOptions);
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
 * 1. When you need to automatically convert a folder of multi‑page TIFF scans into animated PNGs for web display, while setting each frame’s duration based on its size.
 * 2. When a graphics pipeline must generate lightweight APNG sprites from high‑resolution TIFF assets and ensure larger images stay on screen longer by using dimension‑derived frame times.
 * 3. When an archival system requires batch exporting of scanned documents to APNG format with consistent animation speed that adapts to varying image dimensions.
 * 4. When a game developer wants to create character animations from TIFF frames, automatically adjusting the playback speed so bigger frames appear slower without manual timing.
 * 5. When a reporting tool needs to transform TIFF charts into animated PNGs for dashboards, using the average width‑height to calculate a suitable default frame delay for each file.
 */
