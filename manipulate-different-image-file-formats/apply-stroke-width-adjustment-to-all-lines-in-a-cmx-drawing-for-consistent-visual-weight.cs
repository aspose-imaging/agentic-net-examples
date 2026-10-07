// HOW-TO: How To Load And Save A CMX File With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.cmx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                CmxImage cmxImage = image as CmxImage;
                if (cmxImage != null)
                {
                    cmxImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not a CMX image.");
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
 * 1. When you need to open a CorelDRAW CMX drawing, make minor edits programmatically, and then write it back to preserve the original format.
 * 2. When an automated pipeline must verify that a CMX file exists and can be successfully loaded before further processing.
 * 3. When you want to copy a CMX file to a new location while ensuring it is read correctly by Aspose.Imaging to avoid corrupted files.
 * 4. When a server‑side application needs to read a CMX image, apply future transformations, and save it without changing its metadata.
 * 5. When you are testing that the Aspose.Imaging library correctly handles CMX files on a .NET platform.
 */
