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
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.emf";
            string outputPath = @"C:\temp\output.emf";

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
                // Configure background removal to treat white as the background color
                var settings = new RemoveBackgroundSettings
                {
                    Color1 = Aspose.Imaging.Color.White
                };

                // Remove the background using the specified settings
                vectorImage.RemoveBackground(settings);

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
 * 1. When converting legacy EMF diagrams that have a white canvas but contain white line art that must stay visible, a developer can use VectorImage.RemoveBackground with a white backgroundColor to strip only the true background while preserving white foreground elements.
 * 2. When preparing vector graphics for printing on colored paper, a developer needs to remove the default white background from an EMF file without erasing white logos or text, using the provided code.
 * 3. When integrating a document generation system that embeds vector icons into PDFs, a developer can clean up the icons by removing the white background while keeping white symbols intact, ensuring correct rendering.
 * 4. When building a web service that receives user‑uploaded EMF files and returns a transparent version for overlay on web pages, a developer can apply RemoveBackground with Color1 set to white to achieve transparency without losing white details.
 * 5. When automating batch processing of corporate branding assets stored as EMF files, a developer can use this code to strip the white background from each file while retaining white brand elements before exporting to other vector formats.
 */