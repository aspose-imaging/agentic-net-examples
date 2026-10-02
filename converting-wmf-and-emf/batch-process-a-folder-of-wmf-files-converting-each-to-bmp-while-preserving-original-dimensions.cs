// HOW-TO: Batch Convert WMF Files to BMP While Preserving Dimensions in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputWmf";
            string outputFolder = @"C:\OutputBmp";

            // Get all WMF files in the input folder
            string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

            foreach (string wmfPath in wmfFiles)
            {
                // Validate input file existence
                if (!File.Exists(wmfPath))
                {
                    Console.Error.WriteLine($"File not found: {wmfPath}");
                    return;
                }

                // Determine output BMP path
                string outputFileName = Path.GetFileNameWithoutExtension(wmfPath) + ".bmp";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image
                using (Image image = Image.Load(wmfPath))
                {
                    // Save as BMP preserving original dimensions
                    image.Save(outputPath);
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
 * 1. When you need to migrate a legacy collection of vector WMF icons to raster BMP files for use in a Windows application that only supports bitmap resources.
 * 2. When an automated build pipeline must generate BMP thumbnails from a folder of WMF diagrams while keeping the original size for accurate printing.
 * 3. When a document conversion service processes user‑uploaded WMF graphics in bulk and stores them as BMP images to ensure compatibility with older imaging libraries.
 * 4. When you are preparing assets for a game engine that requires BMP textures, and you want to batch‑convert all WMF art assets without scaling them.
 * 5. When a legacy reporting tool expects BMP images, and you need a C# script to read multiple WMF charts from a directory and save them unchanged in BMP format.
 */
