// HOW-TO: Check If a CMX Image Has Multiple Pages in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                bool isMultiPage = image is IMultipageImage;
                Console.WriteLine($"Is multi-page: {isMultiPage}");
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
 * 1. When you need to verify whether an imported CorelDRAW CMX file contains more than one page before processing each layer individually.
 * 2. When your application must decide to split or merge pages of a CMX document based on its multi‑page status.
 * 3. When you want to conditionally apply batch conversions only to single‑page CMX files to avoid unexpected results.
 * 4. When you are building a preview generator that should display a navigation control only if the CMX source has multiple pages.
 * 5. When you need to log or report the page‑count capability of CMX assets during automated quality‑control checks.
 */
