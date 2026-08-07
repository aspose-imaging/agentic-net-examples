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
            string inputPath = "input.svg";
            string outputPath = "output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to generate a printable PDF report from a multi‑page SVG diagram while preserving the original vector quality and page sequence.
 * 2. When an application must convert a batch of SVG assets created by a design tool into a single PDF portfolio for easy distribution to clients.
 * 3. When a web service receives an uploaded multi‑page SVG invoice and must return a PDF version that retains scalable graphics for compliance auditing.
 * 4. When a desktop utility automates the transformation of SVG‑based technical drawings into a consolidated PDF handbook without rasterizing the images.
 * 5. When a CI/CD pipeline includes a step that validates that SVG documentation can be rendered as a single PDF file with exact vector fidelity for archival purposes.
 */