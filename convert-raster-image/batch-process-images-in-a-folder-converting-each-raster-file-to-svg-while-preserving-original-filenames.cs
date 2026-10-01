// HOW-TO: Batch Convert Raster Images To SVG In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchRasterToSvg
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = @"C:\Images\Input";
                string outputFolder = @"C:\Images\Output";

                // Ensure the base output directory exists
                Directory.CreateDirectory(outputFolder);

                string[] files = Directory.GetFiles(inputFolder);
                foreach (string inputPath in files)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Process only common raster image extensions
                    string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                    if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".bmp" && ext != ".tif" && ext != ".tiff" && ext != ".gif")
                    {
                        continue;
                    }

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        SvgOptions options = new SvgOptions();
                        image.Save(outputPath, options);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically convert a folder of PNG, JPEG, BMP, or GIF files into scalable SVG graphics while keeping the original file names.
 * 2. When a web application must generate vector versions of user‑uploaded raster images for responsive design without manual processing.
 * 3. When a reporting system requires batch transformation of scanned TIFF documents into SVG for lightweight embedding in PDFs.
 * 4. When a migration script has to replace legacy raster assets with SVG equivalents across a large media library using C#.
 * 5. When an automated build pipeline should include image optimization by converting all raster assets to SVG to improve scalability and reduce size.
 */
