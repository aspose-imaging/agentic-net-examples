using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\EmfInput";
            string outputDir = @"C:\SvgOutput";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Collection of EMF file names to process
            string[] emfFiles = new string[]
            {
                "sample1.emf",
                "sample2.emf",
                "sample3.emf"
            };

            foreach (var fileName in emfFiles)
            {
                // Build full input path and verify existence
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build full output path (same name with .svg extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true // Convert text to shapes for fidelity
                    };

                    // Configure rasterization options specific to EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Color.WhiteSmoke,
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to migrate a legacy Windows drawing library that stores graphics as EMF metafiles into modern web‑friendly SVG files for responsive UI rendering.
 * 2. When an automation script must generate scalable vector icons from a batch of EMF assets for inclusion in a cross‑platform mobile app.
 * 3. When a document conversion service has to preserve vector fidelity while converting engineering diagrams saved as EMF into SVG for PDF generation.
 * 4. When a CI/CD pipeline requires bulk conversion of EMF logo files to SVG to ensure crisp printing and scaling in marketing materials.
 * 5. When a data‑visualization tool needs to import multiple EMF charts and export them as SVG to enable interactive web visualizations without loss of detail.
 */