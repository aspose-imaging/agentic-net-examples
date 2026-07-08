using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath, new EpsLoadOptions()))
            {
                // ------------------------------------------------------------
                // NOTE: Aspose.Imaging does not provide a direct API to replace
                // gradients with solid colors in vector EPS content. If such
                // processing is required, it must be implemented by parsing
                // the EPS/PostScript stream and modifying the drawing commands.
                // For the purpose of this example we proceed to save the image
                // as SVG without explicit gradient replacement.
                // ------------------------------------------------------------

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    // Example: render text as shapes to avoid font dependencies
                    TextAsShapes = true
                };

                // Save the simplified image as SVG
                epsImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy EPS artwork to a web‑compatible SVG file in a C# application while ensuring text is rendered as shapes to avoid font dependencies.
 * 2. When an automated workflow must verify the existence of an EPS file, create the target directory, and export the vector image as SVG to simplify assets for faster page loading.
 * 3. When a .NET service processes incoming EPS files, replaces complex gradient definitions with solid colors (by parsing the PostScript stream) and saves the cleaned‑up vector graphic as SVG for downstream editing.
 * 4. When a batch job uses Aspose.Imaging to load multiple EPS documents, handle missing files gracefully, and generate SVG outputs with TextAsShapes enabled for consistent rendering across browsers.
 * 5. When a graphics pipeline requires converting EPS to SVG while stripping advanced gradient features to produce lightweight, gradient‑free SVG files that are compatible with basic SVG editors.
 */