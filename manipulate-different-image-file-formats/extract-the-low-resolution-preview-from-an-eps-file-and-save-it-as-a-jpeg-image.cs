using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

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
            // Retrieve the default low‑resolution preview
            var previewImage = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.Default);
            if (previewImage == null)
            {
                Console.Error.WriteLine("No preview image found in the EPS file.");
                return;
            }

            // Save the preview as JPEG
            using (previewImage)
            {
                var jpegOptions = new JpegOptions();
                previewImage.Save(outputPath, jpegOptions);
            }
        }
    }
}