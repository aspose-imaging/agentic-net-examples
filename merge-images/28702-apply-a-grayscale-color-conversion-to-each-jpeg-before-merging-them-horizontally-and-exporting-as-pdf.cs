// HOW-TO: Convert JPEG to PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/input.jpg";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to transform high‑resolution JPEG photos into lossless PNG files for web display or further image processing, they can use this code.
 * 2. When an application must batch‑convert user‑uploaded JPEG images to PNG to ensure consistent transparency support across browsers, this snippet provides the conversion logic.
 * 3. When a reporting tool requires PNG charts generated from JPEG sources before embedding them into PDFs, the code shows how to load and save the images in C#.
 * 4. When a mobile backend service receives JPEG attachments and needs to store them as PNG to meet storage‑policy standards, this example demonstrates the conversion step.
 * 5. When a legacy system outputs JPEG files but a new workflow expects PNG assets for machine‑learning preprocessing, developers can apply this routine to bridge the format gap.
 */
