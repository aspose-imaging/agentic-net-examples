using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\sample_preview.wmf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the WMF preview (low‑resolution vector preview)
                using (Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.WMF))
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No WMF preview available in the EPS file.");
                        return;
                    }

                    // Save the preview as a WMF file
                    preview.Save(outputPath, new WmfOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}