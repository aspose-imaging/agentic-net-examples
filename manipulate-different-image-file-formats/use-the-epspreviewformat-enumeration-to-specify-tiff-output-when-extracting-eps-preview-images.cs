using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output/preview.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (Image img = Image.Load(inputPath))
            {
                var epsImage = (EpsImage)img;

                // Retrieve TIFF preview
                Image preview = epsImage.GetPreviewImage(EpsPreviewFormat.TIFF);
                if (preview == null)
                {
                    Console.Error.WriteLine("No TIFF preview found in the EPS file.");
                    return;
                }

                // Save the preview image
                using (preview)
                {
                    preview.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}