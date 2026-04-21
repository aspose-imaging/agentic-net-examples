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
        // Hardcoded input and output directories
        string inputDir = @"C:\InputEmf";
        string outputDir = @"C:\OutputSvg";

        try
        {
            // Get all EMF files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.emf");

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output SVG path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Set up SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options for EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = EmfRenderMode.Auto,
                        BorderX = 0,
                        BorderY = 0
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG (embedded images are stored as Base64 by default)
                    emfImage.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}