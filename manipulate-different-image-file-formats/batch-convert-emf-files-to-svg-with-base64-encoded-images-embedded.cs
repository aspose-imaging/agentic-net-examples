using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputEmf";
            string outputDir = @"C:\OutputSvg";

            // Ensure the output root directory exists
            Directory.CreateDirectory(outputDir);

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDir, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output SVG path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Configure SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true, // render text as shapes
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            BackgroundColor = Color.WhiteSmoke,
                            PageSize = emfImage.Size,
                            RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                            BorderX = 0,
                            BorderY = 0
                        }
                    };

                    // Save as SVG; embedded raster images are encoded as Base64 by default
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