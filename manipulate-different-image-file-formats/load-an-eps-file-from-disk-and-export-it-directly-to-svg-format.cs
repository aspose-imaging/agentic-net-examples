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
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Create default SVG export options
                var svgOptions = new SvgOptions();

                // Export the image to SVG format
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to display legacy EPS artwork in browsers that only support SVG, a developer can use this code to convert the EPS file to SVG on the server side.
 * 2. When an automated build pipeline must generate scalable icons from EPS design assets for responsive UI, the code enables batch conversion to SVG format.
 * 3. When a document management system imports vector files and must store them as web‑friendly SVG for preview, the developer can load the EPS and save it as SVG using Aspose.Imaging.
 * 4. When a desktop tool allows users to edit or annotate vector graphics and requires converting uploaded EPS files to SVG for further processing, this snippet performs the conversion.
 * 5. When a cloud service provides an API that accepts EPS uploads and returns SVG output for downstream analytics, the code demonstrates the C# implementation of the conversion step.
 */