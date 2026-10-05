// HOW-TO: Load CMX Vector File and Get Dimensions in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Aspose.Imaging.FileFormats.Cmx.CmxImage cmx = (Aspose.Imaging.FileFormats.Cmx.CmxImage)Image.Load(inputPath))
            {
                Console.WriteLine($"CMX loaded. Width: {cmx.Width}, Height: {cmx.Height}");
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
 * 1. When you need to verify that a CMX vector file is accessible and retrieve its width and height before converting it to another image format.
 * 2. When building a batch processor that scans a directory of CMX files to collect their dimensions for a reporting dashboard.
 * 3. When integrating legacy CorelDRAW CMX assets into a .NET application and you must confirm the image metadata such as canvas size.
 * 4. When creating a quality‑check tool that flags CMX files with unexpected width or height values during import.
 * 5. When troubleshooting import errors by loading a CMX file and printing its basic properties to the console.
 */
