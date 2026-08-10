// HOW-TO: Extract EPS Low‑Resolution WMF Preview and Save as WMF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\sample_preview.wmf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve WMF preview (low‑resolution)
                using (Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.WMF))
                {
                    if (preview != null)
                    {
                        // Save preview as WMF vector image
                        preview.Save(outputPath);
                    }
                    else
                    {
                        Console.Error.WriteLine("No WMF preview available in the EPS file.");
                    }
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
 * 1. When you need to generate a quick thumbnail of an EPS artwork for a Windows Forms UI, extracting the WMF preview lets you display a lightweight vector thumbnail without rendering the full EPS.
 * 2. When converting legacy EPS files to a format that older Office applications understand, saving the embedded WMF preview provides a compatible vector representation for documents.
 * 3. When building a batch process that indexes EPS files and stores a low‑resolution preview for search results, using the WMF preview reduces storage and speeds up rendering.
 * 4. When creating a print preview pane that shows a simplified version of an EPS diagram, extracting the WMF preview ensures fast display while preserving vector quality.
 * 5. When developing a migration tool that moves design assets from EPS to WMF for use in CAD or diagramming software, the code extracts the embedded preview to retain the original layout.
 */
