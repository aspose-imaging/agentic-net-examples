// HOW-TO: Load EPS File and Save as PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

namespace EpsLoader
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath);
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
 * 1. When you need to convert a vector EPS artwork into a raster PNG for web preview in a C# application.
 * 2. When an automated workflow must validate the existence of an EPS file and generate a PNG thumbnail for a document management system.
 * 3. When you want to programmatically load an EPS logo and save it as a PNG to embed in a Windows Forms UI.
 * 4. When a server‑side service processes user‑uploaded EPS files and stores them as PNGs for faster delivery to browsers.
 * 5. When you are building a batch conversion tool that reads EPS files from disk and outputs PNG images using Aspose.Imaging.
 */
