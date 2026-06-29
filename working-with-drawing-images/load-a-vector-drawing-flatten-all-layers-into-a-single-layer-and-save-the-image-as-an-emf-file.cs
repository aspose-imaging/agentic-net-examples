using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.emf";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the vector drawing
            using (Image image = Image.Load(inputPath))
            {
                // Prepare EMF export options with manual rasterization settings
                EmfOptions exportOptions = new EmfOptions();
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };
                exportOptions.VectorRasterizationOptions = vectorOptions;

                // Save the flattened image as EMF
                image.Save(outputPath, exportOptions);
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
 * 1. When a developer needs to convert a multi‑layer SVG graphic into a single‑layer EMF file for embedding in a Windows desktop application, this C# code using Aspose.Imaging provides a straightforward solution.
 * 2. When an automated reporting system must flatten vector layers from an SVG logo before exporting it as an EMF image for high‑quality printing, the code handles the rasterization and saving steps.
 * 3. When a batch‑processing tool has to read vector drawings, merge all layers into one, and store the result as an EMF to maintain scalability in Microsoft Office documents, this snippet performs the required operations.
 * 4. When a migration script needs to transform legacy SVG assets into EMF format while preserving page size and eliminating layer complexity for legacy Windows components, the example demonstrates the exact workflow.
 * 5. When a cloud service processes user‑uploaded SVG files and must deliver a flattened EMF version for downstream graphics pipelines, the code shows how to load, flatten, and save the image efficiently in C#.
 */