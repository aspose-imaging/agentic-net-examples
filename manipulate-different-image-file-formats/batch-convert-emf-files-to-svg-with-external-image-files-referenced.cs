// HOW-TO: Batch Convert EMF Files to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputEmf";
            string outputDirectory = @"C:\OutputSvg";

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path (same file name with .svg extension)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Set up SVG save options
                    SvgOptions svgOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options for EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                        BorderX = 0,
                        BorderY = 0
                    };

                    svgOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG
                    emfImage.Save(outputPath, svgOptions);
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
 * 1. When you need to automatically transform a folder of Windows Metafile (EMF) graphics into scalable SVG files for web display.
 * 2. When you want to preserve text as vector shapes during conversion to ensure crisp rendering at any resolution.
 * 3. When you must apply a uniform background color to all converted SVGs to match a corporate style guide.
 * 4. When you need to process multiple EMF assets in a batch job without manually opening each file.
 * 5. When you are integrating image conversion into a C# build pipeline that outputs SVGs for downstream vector editing tools.
 */
