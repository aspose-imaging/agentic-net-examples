// HOW-TO: Convert EPS to PSD with Custom Output Filename in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace EpsToPsdConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = @"C:\Images\sample.eps";
                string outputPath = @"C:\Images\sample_converted.psd";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new PsdOptions();
                    image.Save(outputPath, options);
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
 * 1. When a designer needs to batch‑convert EPS artwork to editable Photoshop PSD files while naming the outputs according to a specific pattern.
 * 2. When an automated build script must generate PSD previews of vector EPS logos for a web‑based asset library.
 * 3. When a content management system imports EPS files and stores them as PSDs to allow layer‑based editing in downstream tools.
 * 4. When a Windows service processes incoming EPS files from a scanner and saves them as PSDs in a designated folder with a custom naming convention.
 * 5. When a migration tool moves legacy EPS graphics to a Photoshop workflow and requires programmatic control over the output file path and format.
 */
