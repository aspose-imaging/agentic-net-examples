using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input path
        string inputPath = "sample.cmx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the CMX vector file
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Cache data for faster access
                cmx.CacheData();

                // Enumerate pages (drawing objects) in the CMX file
                int pageIndex = 0;
                foreach (CmxImagePage page in cmx.Pages)
                {
                    // Cache each page's data
                    page.CacheData();

                    Console.WriteLine($"Page {pageIndex}:");
                    Console.WriteLine($"  Width: {page.Width} px");
                    Console.WriteLine($"  Height: {page.Height} px");
                    Console.WriteLine($"  BitsPerPixel: {page.BitsPerPixel}");
                    Console.WriteLine($"  Size: {page.Size.Width}x{page.Size.Height}");
                    // Additional analysis of drawing objects can be added here if API provides such collections
                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}