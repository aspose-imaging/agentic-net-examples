// HOW-TO: Batch Convert EMF Files to SVG with Embedded Base64 Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;

namespace EmfToSvgBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\InputEmf";
                string outputDirectory = @"C:\OutputSvg";

                // Ensure the output directory exists
                Directory.CreateDirectory(outputDirectory);

                string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf", SearchOption.TopDirectoryOnly);
                foreach (string emfPath in emfFiles)
                {
                    if (!File.Exists(emfPath))
                    {
                        Console.Error.WriteLine($"File not found: {emfPath}");
                        return;
                    }

                    byte[] emfBytes = File.ReadAllBytes(emfPath);
                    string base64 = Convert.ToBase64String(emfBytes);

                    string svgContent = $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                                        $"<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">\n" +
                                        $"  <image href=\"data:image/emf;base64,{base64}\" />\n" +
                                        $"</svg>";

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(emfPath);
                    string svgPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(svgPath));

                    File.WriteAllText(svgPath, svgContent, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed legacy EMF diagrams into web pages without storing separate image files, you can batch convert them to SVG with Base64 data URIs using C#.
 * 2. When generating documentation that requires scalable vector graphics, converting a folder of EMF assets to SVG with embedded Base64 ensures the graphics render correctly across browsers.
 * 3. When automating a migration from Windows Metafile resources to a modern SVG workflow, this code lets you process all EMF files in one step and embed them directly in the SVG output.
 * 4. When creating a portable SVG package for email newsletters or offline reports, converting EMF to SVG with Base64 eliminates external image dependencies.
 * 5. When integrating legacy engineering drawings into a .NET application that consumes SVG, batch converting EMF files to Base64‑encoded SVG simplifies loading and rendering the images at runtime.
 */
