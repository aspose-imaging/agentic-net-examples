using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.eps";
        string outputPath = "preview.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Retrieve low‑resolution preview (default format)
            Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.Default);
            if (preview == null)
            {
                Console.Error.WriteLine("No preview image found in the EPS file.");
                return;
            }

            // Save preview as JPEG
            var jpegOptions = new JpegOptions();
            preview.Save(outputPath, jpegOptions);
            preview.Dispose();
        }
    }
}