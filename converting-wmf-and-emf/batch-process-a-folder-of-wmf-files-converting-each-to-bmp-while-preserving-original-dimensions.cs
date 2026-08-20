// HOW-TO: Batch Convert WMF Files to BMP with Original Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output folders
            string inputFolder = @"C:\InputWmf";
            string outputFolder = @"C:\OutputBmp";

            // Get all WMF files in the input folder
            string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

            foreach (string inputPath in wmfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output BMP path preserving the original file name
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".bmp");

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set rasterization options to keep original dimensions
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Configure BMP save options with the rasterization settings
                    var bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as BMP
                    image.Save(outputPath, bmpOptions);
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
 * 1. When a legacy Windows application requires BMP icons instead of WMF vectors, you can batch convert the WMF assets while keeping their original dimensions.
 * 2. When preparing a set of technical diagrams for a PDF report that only supports raster images, you can transform all WMF files to BMP at their native size.
 * 3. When a game engine imports only bitmap textures, you can automatically convert a folder of WMF sprites to BMP without scaling them.
 * 4. When archiving design assets for a compliance audit, you can preserve the exact visual size by converting each WMF file to a BMP copy in bulk.
 * 5. When a printing workflow demands BMP files for high‑resolution output, you can use this code to batch process WMF files while retaining their original pixel dimensions.
 */
