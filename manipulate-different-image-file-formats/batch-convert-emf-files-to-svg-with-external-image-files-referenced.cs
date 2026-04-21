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
            // Hardcoded list of EMF files to convert
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.emf",
                @"C:\Images\sample2.emf",
                @"C:\Images\sample3.emf"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .svg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options for EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        RenderMode = EmfRenderMode.Auto,
                        // Optional margins; can be adjusted as needed
                        BorderX = 0,
                        BorderY = 0,
                        BackgroundColor = Color.Transparent
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG
                    emfImage.Save(outputPath, saveOptions);
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