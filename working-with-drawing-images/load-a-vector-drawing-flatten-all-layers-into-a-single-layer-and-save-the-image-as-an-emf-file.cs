using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                EmfImage emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("Input is not an EMF image.");
                    return;
                }

                EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

                using (EmfImage flatImage = graphics.EndRecording())
                {
                    flatImage.Save(outputPath);
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
 * 1. When a developer needs to convert a multi‑layer EMF drawing into a single‑layer vector file for compatibility with legacy Windows applications.
 * 2. When an automated report generator must flatten all layers of a vector illustration before embedding it into a PDF or Word document.
 * 3. When a batch‑processing tool has to ensure that complex EMF graphics render consistently by saving them as a single‑layer EMF after removing hidden layers.
 * 4. When a GIS or CAD integration requires simplifying a vector map by merging its layers into one EMF file for faster loading in mapping software.
 * 5. When a cloud‑based image service needs to validate and re‑save uploaded EMF files as flat images to prevent layer‑related security issues.
 */