using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image eps = Image.Load(inputPath))
        {
            // Cast to the concrete EpsImage type using fully qualified name
            var epsImage = eps as Aspose.Imaging.FileFormats.Eps.EpsImage;
            if (epsImage == null)
            {
                Console.Error.WriteLine("Failed to load EPS image.");
                return;
            }

            // Retrieve the TIFF preview
            using (Image preview = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.TIFF))
            {
                if (preview == null)
                {
                    Console.Error.WriteLine("No TIFF preview available.");
                    return;
                }

                // Save the preview image; the file extension determines the format
                preview.Save(outputPath);
            }
        }
    }
}