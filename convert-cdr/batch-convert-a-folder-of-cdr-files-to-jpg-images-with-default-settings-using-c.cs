// HOW-TO: Batch Convert CDR Files to JPG Images in C# (Aspose.Imaging for .NET)
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
            string inputFolder = @"C:\InputCdr";
            string outputFolder = @"C:\OutputJpg";

            string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions options = new JpegOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to automatically generate web‑ready JPEG previews of a large collection of CorelDRAW (CDR) designs stored in a folder.
 * 2. When a migration project requires converting legacy CDR artwork to JPEG format for use in a .NET application without manual intervention.
 * 3. When an e‑commerce platform must batch‑process product illustrations originally saved as CDR files into JPEG thumbnails for faster page loads.
 * 4. When a digital asset management system needs to archive CDR drawings as JPEGs to ensure compatibility with standard image viewers.
 * 5. When a Windows service has to nightly convert newly added CDR files in a directory to JPEGs for downstream reporting or printing workflows.
 */
