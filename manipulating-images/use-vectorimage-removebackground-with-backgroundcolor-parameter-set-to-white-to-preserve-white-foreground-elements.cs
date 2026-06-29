using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.emf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (VectorImage vectorImage = (VectorImage)Image.Load(inputPath))
            {
                // Configure background removal settings to treat white as background
                var bgSettings = new RemoveBackgroundSettings
                {
                    Color1 = Aspose.Imaging.Color.White
                };

                // Remove the background using the specified settings
                vectorImage.RemoveBackground(bgSettings);

                // Save the processed image
                vectorImage.Save(outputPath);
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
 * 1. When generating printable marketing brochures, a developer can use this code to strip the white page background from EMF logos while keeping white text or icons intact for clean overlay on colored paper.
 * 2. When preparing vector graphics for a web‑based diagram editor, the code helps remove the default white canvas from uploaded EMF files so users can place the diagram on any background without losing white foreground shapes.
 * 3. When automating the conversion of scanned engineering drawings to SVG, a developer can first remove the white background from the original EMF to ensure the resulting vector retains white linework and symbols.
 * 4. When creating custom UI themes that embed vector icons into dark mode applications, this snippet removes the white background of EMF assets while preserving white icon details for proper contrast.
 * 5. When building a batch processing tool that extracts product illustrations from EMF templates, the code eliminates the white template background while keeping white product highlights, enabling seamless compositing into catalogs.
 */