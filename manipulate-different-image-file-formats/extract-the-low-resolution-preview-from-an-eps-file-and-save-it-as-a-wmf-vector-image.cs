using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output/preview.wmf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Retrieve the WMF preview (low‑resolution vector preview)
            Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.WMF);

            if (preview == null)
            {
                Console.Error.WriteLine("No WMF preview available in the EPS file.");
                return;
            }

            // Save the preview as a WMF file
            preview.Save(outputPath);
            preview.Dispose();
        }
    }
}