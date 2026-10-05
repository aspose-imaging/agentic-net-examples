// HOW-TO: Convert PNG to PSD and Verify Validity in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            const string inputPath = "input.png";
            const string outputPath = "output/output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();
                image.Save(outputPath, psdOptions);
            }

            using (Image psdImage = Image.Load(outputPath))
            {
                if (psdImage.Width > 0 && psdImage.Height > 0)
                {
                    Console.WriteLine("PSD conversion successful and file is valid.");
                }
                else
                {
                    Console.Error.WriteLine("PSD file loaded but has invalid dimensions.");
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
 * 1. When you need to generate Photoshop‑compatible PSD files from PNG assets in a C# application and ensure the files open without errors.
 * 2. When automating a workflow that converts user‑uploaded PNG images to PSD for further editing in Adobe Photoshop while programmatically confirming the conversion succeeded.
 * 3. When building a batch‑processing tool that creates PSD versions of design assets and validates their dimensions before publishing to a digital asset management system.
 * 4. When integrating Aspose.Imaging into a .NET service that must deliver PSD files to clients and guarantee the files are readable by Photoshop.
 * 5. When testing a CI/CD pipeline that includes image format conversion, you can use this code to confirm the generated PSD files are not corrupted.
 */
