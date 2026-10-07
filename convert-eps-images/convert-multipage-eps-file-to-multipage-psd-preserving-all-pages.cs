// HOW-TO: Convert Multipage EPS File to Multipage PSD Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                epsImage.Save(outputPath, new PsdOptions());
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
 * 1. When you need to preserve each page of a multipage EPS artwork as separate layers in a Photoshop PSD for further editing in C#.
 * 2. When automating a workflow that ingests vector EPS documents and outputs editable multipage PSD files using Aspose.Imaging.
 * 3. When converting print‑ready EPS files into a PSD format to integrate them into a multi‑page Photoshop project programmatically.
 * 4. When building a server‑side service that receives EPS uploads and returns a multipage PSD while keeping all pages intact.
 * 5. When migrating legacy EPS assets to PSD to enable layer‑based manipulation in .NET applications.
 */
