using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputEmf";
        string outputDirectory = @"C:\OutputSvg";

        try
        {
            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output SVG file path
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image and convert it to SVG
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Configure SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options specific to EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        // Preserve original page size
                        PageSize = emfImage.Size,
                        // Optional: set background color
                        BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                        // Render mode (auto selects EMF or WMF)
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                        // Optional margins
                        BorderX = 0,
                        BorderY = 0
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the image as SVG
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