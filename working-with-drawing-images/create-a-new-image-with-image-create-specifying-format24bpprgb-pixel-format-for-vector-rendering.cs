// HOW-TO: Create a 200x200 BMP Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions()
            {
                Source = source
            };

            using (BmpImage image = (BmpImage)Image.Create(options, 200, 200))
            {
                image.Save();
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
 * 1. When a developer needs to generate a blank BMP file of a specific size to use as a canvas for drawing vector graphics in a C# application.
 * 2. When an automated reporting tool must create a 200 × 200 pixel bitmap to embed as a placeholder image in PDF or Word documents.
 * 3. When a game engine requires a BMP texture of known dimensions for legacy hardware that only supports 24‑bit RGB images.
 * 4. When a batch process has to produce a series of uniformly sized BMP files for printing labels or receipts that demand exact pixel dimensions.
 * 5. When a unit test must verify that Aspose.Imaging can successfully create and save a new BMP image using FileCreateSource without loading an existing file.
 */
