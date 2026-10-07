// HOW-TO: Convert Multiple OTG Files to PDF in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output file paths
                string[] inputPaths = new string[]
                {
                    "input\\file1.otg",
                    "input\\file2.otg",
                    "input\\file3.otg"
                };

                string[] outputPaths = new string[]
                {
                    "output\\file1.pdf",
                    "output\\file2.pdf",
                    "output\\file3.pdf"
                };

                // Process files in parallel
                Parallel.For(0, inputPaths.Length, i =>
                {
                    string inputPath = inputPaths[i];
                    string outputPath = outputPaths[i];

                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load OTG image and save as PDF
                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new PdfOptions());
                    }
                });
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
 * 1. When a web service must batch‑convert uploaded OTG drawings to PDF quickly for user download.
 * 2. When a desktop application needs to generate printable PDFs from many OTG design files without freezing the UI.
 * 3. When an automated build pipeline processes a large archive of OTG assets and creates PDF documentation in parallel to reduce build time.
 * 4. When a cloud function receives multiple OTG images and must convert them to PDF simultaneously to meet SLA response times.
 * 5. When a migration script moves legacy OTG files to a PDF‑based archive and wants to speed up the conversion by using multi‑core processing.
 */
