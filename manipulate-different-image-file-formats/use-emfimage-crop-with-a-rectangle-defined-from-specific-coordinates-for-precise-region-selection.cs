// HOW-TO: Crop a Specific Region from an EMF File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.emf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (EmfImage emf = (EmfImage)Image.Load(inputPath))
            {
                Rectangle cropRect = new Rectangle(10, 20, 200, 150);
                emf.Crop(cropRect);

                EmfOptions options = new EmfOptions();
                emf.Save(outputPath, options);
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
 * 1. When you need to extract only a portion of a vector‑based EMF diagram for reuse in a report.
 * 2. When generating thumbnails of a selected area from a large EMF drawing to improve loading speed.
 * 3. When removing unwanted margins from an EMF logo before embedding it in a web page.
 * 4. When isolating a specific chart region from an EMF file to feed into another graphics workflow.
 * 5. When programmatically preparing a cropped EMF segment for printing on a custom‑size label.
 */
