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
            string inputPath = "sample.cmx";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                bool isMultiPage = false;
                if (image is IMultipageImage multipageImage)
                {
                    isMultiPage = multipageImage.PageCount > 1;
                }
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
 * 1. When a CAD application imports a CMX file and must decide whether to render a single drawing or iterate through multiple pages for batch processing.
 * 2. When an automated document conversion service needs to split a multi‑page CMX drawing into separate PNG files, it first checks the Image.IsMultiPage property.
 * 3. When a quality‑control script validates incoming design assets and flags multi‑page CMX files that require special handling before publishing.
 * 4. When a cloud‑based image viewer loads a CMX file and determines whether to enable page navigation controls based on the page count.
 * 5. When a migration tool moves legacy CMX drawings to a new repository and uses the IMultipageImage interface to identify and log files that contain more than one page.
 */