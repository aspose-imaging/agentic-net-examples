// HOW-TO: Check If EPS File Contains a Preview Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;

namespace EpsPreviewChecker
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output.txt";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                bool hasPreview = HasPreviewImage(inputPath);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                File.WriteAllText(outputPath, hasPreview ? "Preview found" : "No preview");

                Console.WriteLine(hasPreview ? "Preview found" : "No preview");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        private static bool HasPreviewImage(string epsPath)
        {
            using (var stream = new FileStream(epsPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
            {
                string line;
                // Read up to a reasonable number of lines to avoid scanning huge files unnecessarily
                int maxLines = 1000;
                int count = 0;
                while (!reader.EndOfStream && count < maxLines)
                {
                    line = reader.ReadLine();
                    if (line != null && line.StartsWith("%%BeginPreview", StringComparison.Ordinal))
                    {
                        return true;
                    }
                    count++;
                }
            }
            return false;
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When converting EPS files to other formats, you can verify a preview exists before attempting extraction to avoid errors.
 * 2. When generating thumbnails for a document management system, you can check for an EPS preview image to decide whether to use the embedded preview or render the vector data.
 * 3. When batch‑processing print jobs, you can skip EPS files without previews to prevent unnecessary rasterization steps.
 * 4. When validating user‑uploaded EPS assets in a web application, you can confirm a preview image is present to ensure a quick visual representation for the UI.
 * 5. When archiving design assets, you can log which EPS files contain previews to prioritize those that already have raster previews for faster preview generation.
 */
