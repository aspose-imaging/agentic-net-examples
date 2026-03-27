using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input directory containing EMF files
        string inputDir = "C:\\Images";

        // Get all EMF files in the directory
        string[] files = Directory.GetFiles(inputDir, "*.emf");

        foreach (var inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (overwrites original)
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access vector-specific methods
                EmfImage emf = (EmfImage)image;

                // Define integer crop bounds (e.g., trim 10 pixels from each side)
                int cropX = 10;
                int cropY = 10;
                int cropWidth = emf.Width - 2 * cropX;
                int cropHeight = emf.Height - 2 * cropY;

                // Perform cropping only if resulting dimensions are valid
                if (cropWidth > 0 && cropHeight > 0)
                {
                    Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                    emf.Crop(rect);
                }

                // Overwrite the original file with the cropped image
                emf.Save();
            }
        }
    }
}