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
            // Hardcoded input and output directories
            string inputDir = @"C:\InputImages";
            string outputDir = @"C:\OutputSvgs";

            // Retrieve all files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in files)
            {
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".odg" && ext != ".otg")
                    continue; // Skip non‑ODG/OTG files

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare SVG export options
                    SvgOptions svgOptions = new SvgOptions();

                    // Choose rasterization options based on file type
                    if (ext == ".odg")
                    {
                        OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                        svgOptions.VectorRasterizationOptions = rasterOptions;
                    }
                    else // .otg
                    {
                        OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                        svgOptions.VectorRasterizationOptions = rasterOptions;
                    }

                    // Save as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}