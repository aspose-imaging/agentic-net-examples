using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true // Preserve text as shapes
                };

                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
                    // Optional margins can be set here, e.g., BorderX = 50, BorderY = 50
                };

                saveOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save as SVG
                emfImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}