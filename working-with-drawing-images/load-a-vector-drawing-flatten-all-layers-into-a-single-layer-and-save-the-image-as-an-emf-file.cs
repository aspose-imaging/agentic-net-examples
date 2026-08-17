// HOW-TO: Flatten EMF Layers Into Single Layer and Save with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
                EmfImage emfImage = (EmfImage)image;
                EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);
                using (EmfImage flattened = graphics.EndRecording())
                {
                    flattened.Save(outputPath);
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
 * 1. When you need to combine multiple vector layers of an EMF drawing into a single layer before sending it to a printing service that only accepts flat EMF files.
 * 2. When a legacy application requires a simplified EMF file without layer information to ensure compatibility with older Windows GDI rendering.
 * 3. When you want to reduce the file size of a complex EMF by flattening layers, making it easier to embed in Word documents or PowerPoint presentations.
 * 4. When automating a workflow that extracts EMF assets from a design tool, flattens them, and stores the result in a shared folder for downstream processing.
 * 5. When preparing EMF graphics for digital signatures, flattening layers ensures the visual content remains unchanged after the signature is applied.
 */
