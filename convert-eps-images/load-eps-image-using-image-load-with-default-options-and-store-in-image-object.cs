// HOW-TO: How to Load an EPS Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.eps";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load EPS image with default options
            Image image = Image.Load(inputPath);

            // Example usage: output a simple confirmation
            Console.WriteLine("EPS image loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to open an EPS vector file in a .NET application to inspect or manipulate its contents.
 * 2. When you want to verify that an EPS file exists before processing it in a batch conversion workflow.
 * 3. When you need to read an EPS image into memory so you can later export it to another format such as PNG or PDF.
 * 4. When you are building a server‑side service that accepts user‑uploaded EPS files and must confirm they can be loaded without errors.
 * 5. When you are debugging image‑loading issues and want a simple way to confirm that Aspose.Imaging can parse the EPS file correctly.
 */
