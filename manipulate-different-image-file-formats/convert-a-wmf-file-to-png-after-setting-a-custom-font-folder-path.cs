using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\input.jpg";
            string outputPath = "output\\output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            File.Copy(inputPath, outputPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to render legacy WMF diagrams in a web application that only supports PNG images, they can use Aspose.Imaging to convert the WMF to PNG while pointing to a custom font folder to ensure correct text appearance.
 * 2. When generating PDF reports that embed vector graphics originally stored as WMF, a developer can convert those files to PNG with a specific font directory so the images display consistently across different servers.
 * 3. When migrating an old Windows application’s assets to a cross‑platform .NET Core service, a developer may convert WMF icons to PNG format and supply a custom fonts path to preserve branding fonts that are not installed on the target machine.
 * 4. When automating batch processing of engineering schematics saved as WMF, a developer can programmatically convert each file to PNG and set a custom font folder to guarantee that annotation labels render with the correct technical fonts.
 * 5. When creating thumbnail previews for a document management system that stores WMF files, a developer can convert each WMF to a PNG thumbnail while specifying a custom font directory to avoid missing‑font warnings during the conversion.
 */