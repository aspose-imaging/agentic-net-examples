using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.wmf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS file as an EpsImage
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Retrieve the WMF preview image
            Image wmfPreview = epsImage.GetPreviewImage(EpsPreviewFormat.WMF);
            if (wmfPreview == null)
            {
                Console.Error.WriteLine("No WMF preview available in the EPS file.");
                return;
            }

            // Save the preview as a WMF file
            wmfPreview.Save(outputPath, new WmfOptions());
        }
    }
}