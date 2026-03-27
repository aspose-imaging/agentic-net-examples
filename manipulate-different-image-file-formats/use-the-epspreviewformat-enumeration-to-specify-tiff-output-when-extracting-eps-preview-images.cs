using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            // Extract TIFF preview
            using (var preview = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.TIFF))
            {
                if (preview != null)
                {
                    // Save the preview as a TIFF file
                    preview.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("No TIFF preview available in the EPS file.");
                }
            }
        }
    }
}