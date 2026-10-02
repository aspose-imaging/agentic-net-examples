// HOW-TO: Convert EMF to GIF with 256‑Color Palette in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "input.emf");
            string outputPath = Path.Combine("Output", "output.gif");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    image.Save(outputPath, gifOptions);
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
 * 1. When you need to embed a vector EMF logo into a web page that only supports GIF images.
 * 2. When you must reduce the file size of an EMF diagram for email attachments by converting it to a 256‑color GIF.
 * 3. When a legacy reporting system requires charts in GIF format but your source graphics are stored as EMF.
 * 4. When you want to generate web‑friendly frames from an EMF illustration for use in a GIF slideshow.
 * 5. When you are building a batch conversion tool that transforms multiple EMF files into GIFs with a limited color palette.
 */
