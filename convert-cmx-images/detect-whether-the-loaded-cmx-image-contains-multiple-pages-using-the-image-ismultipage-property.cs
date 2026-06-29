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
            // Hardcoded input path
            string inputPath = "sample.cmx";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                bool isMultiPage = false;
                if (image is IMultipageImage multipageImage)
                {
                    isMultiPage = multipageImage.PageCount > 1;
                }

                // Output the result
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
 * 1. When a CAD application imports CMX drawings and must decide whether to treat the file as a single sheet or iterate through multiple pages for batch rendering.
 * 2. When a document conversion service needs to split a multi‑page CMX file into separate PNGs, it first checks Image.IsMultiPage to avoid unnecessary processing on single‑page files.
 * 3. When an automated quality‑control pipeline validates that a submitted CMX design contains more than one layout page before triggering a multi‑page review workflow.
 * 4. When a web‑based viewer loads CMX assets and wants to display navigation controls only if the loaded image reports a page count greater than one via IMultipageImage.
 * 5. When a reporting tool aggregates statistics on CMX files and uses the IsMultiPage property to categorize files into single‑page versus multi‑page groups for analytics.
 */