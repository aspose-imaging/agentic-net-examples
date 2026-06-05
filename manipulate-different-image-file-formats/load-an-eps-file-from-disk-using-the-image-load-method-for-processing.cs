using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output\\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Optional: cast to EpsImage if EPS‑specific properties are needed
                // EpsImage epsImage = image as EpsImage;

                // Save the image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a legacy EPS logo into a PNG thumbnail for inclusion in a web page or mobile app.
 * 2. When an automated build script must verify EPS assets exist and generate PNG previews for a design review portal.
 * 3. When a batch‑processing tool has to read EPS files from a folder, apply image processing, and save them as PNGs for a print‑to‑screen workflow.
 * 4. When a content management system imports user‑uploaded EPS illustrations and stores them as PNGs to ensure browser compatibility.
 * 5. When a reporting service extracts EPS charts from a data export, loads them with Aspose.Imaging, and saves them as PNG images for PDF reports.
 */