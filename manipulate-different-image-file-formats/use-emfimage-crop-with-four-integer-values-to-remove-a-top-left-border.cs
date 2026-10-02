// HOW-TO: Crop Top Left Border from EMF Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
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

            using (EmfImage image = (EmfImage)Image.Load(inputPath))
            {
                // Remove a top-left border by cropping 10 pixels from left and top.
                // Adjust the right and bottom values as needed; here we keep the original width and height.
                int left = 10;
                int top = 10;
                int right = image.Width - left;
                int bottom = image.Height - top;

                image.Crop(left, top, right, bottom);
                image.Save(outputPath);
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
 * 1. When you need to remove unwanted margins from a vector EMF logo before embedding it in a PDF report.
 * 2. When preparing EMF diagrams for a web application that requires a clean edge without a 10‑pixel offset.
 * 3. When automating batch processing of scanned EMF drawings to eliminate a consistent top‑left border across all files.
 * 4. When integrating Aspose.Imaging into a C# service that trims excess whitespace from generated EMF charts for better layout.
 * 5. When converting legacy EMF assets for a UI and need to programmatically crop the image to match the design specifications.
 */
