using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "sample.eps";
        string outputPath = "preview.jpg";

        // Ensure the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Create the output directory (if any) before saving
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the EPS file as an EpsImage
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the best available preview image (low‑resolution)
                using (Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.Default))
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No preview image found in the EPS file.");
                        return;
                    }

                    // Save the preview as a JPEG file
                    preview.Save(outputPath, new JpegOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}