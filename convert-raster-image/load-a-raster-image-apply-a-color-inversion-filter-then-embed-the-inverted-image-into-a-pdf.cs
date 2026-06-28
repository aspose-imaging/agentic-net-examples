using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.png");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine("Output", "sample_converted.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to generate a printable PDF report that includes a high‑contrast version of a scanned diagram, they can load the PNG, invert its colors with Aspose.Imaging, and embed the result into the PDF.
 * 2. When creating accessibility‑friendly documentation, a developer may invert dark‑on‑light images to light‑on‑dark for better readability on e‑ink devices and then insert the transformed image into a PDF using C#.
 * 3. When automating the preparation of marketing brochures that require a negative‑film effect, a developer can apply a color inversion filter to product photos and embed the altered images into a PDF catalog.
 * 4. When building a forensic analysis tool that highlights hidden details by inverting image colors before archiving them, a developer can load the raster file, invert it with Aspose.Imaging, and store the result in a PDF evidence file.
 * 5. When developing a batch conversion utility that converts user‑uploaded PNG screenshots into PDF manuals with inverted colors for night‑mode viewing, a developer can use the image loading, inversion, and PDF embedding workflow in C#.
 */